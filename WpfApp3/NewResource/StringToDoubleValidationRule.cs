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

        public static void validate_all(bool chackOznaka)
        {
            int counter = 0;
            StringToDoubleValidationRule std = new StringToDoubleValidationRule( );
            ValidationMustBeFilled vmbf = new ValidationMustBeFilled( );
            ValidationMustBeFilledAndUnique uniq = new ValidationMustBeFilledAndUnique( );
            foreach (Window window in Application.Current.Windows) {
                if (window is NewResource) {
                    //return umesto counera da proverava jedno po jedno
                    ValidationResult valid = std.Validate(((NewResource)window).Cena, null);
                    if (!valid.IsValid) {
                        ((NewResource)window).b_potvrdi.IsEnabled = false;
                        ((NewResource)window).cenaErr.Content = valid.ErrorContent;
                        counter++;
                    } else {
                        ((NewResource)window).cenaErr.Content = " ";
                    }

                    valid = vmbf.Validate(((NewResource)window).Oznaka, null);
                    if (!valid.IsValid) {
                        ((NewResource)window).b_potvrdi.IsEnabled = false;
                        ((NewResource)window).oznakaError.Content = valid.ErrorContent;
                        counter++;
                    } else {
                        ((NewResource)window).oznakaError.Content = " ";
                    }

                    valid = uniq.Validate(((NewResource)window).Oznaka, null);
                    if (!valid.IsValid && chackOznaka) {
                        ((NewResource)window).b_potvrdi.IsEnabled = false;
                        ((NewResource)window).oznakaError.Content = valid.ErrorContent;
                        counter++;
                    } else {
                        ((NewResource)window).oznakaError.Content = " ";
                    }

                    valid = vmbf.Validate(((NewResource)window).Ime, null);
                    if (!valid.IsValid) {
                        ((NewResource)window).b_potvrdi.IsEnabled = false;
                        ((NewResource)window).imeErr.Content = valid.ErrorContent;
                        counter++;
                    } else {
                        ((NewResource)window).imeErr.Content = " ";
                    }

                    valid = vmbf.Validate(((NewResource)window).Opis, null);
                    if (!valid.IsValid) {
                        ((NewResource)window).b_potvrdi.IsEnabled = false;
                        ((NewResource)window).opisErr.Content = valid.ErrorContent;
                        counter++;
                    } else {
                        ((NewResource)window).opisErr.Content = " ";
                    }
                    if (counter > 0) {
                        return;
                    }
                    ((NewResource)window).b_potvrdi.IsEnabled = true;
                }else if (window is NewTag.NewTag) {
                    //return umesto counera da proverava jedno po jedno
                    ValidationResult valid = vmbf.Validate(((NewTag.NewTag)window).Oznaka, null);
                    if (!valid.IsValid) {
                        ((NewTag.NewTag)window).b_potvrdi.IsEnabled = false;
                        ((NewTag.NewTag)window).oznakaError.Content = valid.ErrorContent;
                        counter++;
                    } else {
                        ((NewTag.NewTag)window).oznakaError.Content = " ";
                    }

                    valid = uniq.Validate(((NewTag.NewTag)window).Oznaka, null);
                    if (!valid.IsValid && chackOznaka) {
                        ((NewTag.NewTag)window).b_potvrdi.IsEnabled = false;
                        ((NewTag.NewTag)window).oznakaError.Content = valid.ErrorContent;
                        counter++;
                    } else {
                        ((NewTag.NewTag)window).oznakaError.Content = " ";
                    }

                    valid = vmbf.Validate(((NewTag.NewTag)window).Opis, null);
                    if (!valid.IsValid) {
                        ((NewTag.NewTag)window).b_potvrdi.IsEnabled = false;
                        ((NewTag.NewTag)window).opisErr.Content = valid.ErrorContent;
                        counter++;
                    } else {
                        ((NewTag.NewTag)window).opisErr.Content = " ";
                    }
                    if (counter > 0) {
                        return;
                    }
                    ((NewTag.NewTag)window).b_potvrdi.IsEnabled = true;
                }else if (window is NewType.NewType) {
                    //return umesto counera da proverava jedno po jedno
                    ValidationResult valid = vmbf.Validate(((NewType.NewType)window).Oznaka, null);
                    if (!valid.IsValid) {
                        ((NewType.NewType)window).b_potvrdi.IsEnabled = false;
                        ((NewType.NewType)window).oznakaError.Content = valid.ErrorContent;
                        counter++;
                    } else {
                        ((NewType.NewType)window).oznakaError.Content = " ";
                    }

                    valid = uniq.Validate(((NewType.NewType)window).Oznaka, null);
                    if (!valid.IsValid && chackOznaka) {
                        ((NewType.NewType)window).b_potvrdi.IsEnabled = false;
                        ((NewType.NewType)window).oznakaError.Content = valid.ErrorContent;
                        counter++;
                    } else {
                        ((NewType.NewType)window).oznakaError.Content = " ";
                    }

                    valid = vmbf.Validate(((NewType.NewType)window).Ime, null);
                    if (!valid.IsValid) {
                        ((NewType.NewType)window).b_potvrdi.IsEnabled = false;
                        ((NewType.NewType)window).imeErr.Content = valid.ErrorContent;
                        counter++;
                    } else {
                        ((NewType.NewType)window).imeErr.Content = " ";
                    }

                    valid = vmbf.Validate(((NewType.NewType)window).Opis, null);
                    if (!valid.IsValid) {
                        ((NewType.NewType)window).b_potvrdi.IsEnabled = false;
                        ((NewType.NewType)window).opisErr.Content = valid.ErrorContent;
                        counter++;
                    } else {
                        ((NewType.NewType)window).opisErr.Content = " ";
                    }
                    if (counter > 0) {
                        return;
                    }
                    ((NewType.NewType)window).b_potvrdi.IsEnabled = true;
                }
            }
        }
    }
}