using Microsoft.Win32;
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

namespace WpfApp3.NewTag
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class NewTag : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> BojaCombo { get; set; }
        public static string s = "";
        public bool Oznakaenabled = true;
        public NewTag(Tag t)
        {
            s = "c";
            Oznakaenabled = false;

            InitializeComponent( );
            DataContext = this;
            tbozn.IsEnabled = false;

            Oznaka = t.oznaka;
            Opis = t.opis;

            BojaCombo = new ObservableCollection<string>( );
            foreach (Boje b in Enum.GetValues(typeof(Boje))) {
                if (Enum.GetName(typeof(Boje), b) == "END") {
                    break;
                }
                BojaCombo.Add(Enum.GetName(typeof(Boje), b));
            }
            Boja = t.boja;
        }

        public NewTag()
        {
            s = "";
            Oznakaenabled = true;

            InitializeComponent( );
            DataContext = this;
            Oznaka = "";
            Opis = "";

            BojaCombo = new ObservableCollection<string>( );
            foreach (Boje b in Enum.GetValues(typeof(Boje))) {
                if (Enum.GetName(typeof(Boje), b) == "END") {
                    break;
                }
                BojaCombo.Add(Enum.GetName(typeof(Boje), b));
            }
            Boja = BojaCombo.First( );
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

        private string _boja;
        public string Boja {
            get {
                return _boja;
            }
            set {
                if (value != _boja) {
                    _boja = value;
                    OnPropertyChanged("Boja");
                }
            }
        }
        //#endregion

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
                if (Oznaka.Equals(" ") || Opis.Equals("") || unique) {
                    var s = new messageBox.Window1("Popunite sva polja prema zahtevima");
                    s.ShowDialog( );
                    return;
                }
            }
            Tag t = new Tag(Oznaka, Opis, Boja);
            if (s.Equals("c")) {
                Tag tt = MainWindow.Tags.GetTagById(Oznaka);
                tt.boja = t.boja;
                tt.opis = t.opis;
                /*for (int i = 0; i < MainWindow.Tags.Len( ); i++) {
                    if (MainWindow.Tags.GetTagAtI(i).oznaka == t.oznaka) {
                        MainWindow.Tags.GetTagAtI(i).opis = t.opis;
                        MainWindow.Tags.GetTagAtI(i).boja = t.boja;
                        break;
                    }
                }*/
            } else {
                MainWindow.Tags.addTag(t);
            }
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            for (int i = 0; i < MainWindow.Tags.Len( ); i++) {
                win.Test1 += MainWindow.Tags.GetTagAtI(i).oznaka + " "+  MainWindow.Tags.GetTagAtI(i).boja;
            }
            this.Close( );
        }
    }
}
