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
namespace HashLibShared
{
    public interface IHashLib
    {
        /// <summary>
        /// 对外公开的哈希方法之一
        /// </summary>
        /// <param name="input">输入数据</param>
        /// <returns>长度为常量OutputArraryLen的结果</returns>
        long[] hash2(int[] input);
        /// <summary>
        /// 对外公开的哈希方法之一
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns>长度为常量OutputArraryLen的结果</returns>
        long[] hash2(string str);
        /// <summary>
        /// 对外公开的哈希方法之一
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <param name="o">重载对象，无意义</param>
        /// <returns>以逗号分割的，长度为常量OutputArraryLen的字符串结果，类似于："1,2,3"。</returns>
        string hash2(string str, object o);
        /// <summary>
        /// 对外公开的加盐哈希方法之一
        /// </summary>
        /// <param name="input">输入数据</param>
        /// <returns>长度为常量OutputArraryLen的结果</returns>
        long[] hash_salt2(int[] input);
        /// <summary>
        /// 对外公开的加盐哈希方法之一
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns>以逗号分割的，长度为常量OutputArraryLen的字符串结果，类似于："1,2,3"。</returns>
        long[] hash_salt2(string str);
        /// <summary>
        /// 对外公开的加盐哈希方法之一
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <param name="o">重载对象，无意义</param>
        /// <returns>以逗号分割的，长度为常量OutputArraryLen的字符串结果，类似于："1,2,3"。</returns>
        string hash_salt2(string str, object o);
    }
}