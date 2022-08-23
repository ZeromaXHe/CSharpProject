using System;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 279. 完全平方数 | 难度：中等 | 标签：广度优先搜索、数学、动态规划
    /// 给你一个整数 n ，返回 和为 n 的完全平方数的最少数量 。
    /// 
    /// 完全平方数 是一个整数，其值等于另一个整数的平方；换句话说，其值等于一个整数自乘的积。例如，1、4、9 和 16 都是完全平方数，而 3 和 11 不是。
    /// 
    /// 示例 1：
    /// 输入：n = 12
    /// 输出：3 
    /// 解释：12 = 4 + 4 + 4
    /// 
    /// 示例 2：
    /// 输入：n = 13
    /// 输出：2
    /// 解释：13 = 4 + 9
    /// 
    /// 提示：
    /// 1 <= n <= 104
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/perfect-squares
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution279
    {
        /// <summary>
        /// 执行用时：88 ms, 在所有 C# 提交中击败了 23.81% 的用户
        /// 内存消耗：27.9 MB, 在所有 C# 提交中击败了 39.68% 的用户
        /// 通过测试用例：588 / 588
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares(int n)
        {
            var dp = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; i + j * j <= n; j++)
                {
                    dp[i + j * j] = dp[i + j * j] == 0 ? dp[i] + 1 : Math.Min(dp[i] + 1, dp[i + j * j]);
                }
            }

            return dp[n];
        }
    }
}