using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace exercice1.View
{
    class StationView
    {
        /// <summary>
        /// Start a new section with the given title
        /// </summary>
        /// <param name="title">Title of the section</param>
        public static void StartSection(string title)
        {
            Console.WriteLine($"---------{title}----------");
        }

        /// <summary>
        /// End the current section
        /// </summary>
        public static void EndSection()
        {
            Console.Write("\n\n\n");
        }

        /// <summary>
        /// Display an enumerable of strings
        /// </summary>
        /// <param name="sEnum">The enumerable</param>
        /// <param name="sameLine">Wether the strings are displayed on the same line</param>
        /// <param name="prefix">A string to place before each element of the enumerable</param>
        public static void DisplayEnumerable(IEnumerable<String> sEnum, Boolean sameLine = false, string prefix = " ")
        {
            foreach (string s in sEnum)
            {
                string str = $"{prefix}{s}";
                if (sameLine)
                    Console.Write(str);
                else
                    Console.WriteLine(str);
            }
        }
    }
}
