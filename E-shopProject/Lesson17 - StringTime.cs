using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EncondingTimeStringDisposable
{
    class Person
    {
        ~Person()
        {
            Console.WriteLine("This is person");
        }

    }
    class Program
    {
         
        ~Program()
        {
            Console.WriteLine("This is distructor ;) don't use");
        }
        static void Main2(string[] args)
        {
            //Encoding utf8 = Encoding.GetEncoding("utf-8");
            //Encoding ascii = Encoding.ASCII;

            //Console.WriteLine(ascii.GetChars(new byte[3] { 65, 66, 69 }));

            //Console.WriteLine(new string("viorel".ToCharArray(), 3, 3));

            //string.Empty;
            //string.IsNullOrEmpty;
            //"test".StartsWith("t");
            //"test".EndsWith("t");

            //Console.WriteLine(string.Format("My string is: {0:C}", 500));

            //Console.WriteLine("x".Equals("X", StringComparison.InvariantCultureIgnoreCase));

            //Console.WriteLine(string.Compare("viorel", "VIOREL", StringComparison.InvariantCultureIgnoreCase));

            //string myString = "C# is a simple, modern, general-purpose, object-oriented programming language developed by Microsoft within its .NET initiative led by Anders Hejlsberg. This tutorial will teach you basic C# programming and will also take you through various advanced concepts related to C# programming language.";
            //Console.WriteLine(myString.Contains("Microsoft"));

            //Console.WriteLine($"Name:{"Viorel", -20} Last:{"Test"}");


            //Console.WriteLine("Chisinau: " + new DateTimeOffset(DateTime.Now).DateTime + " " + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now));
            //Console.WriteLine("Astna: " + new DateTimeOffset(DateTime.Now.AddHours(4)).DateTime);
            //Console.WriteLine("Darwin: " + new DateTimeOffset(DateTime.Now.AddHours(4).AddMinutes(30)).DateTime);
            //Console.WriteLine("Vladivostok: " + new DateTimeOffset(DateTime.Now.AddHours(7)).DateTime);
            //Console.WriteLine("Alaska: " + new DateTimeOffset(DateTime.Now.AddHours(-12)).DateTime);


            //Console.WriteLine(6000.ToString("C", CultureInfo.GetCultureInfo("md-MD"))); //L6,000.00
            //Console.WriteLine(3000.ToString("C", CultureInfo.GetCultureInfo("ro-RO"))); //3.000,00 RON



            //Console.WriteLine(TimeZone.CurrentTimeZone.StandardName);


            //TimeSpan startClock = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            //while (true)
            //{
            //    if (startClock.Hours > 24)
            //        startClock = new TimeSpan(0, 0, 0);

            //    Console.Clear();
            //    Console.WriteLine(startClock.ToString());

            //    startClock = startClock + TimeSpan.FromMilliseconds(1000);
            //    Thread.Sleep(1000);

            //}

            //Program p = new Program();

            //GC.Collect(GC.GetGeneration(p));

            //Console.WriteLine("After collecting");


            //int a = 0;
            //while (a < 1000000)
            //{
            //    Person p = new Person();
            //    p = null;
            //    a++;
            //}



            Console.ReadKey();
        }
    }
}
