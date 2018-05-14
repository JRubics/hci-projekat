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
    class TagContainer
    {
        public static ObservableCollection<Tag> t;

        public TagContainer()
        {
            t = new ObservableCollection<Tag>( );
        }
        public void removeTagAtI(int i)
        {
            t.RemoveAt(i);
        }

        public void changeTagAtI(int i, Tag r)
        {
            t[i] = r;
        }

        public void addTag(Tag r)
        {
            t.Add(r);
        }
        public Tag GetTagAtI(int i)
        {
            return t.ElementAt(i);
        }

        public Tag GetTagById(String id)
        {
            for (int k = 0; k < t.Count; k++) {
                if (t[k].oznaka.Equals(id)) {
                    return t[k];
                }
            }
            return null;
        }

        public void RemoveTagById(String id)
        {
            for (int k = 0; k < t.Count; k++) {
                if (t[k].oznaka.Equals(id)) {
                    t.RemoveAt(k);
                }
            }
        }

        public int Len()
        {
            return t.Count;
        }

        public new String ToString {
            get {
                String s = "";
                foreach (Tag r in t) {
                    s += r.oznaka + " " + r.boja + " ";
                }
                return s;
            }
        }

        internal static ObservableCollection<Tag> T { get => t; set => t = value; }

        public void serialize()
        {
            IFormatter formatter = new BinaryFormatter( );
            Stream stream = new FileStream("SaveTag.bin",
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, t);
            stream.Close( );
        }

        public void deserialize()
        {
            try {
                IFormatter formatter = new BinaryFormatter( );
                Stream stream = new FileStream("SaveTag.bin",
                                          FileMode.Open,
                                          FileAccess.Read,
                                          FileShare.Read);
                ObservableCollection<Tag> des = (ObservableCollection<Tag>)formatter.Deserialize(stream);
                for (int i = 0; i < des.Count; i++) {
                    t.Add(des[i]);
                }
                stream.Close( );
            } catch {
                t = new ObservableCollection<Tag>( );
            }
        }
    }
}
