using System;
using System.ComponentModel.DataAnnotations;
using InsuranceCalculator.Api.Models.Interfaces;

namespace InsuranceCalculator.Api.Models.Data
{
    public abstract class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
