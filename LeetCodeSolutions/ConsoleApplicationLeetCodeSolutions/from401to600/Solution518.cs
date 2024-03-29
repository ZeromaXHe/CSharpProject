﻿namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 518. 零钱兑换 II | 难度：中等 | 标签：数组、动态规划
    /// 给你一个整数数组 coins 表示不同面额的硬币，另给一个整数 amount 表示总金额。
    /// 
    /// 请你计算并返回可以凑成总金额的硬币组合数。如果任何硬币组合都无法凑出总金额，返回 0 。
    /// 
    /// 假设每一种面额的硬币有无限个。 
    /// 
    /// 题目数据保证结果符合 32 位带符号整数。
    /// 
    /// 示例 1：
    /// 输入：amount = 5, coins = [1, 2, 5]
    /// 输出：4
    /// 解释：有四种方式可以凑成总金额：
    /// 5=5
    /// 5=2+2+1
    /// 5=2+1+1+1
    /// 5=1+1+1+1+1
    /// 
    /// 示例 2：
    /// 输入：amount = 3, coins = [2]
    /// 输出：0
    /// 解释：只用面额 2 的硬币不能凑成总金额 3 。
    /// 
    /// 示例 3：
    /// 输入：amount = 10, coins = [10] 
    /// 输出：1
    /// 
    /// 提示：
    /// 1 <= coins.length <= 300
    /// 1 <= coins[i] <= 5000
    /// coins 中的所有值 互不相同
    /// 0 <= amount <= 5000
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/coin-change-2
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution518
    {
        /// <summary>
        /// 执行用时：84 ms, 在所有 C# 提交中击败了 64.91% 的用户
        /// 内存消耗：37.3 MB, 在所有 C# 提交中击败了 78.95% 的用户
        /// 通过测试用例：28 / 28
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int Change(int amount, int[] coins)
        {
            int[] dp = new int[amount + 1];
            dp[0] = 1;
            foreach (var coin in coins)
            {
                for (int i = coin; i <= amount; i++)
                {
                    dp[i] += dp[i - coin];
                }
            }

            return dp[amount];
        }
    }
}