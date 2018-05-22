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

namespace WpfApp3.messageBox
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        public Window1(String text)
        {
            InitializeComponent( );
            this.DataContext = this;
            String[] s = text.Split(' ');
            Test1 = "";
            Test2 = "";
            for (int i = 0; i < s.Length; i++) {
                if (i < s.Length / 2) {
                    Test1 += s[i] + " ";
                } else {
                    Test2 += s[i] + " ";
                }
            }
        }

        private string _test1;
        public string Test1 {
            get {
                return _test1;
            }
            set {
                if (value != _test1) {
                    _test1 = value;
                    OnPropertyChanged("Test1");
                }
            }
        }

        private string _test2;
        public string Test2 {
            get {
                return _test2;
            }
            set {
                if (value != _test2) {
                    _test2 = value;
                    OnPropertyChanged("Test2");
                }
            }
        }

        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close( );
        }
    }
}
