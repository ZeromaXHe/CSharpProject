﻿using System;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 191. 位1的个数 | 难度：简单 | 标签：位运算、分治
    /// 编写一个函数，输入是一个无符号整数（以二进制串的形式），返回其二进制表达式中数字位数为 '1' 的个数（也被称为汉明重量）。
    /// 
    /// 提示：
    /// 请注意，在某些语言（如 Java）中，没有无符号整数类型。在这种情况下，输入和输出都将被指定为有符号整数类型，并且不应影响您的实现，因为无论整数是有符号的还是无符号的，其内部的二进制表示形式都是相同的。
    /// 在 Java 中，编译器使用二进制补码记法来表示有符号整数。因此，在上面的 示例 3 中，输入表示有符号整数 -3。
    /// 
    /// 示例 1：
    /// 输入：00000000000000000000000000001011
    /// 输出：3
    /// 解释：输入的二进制串 00000000000000000000000000001011 中，共有三位为 '1'。
    /// 
    /// 示例 2：
    /// 输入：00000000000000000000000010000000
    /// 输出：1
    /// 解释：输入的二进制串 00000000000000000000000010000000 中，共有一位为 '1'。
    /// 
    /// 示例 3：
    /// 输入：11111111111111111111111111111101
    /// 输出：31
    /// 解释：输入的二进制串 11111111111111111111111111111101 中，共有 31 位为 '1'。
    /// 
    /// 提示：
    /// 输入必须是长度为 32 的 二进制串 。
    /// 
    /// 进阶：
    /// 如果多次调用这个函数，你将如何优化你的算法？
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/number-of-1-bits
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution191
    {
        /// <summary>
        /// 执行用时：20 ms, 在所有 C# 提交中击败了 81.55% 的用户
        /// 内存消耗：23.1 MB, 在所有 C# 提交中击败了 75.65% 的用户
        /// 通过测试用例：601 / 601
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(uint n)
        {
            // >> 的优先级貌似低于 +，必须加括号
            n = (0x55555555 & n) + ((0xAAAAAAAA & n) >> 1);
            // Console.WriteLine(Convert.ToString(n, 2));
            n = (0x33333333 & n) + ((0xCCCCCCCC & n) >> 2);
            // Console.WriteLine(Convert.ToString(n, 2));
            n = (0x0F0F0F0F & n) + ((0xF0F0F0F0 & n) >> 4);
            // Console.WriteLine(Convert.ToString(n, 2));
            n = (0x00FF00FF & n) + ((0xFF00FF00 & n) >> 8);
            // Console.WriteLine(Convert.ToString(n, 2));
            return (int) ((0xFFFF & n) + (n >> 16));
        }
    }
}