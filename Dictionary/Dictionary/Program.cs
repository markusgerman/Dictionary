using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Markus German
/// Programm zur Aktualisierung von Textdateien
/// myconsult GmbH
/// </summary>

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary dic = new Dictionary();

            string befehl = "";
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("--"))
                {
                    befehl = args[i];
                    switch (befehl)
                    {
                        case "--help":
                            dic.Help();
                            break;
                        case "--dnshow":
                            dic.DNshow();
                            break;
                    }
                }
                else
                    switch (befehl)
                    {
                        case "--delete":
                            dic.DeleteWord(args[i]);
                            break;
                        case "--add":
                            dic.AddWord(args[i]);
                            break;
                    }
            }
            dic.ListToTxts();
        }
    }
}
