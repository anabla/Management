using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Econtact.econtactClasses;
using Econtact.ExceptionClass;
using System.Windows.Forms;

namespace Econtact.FactoryClasses
{
    public static class Factory 
    {
         private static Dictionary<string, contactClass> c = 
            new Dictionary<string, contactClass>();

        static Factory()
        {
            try
            {
                //Design pattern:- Lazy loading
                c.Add("Room", new Room());
                c.Add("ConfRoom", new ConfRoom());
                c.Add("RoomEven", new RoomEven());
                c.Add("RoomOdd", new RoomOdd());
            }
            catch(HoteliException ex){
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public static contactClass Create(string TypeCust)
        {
            //Design pattern:- RIP Replace of IFs with Polymorphism
            return c[TypeCust];
        }
    }
}
