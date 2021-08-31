using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool chess_square = true;
                List<string> lines = new List<string>();
                lines.Add("<!DOCTYPE html>");
                lines.Add(" <html>");
                lines.Add("     <head>");
                // lines.Add("         <title></title>");
                lines.Add("         <meta charset=" + "\u0022" + "UTF-8" + "\u0022" + " > ");
                lines.Add("         <style>");
                lines.Add("             .chess-board { border-spacing: 0; border-collapse: collapse; }");
                lines.Add("             .chess-board th { padding: .5em; }");
                lines.Add("             .chess-board td { border: 1px solid; width: 2em; height: 2em; }");
                lines.Add("             .chess-board .light { background: #eee; }");
                lines.Add("             .chess-board .dark { background: #000; }");
                lines.Add("         </style>");
                lines.Add("     </head>");
                lines.Add("     <body>");
                lines.Add("         <table class=" + "\u0022" + "chess-board" + "\u0022" + "> ");
                lines.Add("             <tbody>");
                for (int i = 8; i > 0; i--)
                {
                    lines.Add("                 <tr>");
                    for (int j = 8; j > 0; j--)
                    {
                        if (chess_square)
                        {
                            lines.Add("                     <td class=" + "\u0022" + "light" + "\u0022" + "></td>");
                            chess_square = false;
                        }
                        else
                        {
                            lines.Add("                     <td class=" + "\u0022" + "dark" + "\u0022" + "></td>");
                            chess_square = true;
                        }
                    }
                    chess_square = !chess_square;
                    lines.Add("                 /<tr>");
                }
                lines.Add("             </tbody>");
                lines.Add("         </table>");
                lines.Add("     </body>");
                lines.Add("</html>");
                File.WriteAllLines(ConfigurationManager.AppSettings["FilePath"] + "index.html", lines.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message " + ex.Message.ToString());
                Console.ReadKey();
            }
            
        }
    }
}
