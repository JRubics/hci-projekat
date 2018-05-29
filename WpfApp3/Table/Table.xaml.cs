using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp3.Table
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Table : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> TipoviCombo { get; set; }
        public static Res deleteResource = null;
        public ObservableCollection<Res> listRes { get; } = new ObservableCollection<Res>( );
        public Table()
        {
            InitializeComponent( );
            this.DataContext = this;
            List<Res> l = new List<Res>( );
            for (int i = 0; i < MainWindow.Resources.Len(); i++) {
                String e = MainWindow.Resources.GetResourceAtI(i).eksploatisanje ? "DA" : "NE";
                String o = MainWindow.Resources.GetResourceAtI(i).obnovljiv ? "DA" : "NE";
                String s = MainWindow.Resources.GetResourceAtI(i).strateskiVazan ? "DA" : "NE";
                String etiketeStr = "";
                for (int j = 0; j < MainWindow.Resources.GetResourceAtI(i).etikete.Count; j++) {
                    etiketeStr += MainWindow.Resources.GetResourceAtI(i).etikete[j].oznaka + " ";
                }
                String newImg = "";
                if (MainWindow.Resources.GetResourceAtI(i).ikonica.Equals("")) {
                    newImg = MainWindow.Resources.GetResourceAtI(i).tipImg;
                } else {
                    newImg = MainWindow.Resources.GetResourceAtI(i).ikonica;
                }
                l.Add(new Res( ) { Ime = MainWindow.Resources.GetResourceAtI(i).ime, Opis = MainWindow.Resources.GetResourceAtI(i).opis, Oznaka = MainWindow.Resources.GetResourceAtI(i).oznaka, Tip = MainWindow.Resources.GetResourceAtI(i).tip, Slika = newImg, Frekvencija = MainWindow.Resources.GetResourceAtI(i).frekvencija, Ikonica= newImg, Obnovljiv = o, Eksploatisanje = e, StrateskiVazan = s, Mera = MainWindow.Resources.GetResourceAtI(i).mera, Cena = MainWindow.Resources.GetResourceAtI(i).cena, Datum = MainWindow.Resources.GetResourceAtI(i).datum, Etikete = etiketeStr });
                listRes.Add(new Res( ) { Ime = MainWindow.Resources.GetResourceAtI(i).ime, Opis = MainWindow.Resources.GetResourceAtI(i).opis, Oznaka = MainWindow.Resources.GetResourceAtI(i).oznaka, Tip = MainWindow.Resources.GetResourceAtI(i).tip, Slika = newImg, Frekvencija = MainWindow.Resources.GetResourceAtI(i).frekvencija, Ikonica = newImg, Obnovljiv = o, Eksploatisanje = e, StrateskiVazan = s, Mera = MainWindow.Resources.GetResourceAtI(i).mera, Cena = MainWindow.Resources.GetResourceAtI(i).cena, Datum = MainWindow.Resources.GetResourceAtI(i).datum, Etikete = etiketeStr });
            }
            Resursi = new ObservableCollection<Res>(l);
            //resourceTable.ItemsSource = Resursi;

            Ime = "";
            Oznaka = "";

            TipoviCombo = new ObservableCollection<string>( );
            TipoviCombo.Add("");
            for (int i = 0; i < MainWindow.Typesc.Len( ); i++) {
                TipoviCombo.Add(MainWindow.Typesc.GetTypeAtI(i).oznaka);
            }
            Tip = TipoviCombo.First( );

            Max = "";
            Min = "";

            INotifyPropertyChanged price = DataContext as INotifyPropertyChanged;
            if (price != null)
                price.PropertyChanged += new PropertyChangedEventHandler(price_changed);
        }

        private void TxtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter( );
        }

        private void Combobox_changed(object sender, SelectionChangedEventArgs e) {
            filter( );
        }

        private void CheckBoxFalse(object sender, RoutedEventArgs e)
        {
            filter( );
            Button_Full(sender,e);
        }

        private void CheckBoxTrue(object sender, RoutedEventArgs e)
        {
            filter( );
        }

        private void filter() {
            if (chack_filter.IsChecked.Equals(true)) {
                double max, min;
                double d;
                if (Max.Equals("")) {
                    max = double.MaxValue;
                } else if (!(double.TryParse(Max, out d))) {
                    return;
                } else {
                    max = d;
                }

                if (Min.Equals("")) {
                    min = double.MinValue;
                } else if (!(double.TryParse(Min, out d))) {
                    return;
                } else {
                    min = d;
                }

                List<Res> l = new List<Res>( );
                listRes.Clear( );
                for (int i = 0; i < MainWindow.Resources.Len( ); i++) {
                    WpfApp3.Res r = MainWindow.Resources.GetResourceAtI(i);

                    String ek = r.eksploatisanje ? "DA" : "NE";
                    String o = r.obnovljiv ? "DA" : "NE";
                    String s = r.strateskiVazan ? "DA" : "NE";

                    Regex match = new Regex(Ime, RegexOptions.IgnoreCase);
                    Match mIme = match.Match(r.ime);

                    match = new Regex(Oznaka, RegexOptions.IgnoreCase);
                    Match mOznaka = match.Match(r.oznaka);

                    String etiketeStr = "";
                    for (int j = 0; j < r.etikete.Count; j++) {
                        etiketeStr += r.etikete[j].oznaka + " ";
                    }
                    Double cena = double.Parse(r.cena);
                    if ((r.ime.StartsWith(Ime) || Ime.Equals("")) &&
                        (r.oznaka.StartsWith(Oznaka) || Oznaka.Equals("")) &&
                        (Tip.Equals("") || Tip.Equals(r.tip)) &&
                        cena <= max && cena >= min) {
                        l.Add(new Res( ) { Ime = r.ime, Opis = r.opis, Oznaka = r.oznaka, Tip = r.tip, Slika = r.tipImg, Frekvencija = r.frekvencija, Ikonica = r.oznaka, Obnovljiv = o, Eksploatisanje = ek, StrateskiVazan = s, Mera = r.mera, Cena = r.cena, Datum = r.datum, Etikete = etiketeStr });
                        listRes.Add(new Res( ) { Ime = r.ime, Opis = r.opis, Oznaka = r.oznaka, Tip = r.tip, Slika = r.tipImg, Frekvencija = r.frekvencija, Ikonica = r.oznaka, Obnovljiv = o, Eksploatisanje = ek, StrateskiVazan = s, Mera = r.mera, Cena = r.cena, Datum = r.datum, Etikete = etiketeStr });
                    }
                }
            }
        }

        public Table(List<Res> l)
        {

            InitializeComponent( );
            this.DataContext = this;
           
            Resursi = new ObservableCollection<Res>(l);
            //resourceTable.ItemsSource = Resursi;
            Ime = "";
            Oznaka = "";

            TipoviCombo = new ObservableCollection<string>( );
            TipoviCombo.Add("");
            for (int i = 0; i < MainWindow.Typesc.Len( ); i++) {
                TipoviCombo.Add(MainWindow.Typesc.GetTypeAtI(i).oznaka);
            }
            Tip = TipoviCombo.First( );

            Max = "";
            Min = "";

            INotifyPropertyChanged price = DataContext as INotifyPropertyChanged;
            if (price != null)
                price.PropertyChanged += new PropertyChangedEventHandler(price_changed);
        }

        void price_changed(object sender, PropertyChangedEventArgs e)
        {
            double d;
            if (!(double.TryParse(Max, out d)) && !Max.Equals("")) {
                Thickness myThickness = new Thickness(2, 2, 2, 2);
                max_box.BorderBrush = Brushes.Red;
                max_box.BorderThickness = myThickness;
            } else {
                Thickness myThickness = new Thickness(1, 1, 1, 1);
                max_box.BorderBrush = Brushes.Black;
                max_box.BorderThickness = myThickness;
            }
            if (!(double.TryParse(Min, out d)) && !Min.Equals("")) {
                Thickness myThickness = new Thickness(2, 2, 2, 2);
                min_box.BorderBrush = Brushes.Red;
                min_box.BorderThickness = myThickness;
            } else {
                Thickness myThickness = new Thickness(1, 1, 1, 1);
                min_box.BorderBrush = Brushes.Black;
                min_box.BorderThickness = myThickness;
            }
        }

        private void OpenDelete(object sender, RoutedEventArgs e)
        {
            var res = (sender as ListView).SelectedItem;
            if (res != null) {
                foreach (Res r in Resursi) {
                    if (res == r) {
                        deleteResource = r;
                    }
                }
            }

            ContextMenu cm = new ContextMenu( );
            MenuItem item = new MenuItem { Header = "delete", FontSize = 20 };
            item.Click += RemoveResource;
            item.Icon = new System.Windows.Controls.Image 
                   { 
                       Source = new BitmapImage(new Uri("../../resources/garbage.png", UriKind.Relative)) 
                   };
            cm.Items.Add(item);

            var mouseWasDownOn = e.Source as FrameworkElement;

            mouseWasDownOn.ContextMenu = cm;
        }

        public void RemoveResource(object sender, RoutedEventArgs e)
        {
            String id = deleteResource.Oznaka;

            MainWindow.Resources.RemoveResourceById(id);
            this.Close( );
            var l = new Table( );
            l.ShowDialog( );

            MainWindow win = (MainWindow)Application.Current.MainWindow;
            foreach (Button b in win.ResourcePanel.Children) {
                String pom = (b.Name).Substring(1);
                if (pom == deleteResource.Oznaka) {
                    b.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void openChange(object sender, RoutedEventArgs e)
        {
            //List<Res> l = new List<Res>( );
            var item = (sender as DataGrid).SelectedItem;
            if (item != null) {
                int i = 0;
                int n = 0;
                foreach(Res r in Resursi) {
                    if (item == r) {
                        n = i;
                        break;
                    }
                    i++;
                }
                var x = new NewResource.NewResource(MainWindow.Resources.GetResourceAtI(n),"t"+ MainWindow.Resources.GetResourceAtI(i).oznaka);
                x.ShowDialog( );
               /*this.Close( );
                var l = new Table( );
                l.ShowDialog( );*/
            }
        }

        public class Res
        {
            public string Ime { get; set; }
            public string Opis { get; set; }
            public string Oznaka { get; set; }
            public string Tip { get; set; }
            public string Slika { get; set; }
            public string Frekvencija { get; set; }
            public string Ikonica { get; set; }
            public string Obnovljiv { get; set; }
            public string Eksploatisanje { get; set; }
            public string StrateskiVazan { get; set; }
            public string Mera { get; set; }
            public string Cena { get; set; }
            public DateTime Datum { get; set; }
            public string Etikete { get; set; }

        }


        public ObservableCollection<Res> Resursi {
            get;
            set;
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

        #region NotifyProperties
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

        private string _max;
        public string Max {
            get {
                return _max;
            }
            set {
                _max = value;
                OnPropertyChanged("Max");
            }
        }

        private string _min;
        public string Min {
            get {
                return _min;
            }
            set {
                _min = value;
                OnPropertyChanged("Min");
            }
        }

        private string _tip;
        public string Tip {
            get {
                return _tip;
            }
            set {
                if (value != _tip) {
                    _tip = value;
                    OnPropertyChanged("Tip");
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
        #endregion

        private string _ime;
        public string Ime {
            get {
                return _ime;
            }
            set {
                if (value != _ime) {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        private string _oznaka;
        public string Oznaka {
            get {
                return _oznaka;
            }
            set {
                if (value != _oznaka) {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        private string _etikete;
        public string Etikete {
            get {
                return _etikete;
            }
            set {
                if (value != _etikete) {
                    _etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //System.Windows.Application.Current.Shutdown( );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double max, min;
            double d;
            if (Max.Equals("")) {
                max = double.MaxValue;
            }else if (!(double.TryParse(Max, out d))) {
                return;
            } else {
                max = d;
            }

            if (Min.Equals("")) {
                min = double.MinValue;
            } else if (!(double.TryParse(Min, out d))) {
                return;
            } else {
                min = d;
            }

            List<Res> l = new List<Res>( );
            listRes.Clear( );
            for (int i = 0; i < MainWindow.Resources.Len( ); i++) {
                WpfApp3.Res r = MainWindow.Resources.GetResourceAtI(i);

                String ek = r.eksploatisanje ? "DA" : "NE";
                String o = r.obnovljiv ? "DA" : "NE";
                String s = r.strateskiVazan ? "DA" : "NE";

                Regex match = new Regex(Ime, RegexOptions.IgnoreCase);
                Match mIme = match.Match(r.ime);

                match = new Regex(Oznaka, RegexOptions.IgnoreCase);
                Match mOznaka= match.Match(r.oznaka);

                String etiketeStr = "";
                for (int j = 0; j < r.etikete.Count; j++) {
                    etiketeStr += r.etikete[j].oznaka + " ";
                }
                Double cena = double.Parse(r.cena);
                if (((mIme.Success && mIme.Value.Length == r.ime.Length) || Ime.Equals("")) && 
                    ((mOznaka.Success && mOznaka.Value.Length == r.oznaka.Length) || Oznaka.Equals("")) &&
                    (Tip.Equals("") || Tip.Equals(r.tip)) &&
                    cena <= max && cena >= min) {
                    l.Add(new Res( ) { Ime = r.ime, Opis = r.opis, Oznaka = r.oznaka, Tip = r.tip, Slika = r.tipImg, Frekvencija = r.frekvencija, Ikonica = r.oznaka, Obnovljiv = o, Eksploatisanje = ek, StrateskiVazan = s, Mera = r.mera, Cena = r.cena, Datum = r.datum, Etikete = etiketeStr });
                    listRes.Add(new Res( ) { Ime = r.ime, Opis = r.opis, Oznaka = r.oznaka, Tip = r.tip, Slika = r.tipImg, Frekvencija = r.frekvencija, Ikonica = r.oznaka, Obnovljiv = o, Eksploatisanje = ek, StrateskiVazan = s, Mera = r.mera, Cena = r.cena, Datum = r.datum, Etikete = etiketeStr });
                }
            }
            /*this.Close( );
            var tablefil = new Table(l);
            tablefil.ShowDialog( );*/
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Full(object sender, RoutedEventArgs e)
        {
            listRes.Clear( );
            List<Res> l = new List<Res>( );
            for (int i = 0; i < MainWindow.Resources.Len( ); i++) {
                String e1 = MainWindow.Resources.GetResourceAtI(i).eksploatisanje ? "DA" : "NE";
                String o = MainWindow.Resources.GetResourceAtI(i).obnovljiv ? "DA" : "NE";
                String s = MainWindow.Resources.GetResourceAtI(i).strateskiVazan ? "DA" : "NE";
                String etiketeStr = "";
                for (int j = 0; j < MainWindow.Resources.GetResourceAtI(i).etikete.Count; j++) {
                    etiketeStr += MainWindow.Resources.GetResourceAtI(i).etikete[j].oznaka + " ";
                }
                String newImg = "";
                if (MainWindow.Resources.GetResourceAtI(i).ikonica.Equals("")) {
                    newImg = MainWindow.Resources.GetResourceAtI(i).tipImg;
                } else {
                    newImg = MainWindow.Resources.GetResourceAtI(i).ikonica;
                }
                l.Add(new Res( ) { Ime = MainWindow.Resources.GetResourceAtI(i).ime, Opis = MainWindow.Resources.GetResourceAtI(i).opis, Oznaka = MainWindow.Resources.GetResourceAtI(i).oznaka, Tip = MainWindow.Resources.GetResourceAtI(i).tip, Slika = newImg, Frekvencija = MainWindow.Resources.GetResourceAtI(i).frekvencija, Ikonica = newImg, Obnovljiv = o, Eksploatisanje = e1, StrateskiVazan = s, Mera = MainWindow.Resources.GetResourceAtI(i).mera, Cena = MainWindow.Resources.GetResourceAtI(i).cena, Datum = MainWindow.Resources.GetResourceAtI(i).datum, Etikete = etiketeStr });
                listRes.Add(new Res( ) { Ime = MainWindow.Resources.GetResourceAtI(i).ime, Opis = MainWindow.Resources.GetResourceAtI(i).opis, Oznaka = MainWindow.Resources.GetResourceAtI(i).oznaka, Tip = MainWindow.Resources.GetResourceAtI(i).tip, Slika = newImg, Frekvencija = MainWindow.Resources.GetResourceAtI(i).frekvencija, Ikonica = newImg, Obnovljiv = o, Eksploatisanje = e1, StrateskiVazan = s, Mera = MainWindow.Resources.GetResourceAtI(i).mera, Cena = MainWindow.Resources.GetResourceAtI(i).cena, Datum = MainWindow.Resources.GetResourceAtI(i).datum, Etikete = etiketeStr });
            }

            Ime = "";
            Oznaka = "";
            Min = "";
            Max = "";
            Tip = "";
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1) {
                //help
                System.Diagnostics.Process.Start("help.html");
            } else if (e.Key == Key.P && Keyboard.IsKeyDown(Key.LeftCtrl)) {
                Button_Click(sender, e);
            } else if (e.Key == Key.C && Keyboard.IsKeyDown(Key.LeftCtrl)) {
                Button_Full(sender, e);
            }
        }
    }
}
