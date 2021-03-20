using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class RentalDetailDto : IDto
    {
        //Rental Table
        [Key]
        public int RentalId { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        //Customer Table
        public string CompanyName { get; set; }

        //User Table
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //Brand Table
        public string BrandName { get; set; }

        //Color Table
        public string ColorName { get; set; }

        //Car Table
        public string CarDesctiption { get; set; }

        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
    }
}