﻿/*
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
namespace HashLib3
{
    public interface IHashLib
    {
        int[] hash(int[] input);
        void hash(ref int[] input);
        int[] hash(string str);
        int[] hash_salt(int[] input);
        int[] hash_salt(string str);
    }
}