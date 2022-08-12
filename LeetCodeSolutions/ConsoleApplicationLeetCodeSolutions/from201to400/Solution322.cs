using System;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 322. 零钱兑换 | 难度：中等 | 标签：广度优先搜索、数组、动态规划
    /// 给你一个整数数组 coins ，表示不同面额的硬币；以及一个整数 amount ，表示总金额。
    /// 
    /// 计算并返回可以凑成总金额所需的 最少的硬币个数 。如果没有任何一种硬币组合能组成总金额，返回 -1 。
    /// 
    /// 你可以认为每种硬币的数量是无限的。
    /// 
    /// 示例 1：
    /// 输入：coins = [1, 2, 5], amount = 11
    /// 输出：3 
    /// 解释：11 = 5 + 5 + 1
    /// 
    /// 示例 2：
    /// 输入：coins = [2], amount = 3
    /// 输出：-1
    /// 
    /// 示例 3：
    /// 输入：coins = [1], amount = 0
    /// 输出：0
    /// 
    /// 提示：
    /// 1 <= coins.length <= 12
    /// 1 <= coins[i] <= 231 - 1
    /// 0 <= amount <= 104
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/coin-change
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution322
    {
        public void Test()
        {
            // C# 报错在力扣上没有行号…… 在 Rider 上没有跳转报错行的链接…… 太蠢了。不知道 VS 上怎么样
            Console.WriteLine(new Solution322().CoinChange(new[] {1, 2, 5}, 11)); // 3
            Console.WriteLine(new Solution322().CoinChange(new[] {1}, 2)); // 2
            Console.WriteLine(new Solution322().CoinChange(new[] {1, 2147483647}, 2)); // 2
        }

        /// <summary>
        /// 执行用时：88 ms, 在所有 C# 提交中击败了 88.94% 的用户
        /// 内存消耗：40.6 MB, 在所有 C# 提交中击败了 94.98% 的用户
        /// 通过测试用例：189 / 189
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            int[] dp = new int[amount + 1];
            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i] < amount) dp[coins[i]] = 1;
                else if (coins[i] == amount) return 1;
            }

            for (int i = 0; i < amount; i++)
            {
                if (dp[i] == 0) continue;
                for (int j = 0; j < coins.Length; j++)
                {
                    long next = (long) i + coins[j];
                    if (next > amount) continue;
                    if (dp[next] == 0 || dp[i] + 1 < dp[next]) dp[next] = dp[i] + 1;
                }
            }

            return dp[amount] == 0 ? -1 : dp[amount];
        }
    }
}