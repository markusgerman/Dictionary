using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dictionary
{
    class Dictionary
    {
        private string Master { get; set; }
        private string Word { get; set; }
        private string FireFox { get; set; }
        private string Edge { get; set; }

        public List<string> Woerterliste = new List<string>();

        /// <summary>
        /// Ließt alle properties in der xml ein und weißt diese den Klassenvariablen zu.
        /// Außerdem ruft es die Standardmethoden auf.
        /// </summary>
        public Dictionary()
        {
            this.Master = Properties.Settings.Default.master;
            this.Word = Properties.Settings.Default.word;
            this.FireFox = Properties.Settings.Default.firefox;
            this.Edge = Properties.Settings.Default.edge;

            ReadtxtToList();
            Woerterliste.Sort();
            DeleteDups();
            Ignore();
            ListToTxts();
        }

        /// <summary>
        /// Bei übergabe eines Parameters, wird das übergebe Wort aus der Liste gelöscht
        /// </summary>
        /// <param name="Wort"></param>
        public Dictionary(string Wort)
        {
            this.Master = Properties.Settings.Default.master;
            this.Word = Properties.Settings.Default.word;
            this.FireFox = Properties.Settings.Default.firefox;
            this.Edge = Properties.Settings.Default.edge;

            ReadtxtToList();
            Woerterliste.Sort();

            DeleteDups();
            DeleteWord(Wort);
            Ignore();
            ListToTxts();
        }

        /// <summary>
        /// Ruft die ReadtxtToList mit Parametern auf
        /// </summary>
        public void ReadtxtToList()
        {
            ReadtxtToList(this.Edge);
            ReadtxtToList(this.Word);
            ReadtxtToList(this.FireFox);
            ReadtxtToList(this.Master);
        }

        /// <summary>
        /// Ließt alle .txts und schreibt diese in die Liste
        /// </summary>
        /// <param name="path"></param>
        private void ReadtxtToList(string path)
        {
            
            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Woerterliste.Add(line);
                }
            }

        }

        /// <summary>
        /// Ruft die  ListToTxts mit Parametern auf
        /// </summary>
        public void ListToTxts()
        {
            ListToTxts(this.Master);
            ListToTxts(this.Word);
            ListToTxts(this.FireFox);
            ListToTxts(this.Edge);
        }
        /// <summary>
        /// Schreibt die Liste in die .txts
        /// </summary>
        /// <param name="path"></param>
        private void ListToTxts(string path)
        {
            using (TextWriter tw = new StreamWriter(path))
            {
                foreach(string c in Woerterliste)
                {
                    tw.WriteLine(c);
                }
            }
        }

        /// <summary>
        /// Löscht alle Duplikate, die in der Liste sind.
        /// </summary>
        public void DeleteDups()
        {
            Woerterliste = Woerterliste.Distinct().ToList();
            
            //Löscht leere Einträge
            Woerterliste.Remove("");
        }

        /// <summary>
        /// Löscht das übergebene Wort aus der List
        /// </summary>
        /// <param name="wort"></param>
        public void DeleteWord(string wort)
        {
            foreach(string c in Woerterliste)
            {
                if(c == wort)
                {
                    Woerterliste.Remove(wort);
                    Console.WriteLine("Das Wort wurde erfolgreich gelöscht!");
                    break;
                }
            }
        }

        /// <summary>
        /// Fügt das übergebe Wort in die Liste hinzu.
        /// </summary>
        /// <param name="wort"></param>
        public void AddWord(string wort)
        {
            Woerterliste.Add(wort);
            DeleteDups();
            Woerterliste.Sort();

            Console.WriteLine("Wort wurde erfolgreich hinzugefügt!");
        }

        /// <summary>
        /// Zeigt alle Einträge in dem Wörterbuch
        /// </summary>
        public void DNshow()
        {
            foreach(string c in Woerterliste)
            {
                Console.WriteLine(c);
            }
        }

        /// <summary>
        /// Gibt ein Hilfemenü aus.
        /// </summary>
        public void Help()
        {
            Console.WriteLine("Hilfemenü:");
            Console.WriteLine("--help : öffnet das Hilfemenü");
            Console.WriteLine("--delete [wort] : löscht ein Wort aus allen Wörterlisten");
            Console.WriteLine("--dnshow : zeigt das aktuelle Wörterbuch");
            Console.WriteLine("--add [wort] : fügt ein Wort hinzu");
        }

        public void Ignore()
        {
            try
            {
                string ignorestring = Properties.Settings.Default.ignorelist;
                List<string> ignoreliste = new List<string>();
                using (var reader = new StreamReader(ignorestring))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        foreach (string c in Woerterliste)
                        {
                            if (c == line)
                            {
                                Woerterliste.Remove(c);
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Es wurde keine gültige ignore.txt gefunden");
                Console.WriteLine("Drücke eine beliebige Taste um fortzufahren");
                Console.ReadKey();
            }
        }
        
    }
}
