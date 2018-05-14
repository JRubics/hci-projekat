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

namespace WpfApp3.TagTable
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        private static Tag deleteTag = null;
        public Window1()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Tag> l = new List<Tag>( );
            for (int i = 0; i < MainWindow.Tags.Len( ); i++) {
                l.Add(new Tag( ) { Oznaka = MainWindow.Tags.GetTagAtI(i).oznaka, Opis = MainWindow.Tags.GetTagAtI(i).opis, Boja = MainWindow.Tags.GetTagAtI(i).boja });
            }
            Tagovi = new ObservableCollection<Tag>(l);
            tagTable.ItemsSource = Tagovi;
        }
        public ObservableCollection<Tag> Tagovi {
            get;
            set;
        }

        public class Tag
        {
            public string Oznaka { get; set; }
            public string Opis { get; set; }
            public string Boja { get; set; }
        }

        public void RemoveTag(object sender, RoutedEventArgs e)
        {
            String id = deleteTag.Oznaka;

            //dodaj proveru da ne sme da brise ako se igde koristi
            MainWindow.Tags.RemoveTagById(id);
            this.Close( );
            var l = new TagTable.Window1( );
            l.ShowDialog( );
        }

        private void openChange(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null) {
                int i = 0;
                int n = 0;
                foreach (Tag r in Tagovi) {
                    if (item == r) {
                        n = i;
                        break;
                    }
                    i++;
                }
                var x = new NewTag.NewTag(MainWindow.Tags.GetTagAtI(n));
                x.ShowDialog( );
                this.Close( );
                var l = new TagTable.Window1( );
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

        private ICollectionView _View;
        public ICollectionView View {
            get {
                return _View;
            }
            set {
                _View = value;
                OnPropertyChanged("View");
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

        private void OpenDelete(object sender, MouseButtonEventArgs e)
        {
            var tag = (sender as ListView).SelectedItem;
            if (tag != null) {
                foreach (Tag t in Tagovi) {
                    if (tag == t) {
                        deleteTag = t;
                    }
                }
            }

            ContextMenu cm = new ContextMenu( );
            MenuItem item = new MenuItem { Header = "delete", FontSize = 20 };
            item.Click += RemoveTag;
            cm.Items.Add(item);

            var mouseWasDownOn = e.Source as FrameworkElement;

            mouseWasDownOn.ContextMenu = cm;
        }

    }
}
