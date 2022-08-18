using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 39. 组合总和 | 难度：中等 | 标签：数组、回溯
    /// 给你一个 无重复元素 的整数数组 candidates 和一个目标整数 target ，找出 candidates 中可以使数字和为目标数 target 的 所有 不同组合 ，并以列表形式返回。你可以按 任意顺序 返回这些组合。
    /// 
    /// candidates 中的 同一个 数字可以 无限制重复被选取 。如果至少一个数字的被选数量不同，则两种组合是不同的。 
    /// 
    /// 对于给定的输入，保证和为 target 的不同组合数少于 150 个。
    /// 
    /// 示例 1：
    /// 输入：candidates = [2,3,6,7], target = 7
    /// 输出：[[2,2,3],[7]]
    /// 解释：
    /// 2 和 3 可以形成一组候选，2 + 2 + 3 = 7 。注意 2 可以使用多次。
    /// 7 也是一个候选， 7 = 7 。
    /// 仅有这两种组合。
    /// 
    /// 示例 2：
    /// 输入: candidates = [2,3,5], target = 8
    /// 输出: [[2,2,2,2],[2,3,3],[3,5]]
    /// 
    /// 示例 3：
    /// 输入: candidates = [2], target = 1
    /// 输出: []
    /// 
    /// 提示：
    /// 1 <= candidates.length <= 30
    /// 1 <= candidates[i] <= 200
    /// candidate 中的每个元素都 互不相同
    /// 1 <= target <= 500
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/combination-sum
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution39
    {
        /// <summary>
        /// 执行用时：140 ms, 在所有 C# 提交中击败了 49.24% 的用户
        /// 内存消耗：43 MB, 在所有 C# 提交中击败了 66.56% 的用户
        /// 通过测试用例：171 / 171
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var combine = new List<int>();
            var list = new List<IList<int>>();
            Array.Sort(candidates);
            BackTrack(candidates, target, combine, list, 0);
            return list;
        }

        private void BackTrack(int[] candidates, int target, List<int> combine, List<IList<int>> list, int i)
        {
            if (i == candidates.Length) return;
            if (target == 0)
            {
                list.Add(new List<int>(combine));
                return;
            }

            BackTrack(candidates, target, combine, list, i + 1);
            if (target - candidates[i] >= 0)
            {
                combine.Add(candidates[i]);
                BackTrack(candidates, target - candidates[i], combine, list, i);
                combine.RemoveAt(combine.Count - 1);
            }
        }
    }
}