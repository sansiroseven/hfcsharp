using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatorExamples();
        }

        private static void OperatorExamples()
        {
            int width = 3;
            width++;

            int heigth = 2 + 4;
            int area = width * heigth;


            while(area < 50)
            {
                heigth++;
                area = heigth * width;
            }


            Console.WriteLine(area);
            string result = "The area";
            result = result + " is " + area;
            Console.WriteLine(result);

            //bool trunValue = true;
            //Console.WriteLine(trunValue);

            //int count = 5;
            //int i = 0;
            //while (count > 0)
            //{
            //    count = count * 3;
            //    count = count * -1;
            //    i++;
            //}



            //Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
