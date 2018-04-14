/*
------------------------------------------------------------------------------------------------------------------------
 * Copyright (c) 2017-2018 yh20021212 All Rights Reserved.
 * 
 * This code is licensed under the MIT License.
 *
 * Description: This is the implementation of the hash algorithm I invented.
 * Since  : 2017-4-15
 * Author : yh20021212
 * Version: 1.1.1
 * Update : 2018-4-15
------------------------------------------------------------------------------------------------------------------------
The MIT License (MIT)
Copyright © 2018 <copyright holders>
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.                                                                                                                                                                                                                                                                                                                                             
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
------------------------------------------------------------------------------------------------------------------------
*/
using System;

namespace HashLib
{
    public class HashLib : IHashLib
    {
        public HashLib()
        {

        }
        public void hash(ref int[] input)
        {
            input[0] = (input[input.Length - 1] >> 6 & 0x75ff);
            input[1] = (~input[0] >> 1 & 0x9c) + 5;
            for (int i = 2; i < input.Length; i++)
            {
                input[i] = (input[i - 1] << 5 * (~input[i - 1] >> 8) + (~input[i - 2] & 0xc6f)) * 0x675c6f - i;
            }
        }
        public int[] hash(int[] input)
        {
            int[] result = input;
            hash(ref result);
            return result;
        }
        public int[] hash(string str)
        {
            char[] chararrary = str.ToCharArray();
            int[] temp = new int[chararrary.Length];
            temp = Array.ConvertAll(chararrary, new Converter<char, int>((c) => { return c; }));
            hash(ref temp);
            return temp;
        }
        public int[] hash_salt(int[] input)
        {
            byte[] salt = Guid.NewGuid().ToByteArray();
            int[] vs = Array.ConvertAll(salt, new Converter<byte, int>((b) => Convert.ToInt32(b)));
            int[] temp = new int[input.Length + salt.Length + 1];
            Array.Copy(input, temp, input.Length);
            Array.Copy(vs, 0, temp, input.Length - 1, vs.Length);
            hash(ref temp);
            return temp;
        }
        public int[] hash_salt(string str)
        {
            char[] chararrary = str.ToCharArray();
            int[] temp = new int[chararrary.Length];
            temp = Array.ConvertAll(chararrary, new Converter<char, int>((c) => { return c; }));
            return hash_salt(temp);
        }
    }
}
