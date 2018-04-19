using HashLib;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Test";
            int[] input = {
                1,3,2,3,4,5,1,2,3,4,99,109,33,4,2,32,32,-1,-33,-1078,-3459,0xcf,0x9c,0xff,0x777ffdc,-0x934dc,3,40560,20,930,1809,2,3,4,5,66,54,190,304,22,34,56,1,2,1,0,-9,-99,-190,-123&0x9c,~010010,-2,-193456,int.MaxValue,int.MinValue
            };
            IHashLib hashLib = new HashLib.HashLib();
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            long[] result = hashLib.hash2(input), result2 = hashLib.hash_salt2(input), result3 = hashLib.hash2(str), result4 = hashLib.hash_salt2(str);
            stopwatch.Stop();
            Console.WriteLine("The first of the output array:{0},{1},{2},{3}", result[0], result2[0], result3[0], result4[0]);
            Console.WriteLine(TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).TotalMinutes.ToString());
            Console.ReadKey();
        }
    }
}
