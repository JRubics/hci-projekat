using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp3.NewResource
{
    public class StringToDoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try {
                var s = value as string;
                double r;
                if (double.TryParse(s, out r)) {
                    if (r >= 0) {//da bude pozitivna cena
                        return new ValidationResult(true, null);
                    }
                }
                return new ValidationResult(false, "Nije broj");
            } catch {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}