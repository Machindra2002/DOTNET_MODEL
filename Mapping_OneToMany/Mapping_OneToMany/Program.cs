using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping_OneToMany
{
    internal class Program
    {
        ADOEntities db;

        public Program()
        {
            db = new ADOEntities(); 
        }

        public void AddStateCity()
        {
            List<tblcity> lst = new List<tblcity>();
            lst.Add(new tblcity() { city_name="Pune" });
            lst.Add(new tblcity() { city_name = "Mumbai" });
            lst.Add(new tblcity() { city_name = "Nashik" });

            tblstate state = new tblstate() { state_name = "Maharashtra", tblcities = lst };
            db.tblstates.Add(state);
            db.SaveChanges();
            Console.WriteLine("StateCity added successfully");

        }

        public void AddStateCityByUserInput()
        {
            List<tblcity> lst = new List<tblcity>();
            Console.WriteLine("Enter State");
            string sname = Console.ReadLine();
            int i = 1;
            while (i != 0)
            {
                Console.WriteLine("Enter City");
                string cname = Console.ReadLine();
                tblcity ct = new tblcity() { city_name = cname };
                lst.Add(ct);
                Console.WriteLine("Do You Want To Add More City? Yes(1)/No(0)");
                i = Convert.ToInt32(Console.ReadLine());
            }
            tblstate st = new tblstate() { state_name = sname, tblcities = lst };
            db.tblstates.Add(st);
            db.SaveChanges();
            Console.WriteLine("Record added successfully");
        }

        public void getStateCity()
        {
            List<tblstate> state = db.tblstates.ToList();
            foreach(tblstate s in  state)
            {
                Console.WriteLine(s.state_id + " "+s.state_name);
                foreach(tblcity c in s.tblcities)
                {
                    Console.WriteLine("\t"+c.city_name);
                }
                Console.WriteLine("-------------------------------------");
            }

        }

        

        static void Main(string[] args)
        {
            Program p = new Program();
            //p.AddStateCity();
            //p.AddStateCityByUserInput();
            //p.getStateCity();
            Console.ReadLine();
        }
    }
}
