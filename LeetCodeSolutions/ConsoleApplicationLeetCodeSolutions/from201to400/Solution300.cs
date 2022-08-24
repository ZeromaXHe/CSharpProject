﻿using System;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 300. 最长递增子序列 | 难度：中等 | 标签：数组、二分查找、动态规划
    /// 给你一个整数数组 nums ，找到其中最长严格递增子序列的长度。
    /// 
    /// 子序列 是由数组派生而来的序列，删除（或不删除）数组中的元素而不改变其余元素的顺序。例如，[3,6,2,7] 是数组 [0,3,1,6,2,2,7] 的子序列。
    /// 
    /// 示例 1：
    /// 输入：nums = [10,9,2,5,3,7,101,18]
    /// 输出：4
    /// 解释：最长递增子序列是 [2,3,7,101]，因此长度为 4 。
    /// 
    /// 示例 2：
    /// 输入：nums = [0,1,0,3,2,3]
    /// 输出：4
    /// 
    /// 示例 3：
    /// 输入：nums = [7,7,7,7,7,7,7]
    /// 输出：1
    /// 
    /// 提示：
    /// 1 <= nums.length <= 2500
    /// -104 <= nums[i] <= 104
    /// 
    /// 进阶：
    /// 你能将算法的时间复杂度降低到 O(n log(n)) 吗?
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/longest-increasing-subsequence
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution300
    {
        /// <summary>
        /// 执行用时：136 ms, 在所有 C# 提交中击败了 61.32% 的用户
        /// 内存消耗：38.8 MB, 在所有 C# 提交中击败了 64.20% 的用户
        /// 通过测试用例：54 / 54
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            var dp = new int[nums.Length];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }

            var max = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j]) dp[i] = Math.Max(dp[i], dp[j] + 1);
                }

                if (dp[i] > max) max = dp[i];
            }

            return max;
        }
    }
}