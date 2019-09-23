using System;
using System.IO;
using System.Text;
using ChanUpP.Manage;

namespace ChanUpP
{
    class Program
    {
        static void Main(string[] args)
        {
            Converter conv = new Converter();
            string str = Console.ReadLine();
            var p = conv.StringToBriall(str);

            conv.Write(@"C:\Users\aoika\Desktop\a.xml", p);


            //while (true) {
            //    using (StreamWriter sw = new StreamWriter("/Users/aoikazto/Desktop/result.txt", true, Encoding.UTF8))
            //    {
            //        //  u'ㄲ': [[1,0,0,0,0,0], [1,0,0,0,0,0]],
            //        //  u'ㄴ': [[1,0,0,1,0,0]];
            //        try
            //        {
            //            string str = Console.ReadLine();
            //            var s = str.Split('\'');
            //            var ch = s[1]
            //            var size = str.Split('[').Length;
            //            var inner = str.Split('[')[2];
            //            if (size == 4)
            //            {
            //                var p = inner.Split(']')[0];
            //                var in2 = str.Split('[')[3];
            //                in2 = in2.Split(']')[0];
            //                sw.WriteLine($"Braille[\'{ch}\'] = ListToBlock(new List<int> {{ {p}, {in2} }});");
            //            }
            //            else if (size == 3)
            //            {
            //                var p = inner.Split(']')[0];
            //                sw.WriteLine($"Braille[\'{ch}\'] = ListToBlock(new List<int> {{ {p} }});");
            //            }
            //        }
            //        catch
            //        {
            //        }
            //    }
            //}
        }
    }
}