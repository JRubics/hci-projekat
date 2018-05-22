using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp3.NewResource
{
    class ValidationMustBeFilled : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try {
                var s = value as string;
                if (s.Length > 0) {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Popunite");
            } catch {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }   
    }

    class ValidationMustBeFilledAndUnique : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try {
                var s = value as string;
                if (s.Length > 0) {
                    for (int i = 0; i < MainWindow.Resources.Len( ); i++) {
                        if (s.Equals(MainWindow.Resources.GetResourceAtI(i).oznaka)) { //i tip i resurs moraju biti unique
                            return new ValidationResult(false, "Nije unikat");
                        }
                    }
                    for (int i = 0; i < MainWindow.Typesc.Len( ); i++) {
                        if (s.Equals(MainWindow.Typesc.GetTypeAtI(i).oznaka)) { //i tip i resurs moraju biti unique
                            return new ValidationResult(false, "Nije unikat");
                        }
                    }
                    for (int i = 0; i < MainWindow.Tags.Len( ); i++) {
                        if (s.Equals(MainWindow.Tags.GetTagAtI(i).oznaka)) { //i tip i resurs moraju biti unique
                            return new ValidationResult(false, "Nije unikat");
                        }
                    }
                    return new ValidationResult(true, null);
                }
                foreach (Window window in Application.Current.Windows) {
                    if (window.GetType( ) == typeof(NewResource)) {
                        (window as NewResource).b_potvrdi.IsEnabled = false;
                        NewResource.ErrorCounter++;
                    }
                }
                return new ValidationResult(false, "Popunite");
            } catch {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}