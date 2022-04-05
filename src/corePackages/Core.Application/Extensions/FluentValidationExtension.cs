using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Extensions
{
    public static class FluentValidationExtension
    {
        // This method is called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> FirstLetterMustBeUpperCase<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(strToCheck => Char.IsUpper(strToCheck[0])).WithMessage("The first letter is not uppercase");
        }
    }
}
