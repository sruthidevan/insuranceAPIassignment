using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Models.Dto.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Controllers
{
    [ApiController]
    [Route("api/insurances/")]
    public class InsurancesController : ControllerBase
    {
        public InsurancesController()
        {
        }

        /// <summary>
        /// Calculates and updates the insurance based on business rules on cart contents.
        /// </summary>
        /// <param name="cartContents">The cart data containing products list.</param>
        /// <returns>Updated cart contents with insurance values.</returns>

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(CartResponseDto))]
        public async Task<IActionResult> CalculateInsurance([FromBody] CartContentsRequestDto cartContents)
        {
            var products = new List<CartItemResponseDto>();
            foreach (var item in cartContents.Products)
            {
                var cartItemData = await BusinessRules.GetProductAsync(item.Id, item.Quantity);
                products.Add(cartItemData);
            }

            var hasDigitalCamera = products.Any(p => p.ProductTypeName.Trim().Equals("digital cameras", StringComparison.InvariantCultureIgnoreCase));

            var result = new CartResponseDto
            {
                Products = products
            };

            return Ok(result);
        }

        

        //// GET: api/InsuranceItems
        //[HttpGet]
        //[Route("api/insurance/product")]
        //public async Task<ActionResult<IEnumerable<InsuranceItem>>> GetInsuranceItems()
        //{
        //   return await _context.InsuranceItems.ToListAsync();
        //}

        //// GET: api/InsuranceItems/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<InsuranceDto>> GetInsuranceItem(long id)
        //{
        //   var insuranceItem = await _context.InsuranceItems.FindAsync(id);

        //   if (insuranceItem == null)
        //   {
        //      return NotFound();
        //   }

        //   return ItemInsuranceDto(insuranceItem);
        //}

        //private static InsuranceDto ItemInsuranceDto(InsuranceItem insuranceItem) => new()
        //{
        //   ProductId = insuranceItem.ProductId,
        //   ProductTypeName = insuranceItem.ProductTypeName,
        //   ProductTypeHasInsurance = insuranceItem.ProductTypeHasInsurance
        //};

        //// PUT: api/InsuranceItems/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutInsuranceItem(long id, InsuranceDto insuranceItemDto)
        //{
        //   if (id != insuranceItemDto.ProductId)
        //   {
        //      return BadRequest();
        //   }

        //   var insuranceItem = await _context.InsuranceItems.FindAsync(id);
        //   if (insuranceItem == null)
        //   {
        //      return NotFound();
        //   }

        //   insuranceItem.ProductId = insuranceItemDto.ProductId;
        //   insuranceItem.ProductTypeHasInsurance = insuranceItemDto.ProductTypeHasInsurance;

        //   try
        //   {
        //      await _context.SaveChangesAsync();
        //   }
        //   catch (DbUpdateConcurrencyException) when (!InsuranceItemExists(id))
        //   {
        //      return NotFound();
        //   }

        //   return NoContent();
        //}

        //// POST: api/InsuranceItems
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<InsuranceDto>> CreateInsuranceItem(InsuranceDto insuranceItemDto)
        //{
        //   var insuranceItem = new InsuranceItem
        //   {
        //      ProductId = insuranceItemDto.ProductId,
        //      ProductTypeName = insuranceItemDto.ProductTypeName,
        //      ProductTypeHasInsurance = insuranceItemDto.ProductTypeHasInsurance,
        //      SalesPrice = insuranceItemDto.SalesPrice
        //   };

        //   _context.InsuranceItems.Add(insuranceItem);
        //   await _context.SaveChangesAsync();

        //   //return CreatedAtAction("GetInsuranceItem", new { id = todoItemDTO.ProductId }, todoItemDTO);
        //   return CreatedAtAction(nameof(GetInsuranceItem), new {id = insuranceItem.ProductId}, ItemInsuranceDto(insuranceItem));
        //}

        //// POST: api/InsuranceItems/Order
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("{id}")]
        //public async Task<ActionResult<InsuranceDto>> CreateOrderInsuranceItems(long id, InsuranceDto insuranceItemDto)
        //{
        //   if (id != insuranceItemDto.ProductId)
        //   {
        //      return BadRequest();
        //   }

        //   var insuranceItem = await _context.InsuranceItems.FindAsync(id);
        //   if (insuranceItem == null)
        //   {
        //      return NotFound();
        //   }

        //   insuranceItem.ProductId = insuranceItemDto.ProductId;
        //   insuranceItem.ProductTypeHasInsurance = insuranceItemDto.ProductTypeHasInsurance;

        //   try
        //   {
        //      await _context.SaveChangesAsync();
        //   }
        //   catch (DbUpdateConcurrencyException) when (!InsuranceItemExists(id))
        //   {
        //      return NotFound();
        //   }

        //   return NoContent();

        //   foreach (var product in OrderDto)
        //   {
        //      orderInsuranceDTO.InsuranceValue += CalculateInsurance(insuranceItemDto);
        //   }
        //   return insuranceItemDto;

        //}

        //// DELETE: api/TodoItems/5
        //   [HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTodoItem(long id)
        //{
        //   var todoItem = await _context.InsuranceItems.FindAsync(id);
        //   if (todoItem == null)
        //   {
        //      return NotFound();
        //   }

        //   _context.InsuranceItems.Remove(todoItem);
        //   await _context.SaveChangesAsync();

        //   return NoContent();
        //}

        //private bool InsuranceItemExists(long id)
        //{
        //   return _context.InsuranceItems.Any(e => e.ProductId == id);
        //}

    }
}