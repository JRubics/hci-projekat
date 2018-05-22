using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp3.login
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        public Window1()
        {
            InitializeComponent( );
            this.DataContext = this;
            IsEnabled = false;

            INotifyPropertyChanged person = DataContext as INotifyPropertyChanged;
            if (person != null)
                person.PropertyChanged += new PropertyChangedEventHandler(uname_changed);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _user;
        public string User {
            get {
                return _user;
            }
            set {
                if (value != _user) {
                    _user = value;
                    OnPropertyChanged("User");
                }
            }
        }

        private Boolean _isenabled;
        public Boolean IsEnabled {
            get {
                return _isenabled;
            }
            set {
                if (value != _isenabled) {
                    _isenabled = value;
                    OnPropertyChanged("IsEnabled");
                }
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown( );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "admin" && User == "admin") {
                this.Hide( );
            } else {
                Thickness myThickness = new Thickness(2,2,2,2);

                uname.BorderBrush = Brushes.Red;
                uname.BorderThickness = myThickness;

                //uname.prope += new PropertyChangedEventHandler(uname_changed);

                passwordBox.BorderBrush = Brushes.Red;
                passwordBox.BorderThickness = myThickness;

            }

            
        }
        void uname_changed(object sender, PropertyChangedEventArgs e)
        {
            validate( );
        }

        void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            validate( );
        }

        void validate() {
            Thickness myThickness = new Thickness(1, 1, 1, 1);

            uname.BorderBrush = Brushes.Black;
            uname.BorderThickness = myThickness;

            passwordBox.BorderBrush = Brushes.Black;
            passwordBox.BorderThickness = myThickness;

            if (User != "" && passwordBox.Password != "") {
                b.IsEnabled = true;
            } else {
                b.IsEnabled = false;
            }
        }
    }
}
