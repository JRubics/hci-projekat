using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.NewResource
{
    public partial class Resource
    {
        String oznaka;
        String ime;
        /*String opis;
        Image Tip;
        String Frekvencija;
        Image Ikonica;
        Boolean Obnovljiv;
        Boolean StrateskaVaznost;
        Boolean Eksploatacija;
        String Jedinica;
        Double Cena;
        DateTime DatumOtkrivanja;*/
        public Resource(String o, String i)
        {
            ime = i;
            oznaka = o;
        }
    }
}
