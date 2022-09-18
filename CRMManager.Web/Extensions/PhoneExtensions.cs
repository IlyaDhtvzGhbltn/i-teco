using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRMManager.Web.Extensions
{
    public static class PhoneExtensions
    {
        private static readonly Regex _phoneNumber = new Regex("\\+\\d-\\d{3}-\\d{3}-\\d{2}-\\d{2}");

        public static bool Validate(this Entities.Phone phone, string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return true;
            }
            else
            {
                return _phoneNumber.IsMatch(number);
            }
        }
    }
}
