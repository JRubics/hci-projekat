using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp3.TypeTable
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window,INotifyPropertyChanged
    {
        private static Type deleteType= null;
        public Window1()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Type> l = new List<Type>( );
            for (int i = 0; i < MainWindow.Typesc.Len( ); i++) {
                /*String newImg = "";
                if (MainWindow.Resources.GetResourceAtI(i).ikonica.Equals("")) {
                    newImg = MainWindow.Resources.GetResourceAtI(i).tipImg;
                } else {
                    newImg = MainWindow.Resources.GetResourceAtI(i).ikonica;
                }*/
                l.Add(new Type( ) { Oznaka = MainWindow.Typesc.GetTypeAtI(i).oznaka, Opis = MainWindow.Typesc.GetTypeAtI(i).opis, Ime = MainWindow.Typesc.GetTypeAtI(i).ime, Ikonica = MainWindow.Typesc.GetTypeAtI(i).ikonica });
            }
            Tipovi = new ObservableCollection<Type>(l);
            typeTable.ItemsSource = Tipovi;
        }

        public ObservableCollection<Type> Tipovi {
            get;
            set;
        }

        public class Type
        {
            public string Oznaka { get; set; }
            public string Opis { get; set; }
            public string Ime { get; set; }
            public string Ikonica { get; set; }
        }

        private void openChange(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null) {
                int i = 0;
                int n = 0;
                foreach (Type r in Tipovi) {
                    if (item == r) {
                        n = i;
                        break;
                    }
                    i++;
                }
                var x = new NewType.NewType(MainWindow.Typesc.GetTypeAtI(n));
                x.ShowDialog( );
                this.Close( );
                var l = new TypeTable.Window1( );
                l.ShowDialog( );
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OpenDelete(object sender, MouseButtonEventArgs e)
        {
            var tag = (sender as ListView).SelectedItem;
            if (tag != null) {
                foreach (Type t in Tipovi) {
                    if (tag == t) {
                        deleteType = t;
                    }
                }
            }

            ContextMenu cm = new ContextMenu( );
            MenuItem item = new MenuItem { Header = "delete", FontSize = 20 };
            item.Click += RemoveType;
            item.Icon = new System.Windows.Controls.Image 
                   { 
                       Source = new BitmapImage(new Uri("../../resources/garbage.png", UriKind.Relative)) 
                   };
            cm.Items.Add(item);

            var mouseWasDownOn = e.Source as FrameworkElement;

            mouseWasDownOn.ContextMenu = cm;
        }

        public void RemoveType(object sender, RoutedEventArgs e)
        {
            String id = deleteType.Oznaka;

            //dodaj proveru da ne sme da brise ako se igde koristi
            for(int i = 0; i < MainWindow.Resources.Len(); i++) {
                if (MainWindow.Resources.GetResourceAtI(i).tip.Equals(id)) {
                    var s = new messageBox.Window1("Ne možete obrisati tip koji je u upotrebi");
                    s.ShowDialog( );
                    return;
                }
            }
            MainWindow.Typesc.RemoveTypeById(id);
            this.Close( );
            var l = new TypeTable.Window1( );
            l.ShowDialog( );
        }
    }
}
