using System;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 343. 整数拆分 | 难度：中等 | 标签：数学、动态规划
    /// 给定一个正整数 n ，将其拆分为 k 个 正整数 的和（ k >= 2 ），并使这些整数的乘积最大化。
    /// 
    /// 返回 你可以获得的最大乘积 。
    /// 
    /// 示例 1:
    /// 输入: n = 2
    /// 输出: 1
    /// 解释: 2 = 1 + 1, 1 × 1 = 1。
    /// 
    /// 示例 2:
    /// 输入: n = 10
    /// 输出: 36
    /// 解释: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36。
    /// 
    /// 提示:
    /// 2 <= n <= 58
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/integer-break
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution343
    {
        int[] dp;

        private void init()
        {
            dp = new int[59];
            dp[2] = 1;
            for (int i = 3; i <= 58; i++)
            {
                for (int j = 1; j <= i - 2; j++)
                {
                    var prod = Math.Max(dp[i - j], i - j) * j;
                    if (prod > dp[i]) dp[i] = prod;
                }
            }
        }

        /// <summary>
        /// 执行用时：20 ms, 在所有 C# 提交中击败了 88.52% 的用户
        /// 内存消耗：26 MB, 在所有 C# 提交中击败了 42.62% 的用户
        /// 通过测试用例：50 / 50
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int IntegerBreak(int n)
        {
            if (dp == null) init();
            return dp[n];
        }
    }
}