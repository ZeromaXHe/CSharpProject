using System;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 264. 丑数 II | 难度：中等 | 标签：哈希表、数学、动态规划、堆（优先队列）
    /// 给你一个整数 n ，请你找出并返回第 n 个 丑数 。
    /// 
    /// 丑数 就是只包含质因数 2、3 和/或 5 的正整数。
    /// 
    /// 示例 1：
    /// 输入：n = 10
    /// 输出：12
    /// 解释：[1, 2, 3, 4, 5, 6, 8, 9, 10, 12] 是由前 10 个丑数组成的序列。
    /// 
    /// 示例 2：
    /// 输入：n = 1
    /// 输出：1
    /// 解释：1 通常被视为丑数。
    /// 
    /// 提示：
    /// 1 <= n <= 1690
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/ugly-number-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution264
    {
        /// <summary>
        /// 执行用时：16 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗：26.9 MB, 在所有 C# 提交中击败了 65.79% 的用户
        /// 通过测试用例：596 / 596
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NthUglyNumber(int n)
        {
            var dp = new int[n];
            var ptr = new int[3];
            dp[0] = 1;
            for (int i = 1; i < n; i++)
            {
                dp[i] = Math.Min(Math.Min(dp[ptr[0]] * 2, dp[ptr[1]] * 3), dp[ptr[2]] * 5);
                // if 语句必须都并列执行，如果使用 else if 会导致没有去重
                if (dp[i] == dp[ptr[0]] * 2) ptr[0]++;
                if (dp[i] == dp[ptr[1]] * 3) ptr[1]++;
                if (dp[i] == dp[ptr[2]] * 5) ptr[2]++;
            }

            return dp[n - 1];
        }
    }
}