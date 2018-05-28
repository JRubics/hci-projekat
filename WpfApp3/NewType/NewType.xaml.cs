using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp3.NewResource;

namespace WpfApp3.NewType 
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class NewType : Window, INotifyPropertyChanged
    {
        public static string s = "";
        public bool Oznakaenabled = true;
        public NewType()
        {
            s = "";
            Oznakaenabled = true;
            InitializeComponent( );
            DataContext = this;
            Ime = "";
            Oznaka = "";
            Opis = "";
            Ikonica = "";
            IkonicaLabel = "Dodajte ikonicu";
            INotifyPropertyChanged win = DataContext as INotifyPropertyChanged;
            if (win != null)
                win.PropertyChanged += new PropertyChangedEventHandler(validatenew);
        }
        private void validatenew(object sender, PropertyChangedEventArgs e)
        {
            StringToDoubleValidationRule.validate_all(true);
        }

        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public NewType(Type t)
        {
            s = "c";
            Oznakaenabled = false;
            InitializeComponent( );
            DataContext = this;
            tbozn.IsEnabled = false;
            Ime = t.ime;
            Oznaka = t.oznaka;
            Opis = t.opis;
            Ikonica = t.ikonica;
            IkonicaLabel = t.ikonica;
            INotifyPropertyChanged win = DataContext as INotifyPropertyChanged;
            if (win != null)
                win.PropertyChanged += new PropertyChangedEventHandler(validate);
        }
        private void validate(object sender, PropertyChangedEventArgs e)
        {
            StringToDoubleValidationRule.validate_all(false);
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
        private string _ikonica;
        public string Ikonica {
            get {
                return _ikonica;
            }
            set {
                if (value != _ikonica) {
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

        private string _opis;
        public string Opis {
            get {
                return _opis;
            }
            set {
                if (value != _opis) {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

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
        #endregion

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool unique = false;
            if (Oznakaenabled) {
                for (int i = 0; i < MainWindow.Typesc.Len( ); i++) {
                    if (Oznaka.Equals(MainWindow.Typesc.GetTypeAtI(i).oznaka) || Oznaka.Equals("")) {
                        unique = true;//greska
                    }
                }
                for (int i = 0; i < MainWindow.Resources.Len( ); i++) {
                    if (Oznaka.Equals(MainWindow.Resources.GetResourceAtI(i).oznaka) || Oznaka.Equals("")) {
                        unique = true;//greska
                    }
                }
                for (int i = 0; i < MainWindow.Tags.Len( ); i++) {
                    if (Oznaka.Equals(MainWindow.Tags.GetTagAtI(i).oznaka) || Oznaka.Equals("")) {
                        unique = true;//greska
                    }
                }
                if (Oznaka.Equals(" ") || Ime.Equals(" ") || Opis.Equals("") || unique) {
                    var s = new messageBox.Window1("Popunite sva polja prema zahtevima");
                    s.ShowDialog( );
                    return;
                }
            }
            Type t = new Type(Oznaka, Ime, Opis, Ikonica);
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            /*for (int i = 0; i < MainWindow.Typesc.Len( ); i++) {
                win.Test1 += MainWindow.Typesc.GetTypeAtI(i).ime + " "+  MainWindow.Typesc.GetTypeAtI(i).ikonica;
            }*/
            if (s.Equals("c")) {
                Type tt = MainWindow.Typesc.GetTypeById(Oznaka);
                tt.opis = t.opis;
                tt.ime = t.ime;
                tt.ikonica = t.ikonica;
                
                //menja sliku na dugnemu
                for(int i = 0; i < MainWindow.Resources.Len(); i++) {
                    if(MainWindow.Resources.GetResourceAtI(i).tip == tt.oznaka) {
                        Res re = MainWindow.Resources.GetResourceAtI(i);
                        System.Windows.Controls.Image newImg = new Image( );
                        re.tipImg = tt.ikonica;
                        try {
                            newImg.Source = new BitmapImage(new Uri(uriString: @re.ikonica));
                        } catch {
                            try {
                                newImg.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, re.tipImg)));
                            } catch {
                                newImg.Source = new BitmapImage(new Uri(@"../../resources/image.png", UriKind.Relative));
                            }
                        }

                        foreach (Button b in win.ResourcePanel.Children) {//zasto ovo ne radi :O
                            String pom = (b.Name).Substring(1);
                            if (pom == re.oznaka) {
                                b.Content = newImg;
                            }
                        }
                    }
                }
            } else {
                MainWindow.Typesc.addType(t);
            }
            this.Close( );
        }
    }
}
