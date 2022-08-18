using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 47. 全排列 II | 难度：中等 | 标签：数组、回溯
    /// 给定一个可包含重复数字的序列 nums ，按任意顺序 返回所有不重复的全排列。
    /// 
    /// 示例 1：
    /// 输入：nums = [1,1,2]
    /// 输出：
    /// [[1,1,2],
    /// [1,2,1],
    /// [2,1,1]]
    /// 
    /// 示例 2：
    /// 输入：nums = [1,2,3]
    /// 输出：[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
    /// 
    /// 提示：
    /// 1 <= nums.length <= 8
    /// -10 <= nums[i] <= 10
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/permutations-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution47
    {
        /// <summary>
        /// 执行用时：136 ms, 在所有 C# 提交中击败了 65.44% 的用户
        /// 内存消耗：44.3 MB, 在所有 C# 提交中击败了 44.85% 的用户
        /// 通过测试用例：33 / 33
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var perm = new List<int>();
            var list = new List<IList<int>>();
            var visit = new bool[nums.Length];
            Array.Sort(nums);
            Backtrack(nums, perm, list, visit);
            return list;
        }

        private void Backtrack(int[] nums, List<int> perm, List<IList<int>> list, bool[] visit)
        {
            if (perm.Count == nums.Length)
            {
                list.Add(new List<int>(perm));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (visit[i] || (i > 0 && nums[i] == nums[i - 1] && !visit[i - 1])) continue;
                perm.Add(nums[i]);
                visit[i] = true;
                Backtrack(nums, perm, list, visit);
                visit[i] = false;
                perm.RemoveAt(perm.Count - 1);
            }
        }
    }
}