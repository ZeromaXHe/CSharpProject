﻿using System;

namespace ConsoleApplicationLeetCodeSolutions.from801to1000
{
    /// <summary>
    /// 910. 最小差值 II | 难度：中等 | 标签：贪心、数组、数学、排序
    /// 给你一个整数数组 nums，和一个整数 k 。
    /// 
    /// 对于每个下标 i（0 <= i < nums.length），将 nums[i] 变成 nums[i] + k 或 nums[i] - k 。
    /// 
    /// nums 的 分数 是 nums 中最大元素和最小元素的差值。
    /// 
    /// 在更改每个下标对应的值之后，返回 nums 的最小 分数 。
    /// 
    /// 示例 1：
    /// 
    /// 输入：nums = [1], k = 0
    /// 输出：0
    /// 解释：分数 = max(nums) - min(nums) = 1 - 1 = 0 。
    /// 示例 2：
    /// 
    /// 输入：nums = [0,10], k = 2
    /// 输出：6
    /// 解释：将数组变为 [2, 8] 。分数 = max(nums) - min(nums) = 8 - 2 = 6 。
    /// 示例 3：
    /// 输入：nums = [1,3,6], k = 3
    /// 输出：3
    /// 解释：将数组变为 [4, 6, 3] 。分数 = max(nums) - min(nums) = 6 - 3 = 3 。
    /// 
    /// 提示：
    /// 1 <= nums.length <= 104
    /// 0 <= nums[i] <= 104
    /// 0 <= k <= 104
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/smallest-range-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution910
    {
        /// <summary>
        /// 执行用时：100 ms, 在所有 C# 提交中击败了 66.67% 的用户
        /// 内存消耗：42.1 MB, 在所有 C# 提交中击败了 66.67% 的用户
        /// 通过测试用例：69 / 69
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SmallestRangeII(int[] nums, int k)
        {
            var n = nums.Length;
            if (n == 1) return 0;
            Array.Sort(nums);
            var ans = nums[n - 1] - nums[0];
            for (var i = 0; i < n - 1; i++)
            {
                var max = Math.Max(nums[i] + k, nums[n - 1] - k);
                var min = Math.Min(nums[0] + k, nums[i + 1] - k);
                var diff = max - min;
                ans = Math.Min(ans, diff);
            }

            return ans;
        }
    }
}