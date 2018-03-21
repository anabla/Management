using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtact.AbstractClass
{
    public abstract class Personi
    {
        protected int id { get; set; }
        protected String emri { get; set; }
        protected String mbiemri { get; set; }
        protected int mosha { get; set; }

        Personi()
        {
            id = 0;
            emri = "";
            mbiemri = "";
            mosha = 0;
        }

        protected abstract String Pozita();
        protected abstract Boolean KaPervoje();
    }
    public class Menaxheri
    {
        String Pozita()
        {
            return "Menaxher";
        }
        Boolean KaPervoje()
        {
            return true;
        }
    }
}