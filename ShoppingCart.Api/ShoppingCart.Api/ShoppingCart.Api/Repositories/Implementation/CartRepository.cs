﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InsuranceCalculator.Api.Contexts;
using InsuranceCalculator.Api.Models.Data;
using InsuranceCalculator.Api.Models.Dto.Carts;
using InsuranceCalculator.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCalculator.Api.Repositories.Implementation
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICatalogRepository _catalogRepository;

        public CartRepository(ApiDbContext dbContext, 
            IMapper mapper, 
            ICatalogRepository catalogRepository) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _catalogRepository = catalogRepository;
        }

        public async Task<Cart> CreateShoppingCartAsync(CartContentsRequestDto cartContentsRequest)
        {
            var cart = new Cart();

            if (cartContentsRequest.Products.Any())
            {
                cart.Products = _mapper.Map<List<CartItem>>(cartContentsRequest.Products).ToList();
            }
            _dbContext.Add(cart);

            await _dbContext.SaveChangesAsync();
            return await EnrichCart(cart);
        }

        public async Task<Cart> UpdateShoppingCartAsync(int cartId, 
            CartContentsRequestDto cartContentsRequest)
        {
            var cart = await FindByIdAsync(cartId);
            if (cart == null)
                return null;

            cart.Products = _mapper.Map<List<CartItem>>(cartContentsRequest.Products).ToList();
            cart.UpdatedAt = DateTimeOffset.UtcNow;

            _dbContext.Update(cart);

            await _dbContext.SaveChangesAsync();
            return await EnrichCart(cart);
            //return cart;
        }


        public async Task RemoveShoppingCartAsync(int cartId)
        {
            var cart = await FindByIdAsync(cartId);
            if (cart != null)
            {
                _dbContext.Carts.Remove(cart);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task<Cart> RemoveShoppingCartItemAsync(int cartId, int itemId)
        {
            var cart = await FindByIdAsync(cartId);
            if (cart == null)
                return null;

            var catalogItem = await _catalogRepository.FindByIdAsync(itemId);
            if (catalogItem == null)
                return null;

            var itemToRemove = cart.Products.FirstOrDefault(x => x.CatalogItemId == itemId);
            if (itemToRemove != null)
            {
                cart.Products.Remove(itemToRemove);
                await _dbContext.SaveChangesAsync();
            }

            return await EnrichCart(cart);
        }


        public async Task<Cart> IncreaseShoppingCartItemAsync(int cartId, int itemId, int quantity)
        {
            var cart = await FindByIdAsync(cartId);
            if (cart == null)
                return null;

            var catalogItem = await _catalogRepository.FindByIdAsync(itemId);
            if (catalogItem == null)
                return null;

            if (cart.Products.Any(x => x.CatalogItemId == itemId))
            {
                var item = cart.Products.First(x => x.CatalogItemId == itemId);
                item.Quantity += quantity;
            }
            else
            {
                cart.Products.Add(new CartItem
                {
                    CartId = cartId,
                    CatalogItemId = itemId,
                    Quantity = quantity
                });
            }

            _dbContext.Attach(cart);
            await _dbContext.SaveChangesAsync();
            return await EnrichCart(cart);
        }


        public async Task<Cart> DecreaseShoppingCartItemAsync(int cartId, int itemId, int quantity)
        {
            var cart = await FindByIdAsync(cartId);
            if (cart == null)
                return null;

            var catalogItem = await _catalogRepository.FindByIdAsync(itemId);
            if (catalogItem == null)
                return null;

            // Do not allow the quantity to go below zero
            // Arguably we should delete it but then makes it more difficult to increase from client
            if (cart.Products.Any(x => x.CatalogItemId == itemId))
            {
                var item = cart.Products.First(x => x.CatalogItemId == itemId);
                item.Quantity -= (quantity > item.Quantity) ? item.Quantity : quantity;               
            }

            // Do not throw error if the item not in the cart
            // Could equally throw a bad request but little benefit
            _dbContext.Attach(cart);
            await _dbContext.SaveChangesAsync();
            return await EnrichCart(cart);
        }


        public override async Task<Cart> FindByIdAsync(int id)
        {
            var cart = await _dbContext
                .Carts
                .Include(e => e.Products)
                .FirstOrDefaultAsync(x => x.Id == id);

            return await EnrichCart(cart);
            //return cart;
        }


        // Look to find a better way - perhaps wrap the cart model with the extended data?
        private async Task<Cart> EnrichCart(Cart cart)
        {
            if (cart == null)
                return null;

            foreach (var item in cart.Products)
            {
                var catalogItem = await _catalogRepository.FindByIdAsync(item.CatalogItemId);
                item.SalesPrice = catalogItem.SalesPrice;
                item.Name = item.Quantity > 1 ? catalogItem.NamePlural : catalogItem.ProductTypeName;
            }

            return cart;
        }



    }
}
