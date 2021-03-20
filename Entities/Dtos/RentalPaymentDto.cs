using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RentalPaymentDto : IDto
    {
        public Rental Rental { get; set; }
        public Payment Payment { get; set; }
    }
}