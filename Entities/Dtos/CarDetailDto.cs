using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        [Key]
        public int CarId { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}