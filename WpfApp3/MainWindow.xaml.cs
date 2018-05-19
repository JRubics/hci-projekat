using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using WpfApp3.NewResource;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Grid grid = null;
        private static ResourceContainer resources = new ResourceContainer( );
        private static TypeContainer typesc = new TypeContainer( );
        private static TagContainer tags = new TagContainer( );
        private static Button deleteButton = null;
        private static Panel pom = null;
        public MainWindow()
        {
            var s = new login.Window1( );
            s.ShowDialog( );
            InitializeComponent( );
            this.DataContext = this;
            //Test1 = "AFRIKA";
            Img1 = "resources/world.png";
            for (int i = 0; i < resources.Len( ); i++) {
                System.Windows.Controls.Image newImg = new Image( );
                try {
                    newImg.Source = new BitmapImage(new Uri(uriString: @resources.GetResourceAtI(i).ikonica));
                } catch {
                    try {
                        newImg.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, resources.GetResourceAtI(i).tipImg)));
                    } catch {
                        newImg.Source = new BitmapImage(new Uri(@"../../resources/image.png", UriKind.Relative));
                    }
                }

                System.Windows.Controls.Button newBtn = new Button( );

                newBtn.Content = newImg;
                newBtn.Name = "b" + resources.GetResourceAtI(i).oznaka;

                Style style = this.FindResource("ResourceBtn") as Style;
                newBtn.Style = style;

                newBtn.MouseDoubleClick += ButtonClick1;
                newBtn.MouseRightButtonUp += ButtonClickDelete;

                ResourcePanel.Children.Add(newBtn);
            }
            pom = ResourcePanel;
        }

        public static void ButtonClickDelete(object sender, RoutedEventArgs e)
        {
            deleteButton = sender as Button;

            ContextMenu cm = new ContextMenu( );
            MenuItem item = new MenuItem { Header = "delete" , FontSize = 20};
            item.Click += RemoveButton;
            cm.Items.Add(item);

            var mouseWasDownOn = e.Source as FrameworkElement;

            mouseWasDownOn.ContextMenu = cm;
        }

        public static void RemoveButton(object sender, RoutedEventArgs e)
        {
            String id = deleteButton.Name;
            id = id.Substring(1);

            MainWindow.resources.RemoveResourceById(id);
            deleteButton.Visibility = Visibility.Collapsed;

            //brisanje
        }

        public static void ButtonClick1(object sender, RoutedEventArgs e) //dugmici
        {
            var mouseWasDownOn = e.Source as FrameworkElement;
            string elementName = "";
            if (mouseWasDownOn != null) {
                elementName = mouseWasDownOn.Name;
            }
            String n = elementName.Substring(1);
            var x = new NewResource.NewResource(resources.GetResourceById(n),((Button)sender).Name);
            x.ShowDialog( );
        }

        #region NotifyProperties
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
        private string _img1;
        public string Img1 {
            get {
                return _img1;
            }
            set {
                if (value != _img1) {
                    _img1 = value;
                    OnPropertyChanged("Img1");
                }
            }
        }

        internal new static ResourceContainer Resources { get => resources; set => resources = value; }
        internal new static TypeContainer Typesc { get => typesc; set => typesc = value; }
        internal new static TagContainer Tags { get => tags; set => tags = value; }
        #endregion

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
            var s = new NewResource.NewResource();
            s.ShowDialog();
        }

        private void OpenTable(object sender, RoutedEventArgs e)
        {
            var s = new Table.Table( );
            s.ShowDialog( );
        }

        private void OpenTypeTable(object sender, RoutedEventArgs e)
        {
            var s = new TypeTable.Window1( );
            s.ShowDialog( );
        }

        private void OpenTagTable(object sender, RoutedEventArgs e)
        {
            var s = new TagTable.Window1( );
            s.ShowDialog( );
        }

        private void OpenNewType(object sender, RoutedEventArgs e)
        {
            var s = new NewType.NewType( );
            s.ShowDialog( );
        }

        private void OpenNewTag(object sender, RoutedEventArgs e)
        {
            var s = new NewTag.NewTag( );
            s.ShowDialog( );
        }

        private void Button_Africa(object sender, RoutedEventArgs e)
        {
            WorldGrid.Visibility = Visibility.Collapsed;
            AfricaGrid.Visibility = Visibility.Visible;
            grid = AfricaGrid;
        }
        private void Button_Europe(object sender, RoutedEventArgs e)
        {
            WorldGrid.Visibility = Visibility.Collapsed;
            EuropeGrid.Visibility = Visibility.Visible;
            grid = EuropeGrid;
        }
        private void Button_N_America(object sender, RoutedEventArgs e)
        {
            WorldGrid.Visibility = Visibility.Collapsed;
            NAmericaGrid.Visibility = Visibility.Visible;
            grid = NAmericaGrid;
        }
        private void Button_S_America(object sender, RoutedEventArgs e)
        {
            WorldGrid.Visibility = Visibility.Collapsed;
            SAmericaGrid.Visibility = Visibility.Visible;
            grid = SAmericaGrid;
        }
        private void Button_Asia(object sender, RoutedEventArgs e)
        {
            WorldGrid.Visibility = Visibility.Collapsed;
            AsiaGrid.Visibility = Visibility.Visible;
            grid = AsiaGrid;
        }
        private void Button_Oceania(object sender, RoutedEventArgs e)
        {
            WorldGrid.Visibility = Visibility.Collapsed;
            OceaniaGrid.Visibility = Visibility.Visible;
            grid = OceaniaGrid;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            grid.Visibility = Visibility.Collapsed;
            WorldGrid.Visibility = Visibility.Visible;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            resources.serialize( );
            typesc.serialize( );
            tags.serialize( );
            System.Windows.Application.Current.Shutdown( );
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            resources.deserialize( );
            typesc.deserialize( );
            tags.deserialize( );
            //Test1 = resources.ToString;
        }

        private void Button_Meni(object sender, RoutedEventArgs e)
        {
            ContextMenu cm = new ContextMenu( );
            MenuItem item1 = new MenuItem { Header = "Novi Resurs", FontSize = 20 };
            MenuItem item2 = new MenuItem { Header = "Tabela resursa", FontSize = 20 };
            MenuItem item3 = new MenuItem { Header = "Novi Tip", FontSize = 20 };
            MenuItem item6 = new MenuItem { Header = "Tabela Tipova", FontSize = 20 };
            MenuItem item4 = new MenuItem { Header = "Nova Etiketa", FontSize = 20 };
            MenuItem item5 = new MenuItem { Header = "Tabela Etiketa", FontSize = 20 };
            item1.Click += Button_Click;
            item2.Click += OpenTable;
            item3.Click += OpenNewType;
            item4.Click += OpenNewTag;
            item5.Click += OpenTagTable;
            item6.Click += OpenTypeTable;
            cm.Items.Add(item1);
            cm.Items.Add(item2);
            cm.Items.Add(item3);
            cm.Items.Add(item6);
            cm.Items.Add(item4);
            cm.Items.Add(item5);
            var mouseWasDownOn = e.Source as FrameworkElement;
            mouseWasDownOn.ContextMenu = cm;
            cm.IsOpen = true;
        }
    }
}
