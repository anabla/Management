using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Econtact.InterfaceClass;
using Econtact.ExceptionClass;

namespace Econtact.AbstractClass
{
    public abstract class Personi
    {
        protected int id { get; set; }
        protected String emri { get; set; }
        protected String mbiemri { get; set; }
        protected int mosha { get; set; }

        public Personi()
        {
            if(id >= 0)
            {
                throw new HoteliException("Id nuk mund te jete negative!");
            }
            if(emri.Length == 0)
            {
                throw new HoteliException("Emri nuk mund te jete i zbrazet!");
            }
            if(mbiemri.Length == 0)
            {
                throw new HoteliException("Mbiemri nuk mund te jete i zbrazet!");
            }
            if(mosha >= 0)
            {
                throw new HoteliException("Mosha nuk mund te jete negative");
            }
            this.id = id;
            this.emri = emri;
            this.mbiemri = mbiemri;
            this.mosha = mosha;
        }

        public abstract String Pozita();
    }
    public class Menaxheri : Personi, Punetoret
    {
        protected Boolean KaPervoje { get; set; }

        public Menaxheri()
        {
            this.KaPervoje = KaPervoje;
        }
        //Metoda qe e ka trashegu nga klasa abstrakte Personi
        public override String Pozita()
        {
            return "Menaxheri";
        }
        //Interface-it Metoda Punetoret
        public Boolean getKaPervoje()
        {
            return true;
        }
    }
    public abstract class Punetori
    {
        protected int id { get; set; }
        protected String emri { get; set; }
        protected String mbiemri { get; set; }
        protected int mosha { get; set; }

        public Punetori()
        {
            if (id >= 0)
            {
                throw new HoteliException("Id nuk mund te jete negative!");
            }
            if (emri.Length == 0)
            {
                throw new HoteliException("Emri nuk mund te jete i zbrazet!");
            }
            if (mbiemri.Length == 0)
            {
                throw new HoteliException("Mbiemri nuk mund te jete i zbrazet!");
            }
            if (mosha >= 0)
            {
                throw new HoteliException("Mosha nuk mund te jete negative");
            }
            this.id = id;
            this.emri = emri;
            this.mbiemri = mbiemri;
            this.mosha = mosha;
        }

        public abstract String Pozita();
        public abstract String KohaEPunes();
        public abstract String RaportonTek();
    }
    public class RecepsionistiDiten : Punetori, Punetoret
    {
        public Boolean KaPervoje { get; set; }

        public RecepsionistiDiten()
        {
            this.KaPervoje = KaPervoje;
        }
        public Boolean getKaPervoje()
        {
            return true;
        }

        public override String Pozita()
        {
            return "Recepsionist";
        }
        public override String KohaEPunes()
        {
            return "Diten";
        }
        public override String RaportonTek()
        {
            return "Menaxheri";
        }
    }
//Trashegon klasen Punetori dhe implementon inter.Punetoret
    public class RecepsionistiNaten : Punetori, Punetoret
    {
        protected Boolean KaPervoje { get; set; }

        public RecepsionistiNaten()
        {
            this.KaPervoje = KaPervoje;
        }
        public Boolean getKaPervoje()
        {
            return true;
        }

        public override String Pozita()
        {
            return "Recepsionist";
        }
        public override String KohaEPunes()
        {
            return "Naten";
        }
        public override String RaportonTek()
        {
            return "Menaxheri";
        }
    }
}
