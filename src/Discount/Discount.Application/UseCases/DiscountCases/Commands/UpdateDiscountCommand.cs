﻿using Discount.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.DiscountCases.Commands
{
    public class UpdateDiscountCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string CouponCode { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
