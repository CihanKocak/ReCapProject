﻿using Business.Abstract;
using Core.Aspects.Autofac.Transaction;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly IPaymentService _paymentService;

        public RentalsController(IRentalService rentalService, IPaymentService paymentService)
        {
            _rentalService = rentalService;
            _paymentService = paymentService;
        }

        [HttpGet("getbyid")]
        public ActionResult GetById(int id)
        {
            var result = _rentalService.Get(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getallrentaldetails")]
        public ActionResult GetAllRentalDetails()
        {
            var result = _rentalService.GetAllRentalDetails();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getallundeliveredrentaldetails")]
        public ActionResult GetAllUndeliveredRentalDetails()
        {
            var result = _rentalService.GetAllUndeliveredRentalDetails();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getalldeliveredrentaldetails")]
        public ActionResult GetAllDeliveredRentalDetails()
        {
            var result = _rentalService.GetAllDeliveredRentalDetails();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("deliverthecar")]
        public ActionResult DeliverTheCar(Rental rental)
        {
            var result = _rentalService.DeliverTheCar(rental);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public ActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        //Test amaçlı
        [HttpPost("paymentadd")]
        //[TransactionAspect]
        public ActionResult PaymentAdd(RentalPaymentDto rentalPaymentDto)
        {
            var paymentResult = _paymentService.ReceivePayment(rentalPaymentDto.Payment);
            if (!paymentResult.Success)
            {
                return BadRequest(paymentResult);
            }
            var result = _rentalService.Add(rentalPaymentDto.Rental);

            if (result.Success)
                return Ok(result);
            else
            {
                throw new System.Exception(result.Message);
                //return BadRequest(result);                    
            }
        }
    }
}
