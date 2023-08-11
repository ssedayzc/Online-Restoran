using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class HeadingValidator : AbstractValidator<Items>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.ItemName).NotEmpty().WithMessage("Menü Adı Alanı Boş Geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat Alanı Boş geçilemez");
            RuleFor(x => x.ItemId).NotEmpty().WithMessage("ID Adı Alanı Boş Geçilemez");


        }
    }
}
