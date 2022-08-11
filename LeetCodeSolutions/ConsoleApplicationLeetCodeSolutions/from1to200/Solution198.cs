using System;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 198. 打家劫舍 | 难度：中等 | 标签：数组、动态规划
    /// 你是一个专业的小偷，计划偷窃沿街的房屋。每间房内都藏有一定的现金，影响你偷窃的唯一制约因素就是相邻的房屋装有相互连通的防盗系统，如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。
    /// 
    /// 给定一个代表每个房屋存放金额的非负整数数组，计算你 不触动警报装置的情况下 ，一夜之内能够偷窃到的最高金额。
    /// 
    /// 示例 1：
    /// 输入：[1,2,3,1]
    /// 输出：4
    /// 解释：偷窃 1 号房屋 (金额 = 1) ，然后偷窃 3 号房屋 (金额 = 3)。
    /// 偷窃到的最高金额 = 1 + 3 = 4 。
    /// 
    /// 示例 2：
    /// 输入：[2,7,9,3,1]
    /// 输出：12
    /// 解释：偷窃 1 号房屋 (金额 = 2), 偷窃 3 号房屋 (金额 = 9)，接着偷窃 5 号房屋 (金额 = 1)。
    /// 偷窃到的最高金额 = 2 + 9 + 1 = 12 。
    /// 
    /// 提示：
    /// 1 <= nums.length <= 100
    /// 0 <= nums[i] <= 400
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/house-robber
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution198
    {
        /// <summary>
        /// 执行用时：88 ms, 在所有 C# 提交中击败了 13.94% 的用户
        /// 内存消耗：37.3 MB, 在所有 C# 提交中击败了 15.28% 的用户
        /// 通过测试用例：68 / 68
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            int[,] dp = new int[2, 2];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i % 2, 1] = Math.Max(Math.Max(dp[i % 2, 0], dp[i % 2, 1]), dp[(i + 1) % 2, 0]) + nums[i];
                dp[i % 2, 0] = Math.Max(dp[(i + 1) % 2, 0], dp[(i + 1) % 2, 1]);
            }

            return Math.Max(dp[(nums.Length - 1) % 2, 0], dp[(nums.Length - 1) % 2, 1]);
        }

        /// <summary>
        /// 执行用时：84 ms, 在所有 C# 提交中击败了 28.95% 的用户
        /// 内存消耗：37.2 MB, 在所有 C# 提交中击败了 43.70% 的用户
        /// 通过测试用例：68 / 68
        ///
        /// 还可以直接在 nums 本地直接算，继续优化
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob_simple(int[] nums)
        {
            int[] dp = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i % 2] = Math.Max(dp[i % 2] + nums[i], dp[(i + 1) % 2]);
            }

            return Math.Max(dp[0], dp[1]);
        }
    }
}