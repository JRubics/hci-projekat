using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    [Serializable]
    public class Type
    {
        public String oznaka;
        public String opis;
        public String ime;
        public String ikonica;

        public Type(string oznaka, string ime, string opis, string ikonica)
        {
            this.oznaka = oznaka;
            this.ime = ime;
            this.opis = opis;
            this.ikonica = ikonica;
        }
        public Type() { }
    }
}
