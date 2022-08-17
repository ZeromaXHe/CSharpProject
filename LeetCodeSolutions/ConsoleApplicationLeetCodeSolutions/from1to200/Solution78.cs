using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 78. 子集 | 难度：中等 | 标签：位运算、数组、回溯
    /// 给你一个整数数组 nums ，数组中的元素 互不相同 。返回该数组所有可能的子集（幂集）。
    /// 
    /// 解集 不能 包含重复的子集。你可以按 任意顺序 返回解集。
    /// 
    /// 示例 1：
    /// 输入：nums = [1,2,3]
    /// 输出：[[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
    /// 
    /// 示例 2：
    /// 输入：nums = [0]
    /// 输出：[[],[0]]
    /// 
    /// 提示：
    /// 1 <= nums.length <= 10
    /// -10 <= nums[i] <= 10
    /// nums 中的所有元素 互不相同
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/subsets
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution78
    {
        /// <summary>
        /// 执行用时：132 ms, 在所有 C# 提交中击败了 61.17% 的用户
        /// 内存消耗：41.5 MB, 在所有 C# 提交中击败了 83.15% 的用户
        /// 通过测试用例：10 / 10
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>>();
            var temp = new List<int>();
            result.Add(new List<int>(temp));
            Backtrack(nums, result, temp, 0);
            return result;
        }

        private void Backtrack(int[] nums, List<IList<int>> result, List<int> temp, int i)
        {
            if (i == nums.Length) return;
            temp.Add(nums[i]);
            result.Add(new List<int>(temp));
            Backtrack(nums, result, temp, i + 1);
            temp.RemoveAt(temp.Count - 1);
            Backtrack(nums, result, temp, i + 1);
        }
    }
}