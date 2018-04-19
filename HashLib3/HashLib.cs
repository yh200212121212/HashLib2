/*
------------------------------------------------------------------------------------------------------------------------
 * Copyright (c) 2017-2018 yh20021212 All Rights Reserved.
 * 
 * This code is licensed under the MIT License.
 *
 * Description: This is the implementation of the hash algorithm I invented.
 * Since  : 2018-4-15
 * Author : yh20021212
 * Version: 1.1.3
 * Update : 2018-4-19
------------------------------------------------------------------------------------------------------------------------
The MIT License (MIT)
Copyright © 2018 <copyright holders>
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.                                                                                                                                                                                                                                                                                                                                             
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
------------------------------------------------------------------------------------------------------------------------
*/
using System;
using System.Linq;

namespace HashLib3
{
    /// <summary>
    ///  对外公开的我的哈希算法类，2N轮加密，输出长度为OutputArraryLen的数组或字符串。
    /// </summary>
    public class HashLib : IHashLib
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public HashLib()
        {

        }
        /// <summary>
        /// 私有内部方法，用于在加密过程中最后再次哈希
        /// </summary>
        /// <param name="input">输入/输出数据，In/Out。</param>
        private void hash(ref int[] input)
        {
            input[0] = (input[input.Length - 1] >> 6 & 0x75ff);
            input[1] = (~input[0] >> 1 & 0x9c) + 5;
            for (int i = 2; i < input.Length; i++)
            {
                input[i] = (input[i - 1] << 5 * (~input[i - 1] >> 8) + (~input[i - 2] & 0xc6f)) * 0x675c6f - i;
            }
        }
        /// <summary>
        ///  私有内部方法，用于应用种子产生哈希
        /// </summary>
        /// <param name="seed">种子</param>
        /// <param name="input">输入/输出数据，In/Out。</param>
        private void hash2(int seed, ref int[] input)
        {
            input[0] = (input[input.Length - 1] >> 6 & 0x75ff) + 3 * seed;
            input[1] = (~input[0] >> 1 & 0x9c + ~-seed) + 5;
            for (int i = 2; i < input.Length; i++)
            {
                input[i] = (input[i - 1] << 5 * (~input[i - 1] >> 8) + (~input[i - 2] & 0xc6f)) * 0x675c6f - i + (seed & 0x2f) / 4;
            }
        }
        /// <summary>
        /// 对外公开的哈希方法之一
        /// </summary>
        /// <param name="input">输入数据</param>
        /// <returns>长度为常量OutputArraryLen的结果</returns>
        public long[] hash2(int[] input)
        {
            int[] temp1 = input;
            int[] temp2 = input;
            int[] s = new int[input.Length * 2 * N + 20];
            for (int i = 0; i < N; i++)
            {
                hash2(i & 0x4f + i << 2, ref temp1);
                if (i == 0)
                {
                    for (int j = 0; j < temp1.Length; j++)
                    {
                        s[j] = temp1[j];
                    }
                }
                for (int k = i * (temp1.Length); k < (i + 1) * (temp1.Length); k++)
                {
                    for (int l = 0; l < temp1.Length; l++)
                    {
                        s[k] = temp1[l];
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                hash2(~i ^ -0x5a, ref temp2);
                if (i == 0)
                {
                    for (int j = 0; j < temp2.Length; j++)
                    {
                        s[j] = temp2[j];
                    }
                }
                for (int k = i * (temp2.Length); k < (i + 1) * (temp2.Length); k++)
                {
                    for (int l = 0; l < temp2.Length; l++)
                    {
                        s[k] = temp2[l];
                    }
                }
            }
            s = s.OrderBy(x => Guid.NewGuid()).ToArray();
            hash(ref s);
            var temp4 = s.Take(OutputArraryLen).ToArray();
            long[] result = Array.ConvertAll(temp4, new Converter<int, long>((i) => { return Convert.ToInt64(i); }));
            return result;
        }
        /// <summary>
        /// 对外公开的哈希方法之一
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns>长度为常量OutputArraryLen的结果</returns>
        public long[] hash2(string str)
        {
            char[] chararrary = str.ToCharArray();
            int[] temp = Array.ConvertAll(chararrary, new Converter<char, int>((c) => { return c; }));
            long[] result = hash2(temp);
            return result;
        }
        /// <summary>
        /// 对外公开的哈希方法之一
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <param name="o">重载对象，无意义</param>
        /// <returns>以逗号分割的，长度为常量OutputArraryLen的字符串结果，类似于："1,2,3"。</returns>
        public string hash2(string str, object o)
        {
            char[] chararrary = str.ToCharArray();
            int[] temp = Array.ConvertAll(chararrary, new Converter<char, int>((c) => { return c; }));
            long[] result = hash2(temp);
            string StrResult = "";
            for (int i = 0; i < result.Length - 1; i++)
            {
                StrResult += result[i].ToString() + ",";
            }
            StrResult += result[result.Length - 1].ToString();
            return StrResult;
        }
        /// <summary>
        /// 对外公开的加盐哈希方法之一
        /// </summary>
        /// <param name="input">输入数据</param>
        /// <returns>长度为常量OutputArraryLen的结果</returns>
        public long[] hash_salt2(int[] input)
        {
            byte[] salt = Guid.NewGuid().ToByteArray();
            int[] vs = Array.ConvertAll(salt, new Converter<byte, int>((b) => Convert.ToInt32(b)));
            int[] temp = new int[input.Length + salt.Length + 1];
            Array.Copy(input, temp, input.Length);
            Array.Copy(vs, 0, temp, input.Length - 1, vs.Length);
            return hash2(temp);
        }
        /// <summary>
        /// 对外公开的加盐哈希方法之一
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns>以逗号分割的，长度为常量OutputArraryLen的字符串结果，类似于："1,2,3"。</returns>
        public long[] hash_salt2(string str)
        {
            char[] chararrary = str.ToCharArray();
            int[] temp = Array.ConvertAll(chararrary, new Converter<char, int>((c) => { return c; }));
            return hash_salt2(temp);
        }
        /// <summary>
        /// 对外公开的加盐哈希方法之一
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <param name="o">重载对象，无意义</param>
        /// <returns>以逗号分割的，长度为常量OutputArraryLen的字符串结果，类似于："1,2,3"。</returns>
        public string hash_salt2(string str, object o)
        {
            char[] chararrary = str.ToCharArray();
            int[] temp = Array.ConvertAll(chararrary, new Converter<char, int>((c) => { return c; }));
            var temp2 = hash_salt2(temp);
            string StrResult = "";
            for (int i = 0; i < temp2.Length - 1; i++)
            {
                StrResult += temp2[i].ToString() + ",";
            }
            StrResult += temp2[temp2.Length - 1].ToString();
            return StrResult;
        }
        /// <summary>
        /// 输出数组长度
        /// </summary>
        public const int OutputArraryLen = 2560;
        /// <summary>
        /// 算法中的半轮数
        /// </summary>
        public const int N = 1666;
    }
}
