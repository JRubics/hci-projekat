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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;
using WpfApp3.NewResource;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Serializable]
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Grid grid = null;
        public Canvas canvas = null;
        public Button movingButton = null;
        private static ResourceContainer resources = new ResourceContainer( );
        private static TypeContainer typesc = new TypeContainer( );
        private static TagContainer tags = new TagContainer( );
        private static Button deleteButton = null;
        private static Panel pom = null;
        public MainWindow()
        {
            //var s = new login.Window1( );
            //s.ShowDialog( );
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

                ToolTip t = new ToolTip();
                t.Content = "oznaka: " + resources.GetResourceAtI(i).oznaka;
                t.FontSize = 22;
                newBtn.ToolTip = t;
                ResourcePanel.Children.Add(newBtn);
            }
            pom = ResourcePanel;
        }

        /*public static void TooltipShow(object sender, RoutedEventArgs e) {
            ToolTip tooltip = new ToolTip { Content = (sender as Button).Name.Substring(1) };
            tooltip.FontSize = 20;
            (sender as Button).ToolTip = tooltip;
            tooltip.IsOpen = true;
        }

        public static void TooltipHide(object sender, RoutedEventArgs e)
        {
            (sender as Button).ClearValue(Button.ToolTipProperty);
        }*/

        public static void ButtonClickDelete(object sender, RoutedEventArgs e)
        {
            deleteButton = sender as Button;

            ContextMenu cm = new ContextMenu( );
            MenuItem item = new MenuItem { Header = "delete" , FontSize = 20};
            item.Click += RemoveButton;
            item.Icon = new System.Windows.Controls.Image 
                   { 
                       Source = new BitmapImage(new Uri("../../resources/garbage.png", UriKind.Relative)) 
                   };

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
            canvas = AfricaGrid;

            Canvas c = this.deserialize_canvas("AfricaGrid.txt");
            if (c == null) {
                return;
            }
            List<UIElement> elements = new List<UIElement>( );
            foreach (var v in c.Children) {
                elements.Add((UIElement)v);
            }
            foreach (UIElement el in elements) {
                if ((el is Image)) {
                    c.Children.Remove(el);
                    canvas.Children.Add(el);
                }
            }
        }
        private void Button_Europe(object sender, RoutedEventArgs e)
        {
            WorldGrid.Visibility = Visibility.Collapsed;
            EuropeGrid.Visibility = Visibility.Visible;
            canvas = EuropeGrid;

            Canvas c = this.deserialize_canvas("EuropeGrid.txt");
            if (c == null) {
                return;
            }
            List<UIElement> elements = new List<UIElement>( );
            foreach (var v in c.Children) {
                elements.Add((UIElement)v);
            }
            foreach (UIElement el in elements) {
                if ((el is Image)) {
                    c.Children.Remove(el);
                    canvas.Children.Add(el);
                }
            }
        }
        private void Button_N_America(object sender, RoutedEventArgs e)
        {
            WorldGrid.Visibility = Visibility.Collapsed;
            NAmericaGrid.Visibility = Visibility.Visible;
            canvas = NAmericaGrid;

            Canvas c = this.deserialize_canvas("NAmericaGrid.txt");
            if (c == null) {
                return;
            }
            List<UIElement> elements = new List<UIElement>( );
            foreach (var v in c.Children) {
                elements.Add((UIElement)v);
            }
            foreach (UIElement el in elements) {
                if ((el is Image)) {
                    c.Children.Remove(el);
                    canvas.Children.Add(el);
                }
            }
        }
        private void Button_S_America(object sender, RoutedEventArgs e)
        {
            WorldGrid.Visibility = Visibility.Collapsed;
            SAmericaGrid.Visibility = Visibility.Visible;
            canvas = SAmericaGrid;

            Canvas c = this.deserialize_canvas("SAmericaGrid.txt");
            if (c == null) {
                return;
            }
            List<UIElement> elements = new List<UIElement>( );
            foreach (var v in c.Children) {
                elements.Add((UIElement)v);
            }
            foreach (UIElement el in elements) {
                if ((el is Image)) {
                    c.Children.Remove(el);
                    canvas.Children.Add(el);
                }
            }
        }
        private void Button_Asia(object sender, RoutedEventArgs e)
        {
            WorldGrid.Visibility = Visibility.Collapsed;
            AsiaGrid.Visibility = Visibility.Visible;
            canvas = AsiaGrid;

            Canvas c = this.deserialize_canvas("AsiaGrid.txt");
            if (c == null) {
                return;
            }
            List<UIElement> elements = new List<UIElement>( );
            foreach (var v in c.Children) {
                elements.Add((UIElement)v);
            }
            foreach (UIElement el in elements) {
                if ((el is Image)) {
                    c.Children.Remove(el);
                    canvas.Children.Add(el);
                }
            }
        }
        private void Button_Oceania(object sender, RoutedEventArgs e)
        {
            WorldGrid.Visibility = Visibility.Collapsed;
            OceaniaGrid.Visibility = Visibility.Visible;
            canvas = OceaniaGrid;

            Canvas c = this.deserialize_canvas("OceaniaGrid.txt");
            if (c == null) {
                return;
            }
            List<UIElement> elements = new List<UIElement>( );
            foreach (var v in c.Children) {
                elements.Add((UIElement)v);
            }
            foreach (UIElement el in elements) {
                if ((el is Image)) {
                    c.Children.Remove(el);
                    canvas.Children.Add(el);
                }
            }
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            canvas.Visibility = Visibility.Collapsed;
            WorldGrid.Visibility = Visibility.Visible;
            serialize_canvas(canvas);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            resources.serialize( );
            typesc.serialize( );
            tags.serialize( );
            System.Windows.Application.Current.Shutdown( );
        }

        private void serialize_canvas(Canvas c)
        {
            string save = XamlWriter.Save(c);

            using (StreamWriter outputFile = new StreamWriter(c.Name+".txt")) {
                    outputFile.Write(save);
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            resources.deserialize( );
            typesc.deserialize( );
            tags.deserialize( );
        }

        private Canvas deserialize_canvas(String path)
        {
            if (File.Exists(path)) {
                string readText = File.ReadAllText(path);

                StringReader stringReader = new StringReader(readText);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                Canvas c = (Canvas)XamlReader.Load(xmlReader);
                return c;
            }
            return null;
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
            MenuItem item7 = new MenuItem { Header = "Pomoć", FontSize = 20 };
            MenuItem item8 = new MenuItem { Header = "O programu", FontSize = 20 };

            item1.Click += Button_Click;
            item2.Click += OpenTable;
            item3.Click += OpenNewType;
            item4.Click += OpenNewTag;
            item5.Click += OpenTagTable;
            item6.Click += OpenTypeTable;
            item7.Click += openHelp;
            item8.Click += OpenAbout;

            item1.Icon = new System.Windows.Controls.Image 
                   { 
                       Source = new BitmapImage(new Uri("../../resources/rounded-add-button.png", UriKind.Relative)) 
                   };
            item2.Icon = new System.Windows.Controls.Image 
                   { 
                       Source = new BitmapImage(new Uri("../../resources/table-grid.png", UriKind.Relative)) 
                   };
            item3.Icon = new System.Windows.Controls.Image 
                   { 
                       Source = new BitmapImage(new Uri("../../resources/rounded-add-button.png", UriKind.Relative)) 
                   };
            item4.Icon = new System.Windows.Controls.Image 
                   { 
                       Source = new BitmapImage(new Uri("../../resources/rounded-add-button.png", UriKind.Relative)) 
                   };
            item5.Icon = new System.Windows.Controls.Image 
                   { 
                       Source = new BitmapImage(new Uri("../../resources/table-grid.png", UriKind.Relative)) 
                   };
            item6.Icon = new System.Windows.Controls.Image 
                   { 
                       Source = new BitmapImage(new Uri("../../resources/table-grid.png", UriKind.Relative)) 
                   };
            item7.Icon = new System.Windows.Controls.Image 
            {
                Source = new BitmapImage(new Uri("../../resources/contract.png", UriKind.Relative))
            };
            item8.Icon = new System.Windows.Controls.Image 
            {
                Source = new BitmapImage(new Uri("../../resources/information.png", UriKind.Relative))
            };

            if (typesc.Len( ) == 0) {
                ToolTip t = new ToolTip( );
                t.Content = "Nije dozvoljeno dodavanje resursa ako ne postoji ni jedan tip";
                t.FontSize = 18;
                item3.ToolTip = t;
                item5.ToolTip = t;
                item4.ToolTip = t;
                item6.ToolTip = t;

                item1.IsEnabled = false;
                item2.IsEnabled = false;
            } else {
                ToolTip t1 = new ToolTip( );
                t1.FontSize = 18;
                t1.Content = "l.ctrl + R";
                item1.ToolTip = t1;

                ToolTip t2 = new ToolTip( );
                t2.FontSize = 18;
                t2.Content = "l.shift + R";
                item2.ToolTip = t2;

                ToolTip t3 = new ToolTip( );
                t3.FontSize = 18;
                t3.Content = "l.ctrl + T";
                item3.ToolTip = t3;

                ToolTip t4 = new ToolTip( );
                t4.FontSize = 18;
                t4.Content = "l.ctrl + N";
                item4.ToolTip = t4;

                ToolTip t5 = new ToolTip( );
                t5.FontSize = 18;
                t5.Content = "l.shift + T";
                item5.ToolTip = t5;

                ToolTip t6 = new ToolTip( );
                t6.FontSize = 18;
                t6.Content = "l.shift + N";
                item6.ToolTip = t6;

                ToolTip t7 = new ToolTip( );
                t7.FontSize = 18;
                t7.Content = "l.shift + N";
                item6.ToolTip = t7;

                ToolTip t8 = new ToolTip( );
                t8.FontSize = 18;
                t8.Content = "l.shift + N";
                item6.ToolTip = t8;
            }

            cm.Items.Add(item1);
            cm.Items.Add(item2);
            cm.Items.Add(new Separator());
            cm.Items.Add(item3);
            cm.Items.Add(item6);
            cm.Items.Add(new Separator( ));
            cm.Items.Add(item4);
            cm.Items.Add(item5);
            cm.Items.Add(new Separator( ));
            cm.Items.Add(item7);
            cm.Items.Add(item8);

            var mouseWasDownOn = e.Source as FrameworkElement;
            mouseWasDownOn.ContextMenu = cm;
            cm.IsOpen = true;
        }

        private void openHelp(object sender, RoutedEventArgs r) {
            System.Diagnostics.Process.Start("help.html");
        }

        private void OpenAbout(object sender, RoutedEventArgs r)
        {
            System.Diagnostics.Process.Start("help.html");
        }

        //DRAG AND DROP

        public Point startPoint;
        private void Resource_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Resource_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            foreach (Button b in ResourcePanel.Children) {
                //nalazi na kojem dugmetu se desio event
                if (mousePos.X >= b.TransformToAncestor(Application.Current.MainWindow).Transform(new Point(0, 0)).X &&
                    mousePos.X <= b.TransformToAncestor(Application.Current.MainWindow).Transform(new Point(0, 0)).X + 50 &&
                    mousePos.Y >= b.TransformToAncestor(Application.Current.MainWindow).Transform(new Point(0, 0)).Y &&
                    mousePos.Y <= b.TransformToAncestor(Application.Current.MainWindow).Transform(new Point(0, 0)).Y + 50
                    ) {
                    if (e.LeftButton == MouseButtonState.Pressed) {
                        DataObject dragData = new DataObject("myFormat", b);
                        DragDrop.DoDragDrop(b, dragData, DragDropEffects.Move);

                        movingButton = b;
                    }
                }
            }
        }
         private static T FindAncestor<T>(DependencyObject current)
                 where T : DependencyObject
         {
             do {
                 if (current is T) {
                     return (T)current;
                 }
                 current = VisualTreeHelper.GetParent(current);
             }
             while (current != null);
             return null;
         }

        private void Image_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source) {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Image_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat")) {
                if (e.Data.GetData("myFormat") is Button) {
                    Button b = e.Data.GetData("myFormat") as Button;
                    Res r;

                    for (int i = 0; i < resources.Len( ); i++) {
                        String pom = (b.Name).Substring(1);
                        if (pom == resources.GetResourceAtI(i).oznaka) {
                            r = resources.GetResourceAtI(i);
                            r.position = e.GetPosition(canvas);

                            Image img = new Image( );
                            try {
                                img.Source = new BitmapImage(new Uri(uriString: @r.ikonica));
                            } catch {
                                try {
                                    img.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, r.tipImg)));
                                } catch {
                                    img.Source = new BitmapImage(new Uri(@"../../resources/image.png", UriKind.Relative));
                                }
                            }

                            img.AllowDrop = false;
                            img.Width = 40;
                            img.Height = 40;
                            //img.Name = r.tip.ToString();

                            ToolTip t = new ToolTip( );
                            StackPanel stack = new StackPanel( );
                            stack.Orientation = Orientation.Vertical;

                            StackPanel stack1 = new StackPanel( );
                            stack1.Orientation = Orientation.Horizontal;
                            stack1.Children.Add(new Label( ) { Content = "Oznaka: " + r.oznaka, FontWeight = FontWeights.Bold, FontSize = 18 });

                            StackPanel stack2 = new StackPanel( );
                            stack2.Orientation = Orientation.Horizontal;
                            stack2.Children.Add(new Label( ) { Content = "Etikete: ", FontWeight = FontWeights.Bold, FontSize = 18 });
                            for (int k = 0; k < r.etikete.Count; k++) {
                                stack2.Children.Add(new Label( ) { Content = r.etikete[k].oznaka, FontWeight = FontWeights.Bold, FontSize = 18, Foreground = boja_etikete(r.etikete[k]) });
                            }
                            if (r.etikete.Count == 0) {
                                stack2 = new StackPanel( );
                                stack2.Orientation = Orientation.Horizontal;
                                stack2.Children.Add(new Label( ) { Content = "Nema etikete", FontWeight = FontWeights.Bold, FontSize = 18 });
                            }
                            stack.Children.Add(stack1);
                            stack.Children.Add(stack2);
                            t.Content = stack;
                            /*String etiketeStr = "etikete: ";
                            for (int j = 0; j < r.etikete.Count; j++) {
                                etiketeStr += r.etikete[j].oznaka + " ";
                            }
                            if (!etiketeStr.Equals("")) {
                                t.Content = etiketeStr;
                            } else {
                                t.Content = "Nema etikete";
                            }*/
                            t.FontSize = 20;
                            img.ToolTip = t;

                            Canvas.SetTop(img, r.position.Y);
                            Canvas.SetLeft(img, r.position.X);
                            canvas.Children.Add(img);

                            Action emptyDelegate = delegate { };
                            canvas.Dispatcher.Invoke(emptyDelegate, DispatcherPriority.Render);
                        }
                    }
                } else if (e.Data.GetData("myFormat") is Image && (e.Data.GetData("myFormat") as Image).ActualHeight <= 100) {
                    Image img = e.Data.GetData("myFormat") as Image;
                    canvas.Children.Remove(img);
                    

                    Point p = e.GetPosition(canvas);
                    Canvas.SetTop(img, p.Y);
                    Canvas.SetLeft(img, p.X);
                    canvas.Children.Add(img);
                }
            }
        }

        private SolidColorBrush boja_etikete(Tag tag)
        {
            SolidColorBrush b;
            if (tag.boja == "crvena") { 
                b = new SolidColorBrush(Colors.Red);
                return b;
            } else if (tag.boja == "zelena") {
                b = new SolidColorBrush(Colors.Green);
                return b;
            } else if (tag.boja == "plava") {
                b = new SolidColorBrush(Colors.Blue);
                return b;
            } else if (tag.boja == "žuta") {
                b = new SolidColorBrush(Colors.Yellow);
                return b;
            } else {
                b = new SolidColorBrush(Colors.Black);
                return b;
            }
        }

        private void ehDrop(object sender, DragEventArgs e)
        {
            throw new NotImplementedException( );
        }

        private void Canvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             startPoint = e.GetPosition(null);
        }

        private void Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(canvas);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
            (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
            Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)) {
                UIElement uIElement = (UIElement)e.OriginalSource;
                double top1 = Canvas.GetTop(uIElement);
                double left1 = Canvas.GetLeft(uIElement);

                if (uIElement is Image ) {
                    if((uIElement as Image).ActualHeight <= 100){
                        DataObject dragData = new DataObject("myFormat", uIElement);
                        DragDrop.DoDragDrop(uIElement, dragData, DragDropEffects.Move);

                        //delete double el
                        UIElement el = null;
                        foreach (UIElement c in canvas.Children) {
                            if (c is Image && (double)c.GetValue(Canvas.TopProperty) == top1 && (double)c.GetValue(Canvas.LeftProperty) == left1) {
                                el = c;
                            }
                        }
                        canvas.Children.Remove(el);
                    }
                }
            }
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            List<UIElement> elements = new List<UIElement>( );
            foreach (var v in canvas.Children) {
                elements.Add((UIElement)v);
            }
            foreach (UIElement el in elements) {
                if (el is Image) {
                    if((el as Image).ActualHeight < 100)
                    canvas.Children.Remove(el);
                }
            }
            if (canvas.Name.Equals("AfricaGrid")) {
                Image img = new Image( );
                img.Source = new BitmapImage(new Uri(@"../../resources/africa.png", UriKind.Relative));
                Canvas.SetTop(img, 0);
                Canvas.SetLeft(img, 150);
                canvas.Children.Add(img);
            }else if (canvas.Name.Equals("EuropeGrid")) {
                Image img = new Image( );
                img.Source = new BitmapImage(new Uri(@"../../resources/europe.png", UriKind.Relative));
                Canvas.SetTop(img, 10);
                Canvas.SetLeft(img, 130);
                canvas.Children.Add(img);
            } else if (canvas.Name.Equals("NAmericaGrid")) {
                Image img = new Image( );
                img.Source = new BitmapImage(new Uri(@"../../resources/north_america.png", UriKind.Relative));
                Canvas.SetTop(img, 10);
                Canvas.SetLeft(img, 135);
                canvas.Children.Add(img);
            } else if (canvas.Name.Equals("SAmericaGrid")) {
                Image img = new Image( );
                img.Source = new BitmapImage(new Uri(@"../../resources/south_america.png", UriKind.Relative));
                Canvas.SetTop(img, 0);
                Canvas.SetLeft(img, 150);
                canvas.Children.Add(img);
            } else if (canvas.Name.Equals("AsiaGrid")) {
                Image img = new Image( );
                img.Source = new BitmapImage(new Uri(@"../../resources/asia.png", UriKind.Relative));
                Canvas.SetTop(img, 0);
                Canvas.SetLeft(img, 150);
                canvas.Children.Add(img);
            } else if (canvas.Name.Equals("OceaniaGrid")) {
                Image img = new Image( );
                img.Source = new BitmapImage(new Uri(@"../../resources/oceania.png", UriKind.Relative));
                Canvas.SetTop(img, 0);
                Canvas.SetLeft(img, 150);
                canvas.Children.Add(img);
            }

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1) {
                //help
                System.Diagnostics.Process.Start("help.html");
            } else if (e.Key == Key.R && Keyboard.IsKeyDown(Key.LeftCtrl)) {
                Button_Click( sender,e);
            } else if (e.Key == Key.R && Keyboard.IsKeyDown(Key.LeftShift)) {
                OpenTable(sender, e);
            } else if (e.Key == Key.T && Keyboard.IsKeyDown(Key.LeftCtrl)) {
                OpenNewType(sender, e);
            } else if (e.Key == Key.T && Keyboard.IsKeyDown(Key.LeftShift)) {
                OpenTypeTable(sender, e);
            } else if (e.Key == Key.N && Keyboard.IsKeyDown(Key.LeftCtrl)) {
                OpenNewTag(sender, e);
            } else if (e.Key == Key.N && Keyboard.IsKeyDown(Key.LeftShift)) {
                OpenTagTable(sender, e);
            } else if (e.Key == Key.O && Keyboard.IsKeyDown(Key.LeftCtrl)) {
                System.Diagnostics.Process.Start("about.html");
            }
        }

        /*private void Button_Find(object sender, RoutedEventArgs e)
        {
            List<UIElement> elements = new List<UIElement>( );
            foreach (UIElement el in canvas.Children) {
                if (el is Image) {
                    Image img = el as Image;
                    String t = GetToolTip(img);
                    if (!t.Equals("as")) {
                        elements.Add(el);
                    }
                }
            }
            foreach (UIElement el in elements) {
                if (el is Image) {
                    if ((el as Image).ActualHeight < 100)
                        canvas.Children.Remove(el);
                }
            }
        }*/
    }
}
