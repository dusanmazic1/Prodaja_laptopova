using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prodaja_laptopova
{
    [Serializable]
    public class Laptop
    {

        public int garancija { get; set; }
        public string naziv { get; set; }
        public string model { get; set; }

        public DateTime vreme { get; set; }
        public string img { get; set; }
        public Laptop()
        {

        }

        public Laptop(string n, string m, int g, DateTime v, string i)
        {
            naziv = n;
            model = m;
            garancija = g;
            vreme = v;
            img = i;
        }
    }
}
