using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Program
    {
        public static void Main(string[] args)
        {
            int i = 1;

            do
            {
                

                Console.WriteLine("Write 1 for Get weather and 2 for Get Wind Speed  and  3 for Get Pressure  and 0for Exit");
                int input = Convert.ToInt32(Console.ReadLine()); ;
                i = input;
                
                if (input == 1)
                {
                    Console.WriteLine("Enter the date in YYYY-MM-DD if format");
                    //DateTime dt = Convert.ToDateTime(Console.ReadLine());
                    // string date = dt.ToShortDateString();
                    string date = Console.ReadLine();
                     DataAccess datass = new DataAccess();
                    //datass.GetData(date);
                    List<DataReprestentation.MainWithDate> lm = datass.GetData(date);
                    foreach (var m in lm)
                    {
                        Console.WriteLine(m.dateTime + ": " + "temp:" + m.mains.temp + "  min temp:" + m.mains.temp_min + " Max temp" + m.mains.temp_max);
                    }
                }
                else if (input == 2)
                {
                    Console.WriteLine("Enter the date in YYYY-MM-DD if format");
                    string date = Console.ReadLine();
                    DataAccess datass = new DataAccess();
                    List<DataReprestentation.WindsWithDate> lw = datass.GetWinds(date);
                    foreach (var win in lw)
                    {
                        Console.WriteLine(win.datetime + ": " + "wind speed: " + win.winds.speed + "  wind degree" + win.winds.deg);

                    }

                }
                else if(input==3)
                {
                    Console.WriteLine("Enter the date in YYYY-MM-DD if format");
                    string date = Console.ReadLine();
                    DataAccess datass = new DataAccess();
                    List<DataReprestentation.MainWithDate> ls = datass.GetData(date);
                    foreach (var s in ls)
                    {
                        Console.WriteLine(s.dateTime + ": " + "pressure:" + s.mains.pressure);
                    }
                }
                else
                {
                    break;
                }
            

            } while (i != 0);

            Console.Read();
        }
    }
}