﻿using System;

namespace ConsoleApplicationLeetCodeSolutions.from1201to1400
{
    /// <summary>
    /// 1201. 丑数 III | 难度：中等 | 标签：数学、二分查找、数论
    /// 给你四个整数：n 、a 、b 、c ，请你设计一个算法来找出第 n 个丑数。
    /// 
    /// 丑数是可以被 a 或 b 或 c 整除的 正整数 。
    /// 
    /// 示例 1：
    /// 输入：n = 3, a = 2, b = 3, c = 5
    /// 输出：4
    /// 解释：丑数序列为 2, 3, 4, 5, 6, 8, 9, 10... 其中第 3 个是 4。
    /// 
    /// 示例 2：
    /// 输入：n = 4, a = 2, b = 3, c = 4
    /// 输出：6
    /// 解释：丑数序列为 2, 3, 4, 6, 8, 9, 10, 12... 其中第 4 个是 6。
    /// 
    /// 示例 3：
    /// 输入：n = 5, a = 2, b = 11, c = 13
    /// 输出：10
    /// 解释：丑数序列为 2, 4, 6, 8, 10, 11, 12, 13... 其中第 5 个是 10。
    /// 
    /// 示例 4：
    /// 输入：n = 1000000000, a = 2, b = 217983653, c = 336916467
    /// 输出：1999999984
    /// 
    /// 提示：
    /// 1 <= n, a, b, c <= 10^9
    /// 1 <= a * b * c <= 10^18
    /// 本题结果在 [1, 2 * 10^9] 的范围内
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/ugly-number-iii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1201
    {
        /// <summary>
        /// 执行用时：32 ms, 在所有 C# 提交中击败了 16.67% 的用户
        /// 内存消耗：25.9 MB, 在所有 C# 提交中击败了 100.00% 的用户
        /// 通过测试用例：53 / 53
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int NthUglyNumber(int n, int a, int b, int c)
        {
            long ans = 0;
            long l = 0, r = (long) Math.Min(a, Math.Min(b, c)) * n;
            long ab = Lcm(a, b);
            long ac = Lcm(a, c);
            long bc = Lcm(b, c);
            long abc = Lcm(b, ac);
            while (l <= r)
            {
                long m = l + ((r - l) >> 1);
                long num = m / a + m / b + m / c - m / ab - m / ac - m / bc + m / abc;
                if (num < n)
                {
                    l = m + 1;
                    ans = l;
                }
                else r = m - 1;
            }

            return (int) ans;
        }

        private long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);

        private long Lcm(long a, long b) => a * b / Gcd(a, b);
    }
}