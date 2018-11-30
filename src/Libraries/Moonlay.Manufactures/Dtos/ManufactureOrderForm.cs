using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moonlay.Manufactures.Dtos
{
    public class ManufactureOrderForm
    {
        public string Code { get; set; }
        public string UnitId { get; set; }
        public string FlowId { get; set; }
        public string OutputProductId { get; set; }
    }

    public class ManufactureOrderFormValidator : AbstractValidator<ManufactureOrderForm>
    {
        public ManufactureOrderFormValidator()
        {
            RuleFor(p => p.Code).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(p => p.UnitId).NotNull().NotEmpty();
            RuleFor(p => p.FlowId).NotNull().NotEmpty();
        }
    }
}
