﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    [Serializable]
    public class Res
    {
        public String oznaka;
        public String opis;
        public String ime;
        public String tip;
        public String tipImg;
        public String frekvencija;
        public String ikonica;
        public Boolean obnovljiv;
        public Boolean strateskiVazan;
        public Boolean eksploatisanje;
        public String mera;
        public Double cena;
        public DateTime datum;

        public Res() { }

        public Res(string oznaka, string ime, string opis, string tip, string tipImg, string frekvencija, string ikonica, bool obnovljiv, bool strateskiVazan, bool eksploatisanje, string mera, double cena, DateTime datum)
        {
            this.oznaka = oznaka;
            this.ime = ime;
            this.opis = opis;
            this.tip = tip;
            this.tipImg = tipImg;
            this.frekvencija = frekvencija;
            this.ikonica = ikonica;
            this.obnovljiv = obnovljiv;
            this.strateskiVazan = strateskiVazan;
            this.eksploatisanje = eksploatisanje;
            this.mera = mera;
            this.cena = cena;
            this.datum = datum;
        }
    }
}
