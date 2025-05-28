/*
 * Manage the display of the game in the console.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    public class Display
    {
        /// <summary>
        /// Display an error message in red color.
        /// </summary>
        /// <param name="message">the message</param>
        public static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

}
