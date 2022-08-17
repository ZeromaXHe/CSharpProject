using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 90. 子集 II | 难度：中等 | 标签：位运算、数组、回溯
    /// 给你一个整数数组 nums ，其中可能包含重复元素，请你返回该数组所有可能的子集（幂集）。
    /// 
    /// 解集 不能 包含重复的子集。返回的解集中，子集可以按 任意顺序 排列。
    /// 
    /// 示例 1：
    /// 输入：nums = [1,2,2]
    /// 输出：[[],[1],[1,2],[1,2,2],[2],[2,2]]
    /// 
    /// 示例 2：
    /// 输入：nums = [0]
    /// 输出：[[],[0]]
    /// 
    /// 提示：
    /// 1 <= nums.length <= 10
    /// -10 <= nums[i] <= 10
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/subsets-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution90
    {
        /// <summary>
        /// 执行用时：136 ms, 在所有 C# 提交中击败了 64.42% 的用户
        /// 内存消耗：42.2 MB, 在所有 C# 提交中击败了 24.04% 的用户
        /// 通过测试用例：20 / 20
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            var temp = new List<int>();
            result.Add(new List<int>(temp));
            Backtrack(nums, result, temp, 0);
            return result;
        }

        private void Backtrack(int[] nums, List<IList<int>> result, List<int> temp, int i)
        {
            if (i == nums.Length) return;
            var count = 1;
            while (i + count < nums.Length && nums[i] == nums[i + count]) count++;
            for (int j = 0; j < count; j++)
            {
                temp.Add(nums[i]);
                result.Add(new List<int>(temp));
                Backtrack(nums, result, temp, i + count);
            }

            temp.RemoveRange(temp.Count - count, count);
            Backtrack(nums, result, temp, i + count);
        }
    }
}