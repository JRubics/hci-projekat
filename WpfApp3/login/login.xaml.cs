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

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown( );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "admin" && User == "admin") {
                this.Hide( );
            }
        }
    }
}
