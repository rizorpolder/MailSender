using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI
{
    class StringLengthValidationRule : ValidationRule
    {
        public int StringLenght { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!(value is string str)) return new ValidationResult(false, "Значение не является строкой");
            if (str.Length < StringLenght) return new ValidationResult(false, $"Длинна строки меньше {StringLenght}");
            return ValidationResult.ValidResult;
        }
    }
}
