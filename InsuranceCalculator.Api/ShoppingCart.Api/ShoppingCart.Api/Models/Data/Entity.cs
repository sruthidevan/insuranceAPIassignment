using System;
using System.ComponentModel.DataAnnotations;
using ShoppingCart.Api.Models.Interfaces;

namespace ShoppingCart.Api.Models.Data
{
    public abstract class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
