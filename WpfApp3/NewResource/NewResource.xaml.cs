﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp3.NewResource
{
    /// <summary>
    /// Interaction logic for NewResource.xaml
    /// </summary>
    public partial class NewResource : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> TipoviCombo { get; set; }
        public ObservableCollection<string> FrekvCombo { get; set; }
        public ObservableCollection<string> MeraCombo { get; set; }
        public ObservableCollection<Item> items { get; set; }
        //public bool ButtonEnabled;

        public String s = "";//mode pozivanja button click-a
        public bool Oznakaenabled = true;
        public static int ErrorCounter = 0;
        public NewResource(Res r,String a) {

            try {
                s = a;
                Oznakaenabled = false;

                InitializeComponent( );
                DataContext = this;
                b_potvrdi.IsEnabled = true;
                tboznaka.IsEnabled = false;

                Ime = r.ime;
                Oznaka = r.oznaka;

                Opis = r.opis;

                TipoviCombo = new ObservableCollection<string>( );
                for (int i = 0; i < MainWindow.Typesc.Len( ); i++) {
                    TipoviCombo.Add(MainWindow.Typesc.GetTypeAtI(i).oznaka);
                }
                Tip = r.tip;

                FrekvCombo = new ObservableCollection<string>( );
                foreach (Frekvencija f in Enum.GetValues(typeof(Frekvencija))) {
                    if (Enum.GetName(typeof(Frekvencija), f) == "END") {
                        break;
                    }
                    FrekvCombo.Add(Enum.GetName(typeof(Frekvencija), f));
                }
                Frekvencija = r.frekvencija;

                Ikonica = r.ikonica;
                IkonicaLabel = r.ikonica;
                Obnovljiv = r.obnovljiv;
                StrateskiVazan = r.strateskiVazan;
                Eksploatisanje = r.eksploatisanje;

                MeraCombo = new ObservableCollection<string>( );
                foreach (Mere m in Enum.GetValues(typeof(Mere))) {
                    if (Enum.GetName(typeof(Mere), m) == "END") {
                        break;
                    }
                    MeraCombo.Add(Enum.GetName(typeof(Mere), m));
                }
                Mera = r.mera;

                Cena = r.cena;
                Datum = r.datum;
                items = new ObservableCollection<Item>( );
                for (int i = 0; i < MainWindow.Tags.Len( ); i++) {
                    Item it = new Item(MainWindow.Tags.GetTagAtI(i).oznaka, (Color)ColorConverter.ConvertFromString(MainWindow.Tags.GetTagAtI(i).boja), MainWindow.Tags.GetTagAtI(i).opis);

                    for (int j = 0; j < r.etikete.Count; j++) {
                        if (r.etikete.ElementAt(j).oznaka == it.TipOzn) {
                            it.IsChacked = true;
                            break;
                        }
                    }
                    items.Add(it);
                }
                if (r.etikete.Count > 0) {
                    EExists = "Etikete:";
                } else {
                    EExists = " ";
                }

                INotifyPropertyChanged win = DataContext as INotifyPropertyChanged;
                if (win != null)
                    win.PropertyChanged += new PropertyChangedEventHandler(validate);
            } catch {
                var s = new messageBox.Window1("Ne možete menjati resurs koji je obrisan");
                s.ShowDialog( );
                return;
            }
        }

        private void validate(object sender, PropertyChangedEventArgs e)
        {
            StringToDoubleValidationRule.validate_all(false);
        }

        public NewResource()
        {
            Oznakaenabled = true;
            s = "";
            InitializeComponent();
            DataContext = this;
            b_potvrdi.IsEnabled = false;

            Ime = "";
            Oznaka = "";
            Opis = "";

            TipoviCombo = new ObservableCollection<string>( );
            for (int i = 0; i < MainWindow.Typesc.Len( ); i++) {
                TipoviCombo.Add(MainWindow.Typesc.GetTypeAtI(i).oznaka);
            }
            Tip = null;
            if (MainWindow.Typesc.Len( ) > 0) {
                Tip = TipoviCombo.First();
            }

            FrekvCombo = new ObservableCollection<string>();
            foreach (Frekvencija f in Enum.GetValues(typeof(Frekvencija)))
            {
                if (Enum.GetName(typeof(Frekvencija), f) == "END")
                {
                    break;
                }
                FrekvCombo.Add(Enum.GetName(typeof(Frekvencija), f));
            }
            Frekvencija = FrekvCombo.First();

            Ikonica = "";
            IkonicaLabel = "Dodajte ikonicu";
            Obnovljiv = false;
            StrateskiVazan = false;
            Eksploatisanje = true;

            MeraCombo = new ObservableCollection<string>();
            foreach (Mere m in Enum.GetValues(typeof(Mere)))
            {
                if (Enum.GetName(typeof(Mere), m) == "END")
                {
                    break;
                }
                MeraCombo.Add(Enum.GetName(typeof(Mere), m));
            }
            Mera = MeraCombo.First();

            Cena = "0";
            Datum = DateTime.Now;

            items = new ObservableCollection<Item>();
            for (int i = 0; i < MainWindow.Tags.Len(); i++) {
                items.Add(new Item(MainWindow.Tags.GetTagAtI(i).oznaka, (Color)ColorConverter.ConvertFromString(MainWindow.Tags.GetTagAtI(i).boja), MainWindow.Tags.GetTagAtI(i).opis));
            }

            if (MainWindow.Tags.Len( ) > 0) {
                EExists = "Etikete:";
            } else {
                EExists = " ";
            }
            INotifyPropertyChanged win = DataContext as INotifyPropertyChanged;
            if (win != null)
                win.PropertyChanged += new PropertyChangedEventHandler(validatenew);
        }

        private void validatenew(object sender, PropertyChangedEventArgs e)
        {
            StringToDoubleValidationRule.validate_all(true);
        }

        public class Item
        {
            public string TipOzn { get; set; }
            public Color TipBoja { get; set; }
            public string TipBackground { get; set; }
            public string TipOpis { get; set; }
            public bool IsChacked { get; set; }
            public Item(string t, Color b,string o) {
                TipOzn = t;
                TipBoja = b;
                TipOpis = o;
                IsChacked = false;
                TipBackground = b.ToString();
            }
        }


        #region NotifyProperties
        private string _test1;
        public string Test1
        {
            get
            {
                return _test1;
            }
            set
            {
                if (value != _test1)
                {
                    _test1 = value;
                    OnPropertyChanged("Test1");
                }
            }
        }

        private string _e_exists;
        public string EExists {
            get {
                return _e_exists;
            }
            set {
                if (value != _e_exists) {
                    _e_exists = value;
                    OnPropertyChanged("EExists");
                }
            }
        }

        private string _tipozn;
        public string TipOzn {
            get {
                return _tipozn;
            }
            set {
                if (value != _tipozn) {
                    _tipozn = value;
                    OnPropertyChanged("TipOzn");
                }
            }
        }

        private string _tipboja;
        public string TipBoja {
            get {
                return _tipboja;
            }
            set {
                if (value != _tipboja) {
                    _tipboja = value;
                    OnPropertyChanged("TipBoja");
                }
            }
        }

        private string _tipopis;
        public string TipOpis {
            get {
                return _tipopis;
            }
            set {
                if (value != _tipopis) {
                    _tipopis = value;
                    OnPropertyChanged("TipOpis");
                }
            }
        }

        private string _ikonica;
        public string Ikonica
        {
            get
            {
                return _ikonica;
            }
            set
            {
                if (value != _ikonica)
                {
                    _ikonica = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        private string _ikonica_label;
        public string IkonicaLabel {
            get {
                return _ikonica_label;
            }
            set {
                if (value != _ikonica_label) {
                    _ikonica_label = value;
                    OnPropertyChanged("IkonicaLabel");
                }
            }
        }

        private DateTime _datum;
        public DateTime Datum
        {
            get
            {
                return _datum;
            }
            set
            {
                if (value != _datum)
                {
                    _datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }

        private string _mera;
        public string Mera
        {
            get
            {
                return _mera;
            }
            set
            {
                if (value != _mera)
                {
                    _mera = value;
                    OnPropertyChanged("Mera");
                }
            }
        }

        private String _cena;
        public String Cena
        {
            get
            {
                return _cena;
            }
            set
            {
                if (value != _cena)
                {
                    _cena = value;
                    OnPropertyChanged("Cena");
                }
            }
        }

        private string _opis;
        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        private Boolean _obnovljiv;
        public Boolean Obnovljiv
        {
            get
            {
                return _obnovljiv;
            }
            set
            {
                if (value != _obnovljiv)
                {
                    _obnovljiv = value;
                    OnPropertyChanged("Obnovljiv");
                }
            }
        }

        private Boolean _str_vazan;
        public Boolean StrateskiVazan
        {
            get
            {
                return _str_vazan;
            }
            set
            {
                if (value != _str_vazan)
                {
                    _str_vazan = value;
                    OnPropertyChanged("StrateskiVazan");
                }
            }
        }

        private Boolean _expl;
        public Boolean Eksploatisanje
        {
            get
            {
                return _expl;
            }
            set
            {
                if (value != _expl)
                {
                    _expl = value;
                    OnPropertyChanged("Eksploatisanje");
                }
            }
        }

        private string _frekvencija;
        public string Frekvencija
        {
            get
            {
                return _frekvencija;
            }
            set
            {
                if (value != _frekvencija)
                {
                    _frekvencija = value;
                    OnPropertyChanged("Frekvencija");
                }
            }
        }

        private string _tip;
        public string Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                if (value != _tip)
                {
                    _tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        private string _ime;
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        private string _oznaka;
        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        private bool _ischacked;
        public bool IsChacked {
            get {
                return _ischacked;
            }
            set {
                if (value != _ischacked) {
                    _ischacked = value;
                    OnPropertyChanged("IsChacked");
                }
            }
        }
        #endregion

        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private void DatePicker_SelectedDateChanged(object sender,
            SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;

            DateTime? date = picker.SelectedDate;
            if (date == null) {
                this.Title = "No date";
            } else {
                this.Title = date.Value.ToShortDateString( );
            }
            Datum = (DateTime)date;
        }

        private bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors and all
            // of its children (that are dependency objects) are error-free.
            return !Validation.GetHasError(obj) &&
            LogicalTreeHelper.GetChildren(obj)
            .OfType<DependencyObject>( )
            .All(IsValid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String TipImg = MainWindow.Typesc.GetTypeById(Tip).ikonica;
            //TipImg = Tip;
            Res r = new Res(Oznaka, Ime,Opis, Tip, TipImg, Frekvencija,Ikonica, Obnovljiv, StrateskiVazan, Eksploatisanje, Mera, Cena, Datum);
            r.etikete.Clear( );
            for (int i = 0; i < items.Count; i++) {
                if (items[i].IsChacked) {
                    r.etikete.Add(MainWindow.Tags.GetTagAtI(i));
                }
            }
            if (s.StartsWith("b") || s.StartsWith("B")) {
                for (int i = 0; i < MainWindow.Resources.Len( ); i++) {
                    if (MainWindow.Resources.GetResourceAtI(i).oznaka == r.oznaka) {
                        MainWindow.Resources.GetResourceAtI(i).ime = r.ime;
                        MainWindow.Resources.GetResourceAtI(i).opis = r.opis;
                        MainWindow.Resources.GetResourceAtI(i).tip = r.tip;
                        MainWindow.Resources.GetResourceAtI(i).tipImg = r.tipImg;
                        MainWindow.Resources.GetResourceAtI(i).frekvencija = r.frekvencija;
                        MainWindow.Resources.GetResourceAtI(i).ikonica = r.ikonica;
                        MainWindow.Resources.GetResourceAtI(i).obnovljiv = r.obnovljiv;
                        MainWindow.Resources.GetResourceAtI(i).strateskiVazan = r.strateskiVazan;
                        MainWindow.Resources.GetResourceAtI(i).eksploatisanje = r.eksploatisanje;
                        MainWindow.Resources.GetResourceAtI(i).mera = r.mera;
                        MainWindow.Resources.GetResourceAtI(i).cena = r.cena;
                        MainWindow.Resources.GetResourceAtI(i).datum = r.datum;
                        MainWindow.Resources.GetResourceAtI(i).etikete = r.etikete;
                        break;
                    }
                }
                MainWindow win = (MainWindow)Application.Current.MainWindow;
                string id = s.Substring(1);
                Res re = MainWindow.Resources.GetResourceById(id);
                System.Windows.Controls.Image newImg = new Image( );
                
                try {
                    newImg.Source = new BitmapImage(new Uri(uriString: @re.ikonica));
                } catch {
                    try {
                        newImg.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, re.tipImg)));
                    } catch {
                        newImg.Source = new BitmapImage(new Uri(@"../../resources/image.png", UriKind.Relative));
                    }
                }
                
                foreach (Button b in win.ResourcePanel.Children) {
                    String pom = (b.Name).Substring(1);
                    if (pom == re.oznaka) {
                        b.Content = newImg;
                    }
                }

                //updare map
                if (win.canvas != null) {
                    foreach (var v in win.canvas.Children) {
                        if (v is Image) {
                            Regex reg = new Regex(@"([a-zA-Z]+)(\d+)");
                            Match result = reg.Match((v as Image).Name);
                            string n = result.Groups[1].Value;

                            if (n.Equals(re.oznaka)) {
                                (v as Image).Source = newImg.Source;
                                ToolTip t = MainWindow.makeTooltip(r);
                                (v as Image).ToolTip = t;
                            }
                        }
                    }
                }
                //end update 

                this.Close( );
            } else if (s.StartsWith("t")) {
                for (int i = 0; i < MainWindow.Resources.Len( ); i++) {
                    if (MainWindow.Resources.GetResourceAtI(i).oznaka == r.oznaka) {
                        MainWindow.Resources.GetResourceAtI(i).ime = r.ime;
                        MainWindow.Resources.GetResourceAtI(i).opis = r.opis;
                        MainWindow.Resources.GetResourceAtI(i).tip = r.tip;
                        MainWindow.Resources.GetResourceAtI(i).tipImg = r.tipImg;
                        MainWindow.Resources.GetResourceAtI(i).frekvencija = r.frekvencija;
                        MainWindow.Resources.GetResourceAtI(i).ikonica = r.ikonica;
                        MainWindow.Resources.GetResourceAtI(i).obnovljiv = r.obnovljiv;
                        MainWindow.Resources.GetResourceAtI(i).strateskiVazan = r.strateskiVazan;
                        MainWindow.Resources.GetResourceAtI(i).eksploatisanje = r.eksploatisanje;
                        MainWindow.Resources.GetResourceAtI(i).mera = r.mera;
                        MainWindow.Resources.GetResourceAtI(i).cena = r.cena;
                        MainWindow.Resources.GetResourceAtI(i).datum = r.datum;
                        MainWindow.Resources.GetResourceAtI(i).etikete = r.etikete;
                        break;
                    }
                }
                MainWindow win = (MainWindow)Application.Current.MainWindow;
                string id = s.Substring(1);
                Res re = MainWindow.Resources.GetResourceById(id);
                System.Windows.Controls.Image newImg = new Image( );

                try {
                    newImg.Source = new BitmapImage(new Uri(uriString: @re.ikonica));
                } catch {
                    try {
                        newImg.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, re.tipImg)));
                    } catch {
                        newImg.Source = new BitmapImage(new Uri(@"../../resources/image.png", UriKind.Relative));
                    }
                }

                foreach (Button b in win.ResourcePanel.Children) {
                    String pom = (b.Name).Substring(1);
                    if (pom == re.oznaka) {
                        b.Content = newImg;
                    }
                }
                if (win.canvas != null) {
                    foreach (var v in win.canvas.Children) {
                        if (v is Image) {
                            Regex reg = new Regex(@"([a-zA-Z]+)(\d+)");
                            Match result = reg.Match((v as Image).Name);
                            string n = result.Groups[1].Value;

                            if (n.Equals(re.oznaka)) {
                                (v as Image).Source = newImg.Source;
                                ToolTip t = MainWindow.makeTooltip(r);
                                (v as Image).ToolTip = t;
                            }
                        }
                    }
                }
                this.Close( );
            } else {
                //items = (List<Tag>)lbTodoList.Items( ); ne updatuje se

                MainWindow.Resources.addResource(r);
                MakeBtn(r);
            }
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

        private void MakeBtn(Res r)
        {
            System.Windows.Controls.Image newImg = new Image( );
            try {
                newImg.Source = new BitmapImage(new Uri(uriString: r.ikonica));
            } catch {
                try {
                    newImg.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, r.tipImg)));
                } catch {
                    newImg.Source = new BitmapImage(new Uri(@"../../resources/image.png", UriKind.Relative));
                }
            }

            System.Windows.Controls.Button newBtn = new Button( );

            newBtn.Content = newImg;
            newBtn.Name = "B" + r.oznaka;
            newBtn.Width = 50;
            newBtn.Height = newBtn.Width;
            newBtn.Background = Brushes.White;

            Thickness margin = newBtn.Margin;
            margin.Left = 15;
            margin.Right = 15;
            margin.Top = 5;
            margin.Bottom = 5;
            newBtn.Margin = margin;

            newBtn.HorizontalAlignment = HorizontalAlignment.Center;

            newBtn.MouseRightButtonUp += MainWindow.ButtonClickDelete;

            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.ResourcePanel.Children.Add(newBtn);

            newBtn.MouseDoubleClick += MainWindow.ButtonClick1;

            ToolTip t = new ToolTip( );
            t.Content = r.oznaka;
            t.FontSize = 22;
            newBtn.ToolTip = t;

            this.Close( );
        }

        private void IzborIkoniceClick(object sender, RoutedEventArgs e)
        {
            //Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog( );
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog( ) == true) {
                Ikonica = openFileDialog.FileName;
                IkonicaLabel = Ikonica;
            }
        }
    }
}
