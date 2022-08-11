using System;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 213. 打家劫舍 II | 难度：中等 | 标签：数组、动态规划
    /// 你是一个专业的小偷，计划偷窃沿街的房屋，每间房内都藏有一定的现金。这个地方所有的房屋都 围成一圈 ，这意味着第一个房屋和最后一个房屋是紧挨着的。同时，相邻的房屋装有相互连通的防盗系统，如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警 。
    /// 
    /// 给定一个代表每个房屋存放金额的非负整数数组，计算你 在不触动警报装置的情况下 ，今晚能够偷窃到的最高金额。
    /// 
    /// 示例 1：
    /// 输入：nums = [2,3,2]
    /// 输出：3
    /// 解释：你不能先偷窃 1 号房屋（金额 = 2），然后偷窃 3 号房屋（金额 = 2）, 因为他们是相邻的。
    /// 
    /// 示例 2：
    /// 输入：nums = [1,2,3,1]
    /// 输出：4
    /// 解释：你可以先偷窃 1 号房屋（金额 = 1），然后偷窃 3 号房屋（金额 = 3）。
    /// 偷窃到的最高金额 = 1 + 3 = 4 。
    /// 
    /// 示例 3：
    /// 输入：nums = [1,2,3]
    /// 输出：3
    /// 
    /// 提示：
    /// 1 <= nums.length <= 100
    /// 0 <= nums[i] <= 1000
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/house-robber-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution213
    {
        /// <summary>
        /// 执行用时：88 ms, 在所有 C# 提交中击败了 16.13% 的用户
        /// 内存消耗：36.9 MB, 在所有 C# 提交中击败了 93.55% 的用户
        /// 通过测试用例：75 / 75
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            int[] dp1 = new int[2];
            int[] dp2 = new int[2];
            for (int i = 1; i < nums.Length; i++)
            {
                dp1[i % 2] = Math.Max(dp1[i % 2] + nums[i], dp1[(i + 1) % 2]);
                dp2[i % 2] = Math.Max(dp2[i % 2] + nums[nums.Length - 1 - i], dp2[(i + 1) % 2]);
            }

            return Math.Max(Math.Max(dp1[0], dp1[1]), Math.Max(dp2[0], dp2[1]));
        }
    }
}