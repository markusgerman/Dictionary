using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Userinterface
    {
        public Userinterface()
        {
            while (true)
            {
                Console.Write("Bitte Befehl eingeben: ");

                string befehl = Console.ReadLine();

                if (befehl == "--help")
                {
                    Help();
                }
                if(befehl == "--delete")
                {
                    Delete();
                }
                if(befehl == "--close")
                {
                    Close();
                }
                if(befehl == "--dnshow")
                {
                    Dnshow();
                }
            }
        }
        public void Help()
        {
            Console.WriteLine("Hilfemenü");
            Console.WriteLine("--help : öffnet das Hilfemenü");
            Console.WriteLine("--delete : löscht ein Wort aus allen Wörterlisten");
            Console.WriteLine("--close : schließt das Programm");
            Console.WriteLine("--dnshow : zeigt das aktuelle Wörterbuch");
        }
        public void Delete()
        {
            Console.Write("Bitte das zu löschende Wort eingeben: ");
            string wort = Console.ReadLine();
            Dictionary dic = new Dictionary(wort);
        }
        public void Close()
        {
            Environment.Exit(0);
        }
        public void Dnshow()
        {
            Dictionary dic = new Dictionary();

            foreach(string woerter in dic.Woerterliste)
            {
                Console.WriteLine(woerter);
            }
        }
    }
}
