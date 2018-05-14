using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    [Serializable]
    class TypeContainer
    {
        public static ObservableCollection<Type> t;

        public TypeContainer()
        {
            t = new ObservableCollection<Type>( );
        }
        public void removeTypeAtI(int i)
        {
            t.RemoveAt(i);
        }

        public void changeTypeAtI(int i, Type r)
        {
            t[i] = r;
        }

        public void addType(Type r)
        {
            t.Add(r);
        }
        public Type GetTypeAtI(int i)
        {
            return t.ElementAt(i);
        }

        public Type GetTypeByName(String i)
        {
            for(int k = 0; k < t.Count; k++) {
                if (t[k].ime.Equals(i)) {
                    return t[k];
                }
            }
            return null;
        }

        public void RemoveTypeById(String id)
        {
            for (int k = 0; k < t.Count; k++) {
                if (t[k].oznaka.Equals(id)) {
                    t.RemoveAt(k);
                }
            }
        }

        public Type GetTypeById(String id)
        {
            for (int k = 0; k < t.Count; k++) {
                if (t[k].oznaka.Equals(id)) {
                    return t[k];
                }
            }
            return null;
        }

        public int Len()
        {
            return t.Count;
        }

        public new String ToString {
            get {
                String s = "";
                foreach (Type r in t) {
                    s += r.oznaka + " " + r.oznaka + " " + r.oznaka + r.ikonica;
                }
                return s;
            }
        }

        internal static ObservableCollection<Type> T { get => t; set => t = value; }

        public void serialize()
        {
            IFormatter formatter = new BinaryFormatter( );
            Stream stream = new FileStream("SaveType.bin",
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, t);
            stream.Close( );
        }

        public void deserialize()
        {
            try {
                IFormatter formatter = new BinaryFormatter( );
                Stream stream = new FileStream("SaveType.bin",
                                          FileMode.Open,
                                          FileAccess.Read,
                                          FileShare.Read);
                ObservableCollection<Type> des = (ObservableCollection<Type>)formatter.Deserialize(stream);
                for (int i = 0; i < des.Count; i++) {
                    t.Add(des[i]);
                }
                stream.Close( );
            } catch {
                t = new ObservableCollection<Type>( );
            }
        }
    }
}
