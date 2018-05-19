using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp3
{
    [Serializable]
    class ResourceContainer
    {
        public static ObservableCollection<Res> res;

        public void AddTag(Tag t, int i) {
            res.ElementAt(i).etikete.Add(t);
        }

        public ResourceContainer()
        {
            res = new ObservableCollection<Res>();
        }

        public void removeResourceAtI(int i) {
            res.RemoveAt(i);
        }

        public void changeResourceAtI(int i,Res r)
        {
            res[i] = r;
        }

        public void addResource(Res r)
        {
            res.Add(r);
        }
        public Res GetResourceAtI(int i)
        {
            return res.ElementAt(i);
        }
        public Res GetResourceById(String id)
        {
            for(int i = 0; i < res.Count; i++) {
                if(res[i].oznaka == id) {
                    return res[i]; 
                }
            }
            return null;
        }

        public void RemoveResourceById(String id)
        {
            for (int i = 0; i < res.Count; i++) {
                if (res[i].oznaka == id) {
                    res.RemoveAt(i);
                }
            }
        }

        public int Len()
        {
            return res.Count;
        }

        public new String ToString
        {
            get
            {
                String s = "";
                foreach (Res r in res)
                {
                    s += r.oznaka + " " + r.oznaka + " " + r.oznaka + r.tip + " " + r.ikonica + " " + r.frekvencija + " " + r.obnovljiv + " " + r.strateskiVazan + " " + r.eksploatisanje + " " + r.mera + " " + r.cena + " " + r.datum;
                }
                return s;
            }
        }

        internal static ObservableCollection<Res> R { get => res; set => res = value; }

        public void serialize()
        {
            IFormatter formatter = new BinaryFormatter( );
            Stream stream = new FileStream("Save.bin",
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, res);
            stream.Close( );
        }

        public void deserialize()
        {
            try {
                IFormatter formatter = new BinaryFormatter( );
                Stream stream = new FileStream("Save.bin",
                                          FileMode.Open,
                                          FileAccess.Read,
                                          FileShare.Read);
                ObservableCollection<Res> des = (ObservableCollection<Res>)formatter.Deserialize(stream);
                for (int i = 0; i < des.Count; i++) {
                    res.Add(des[i]);
                }
                stream.Close( );
            } catch {
                res = new ObservableCollection<Res>();
            }
        }
    }
}
