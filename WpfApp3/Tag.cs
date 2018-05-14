using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp3
{
    [Serializable]
    public class Tag
    {
        public String oznaka;
        public String opis;
        public String boja;

        public Tag(string oznaka, string opis, string boja)
        {
            this.oznaka = oznaka;
            this.opis = opis;
            this.boja = boja;
        }
        public Tag() { }
    }
}
