using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 40. 组合总和 II | 难度：中等 | 标签：数组、回溯
    /// 给定一个候选人编号的集合 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
    /// 
    /// candidates 中的每个数字在每个组合中只能使用 一次 。
    /// 
    /// 注意：解集不能包含重复的组合。 
    /// 
    /// 示例 1:
    /// 输入: candidates = [10,1,2,7,6,1,5], target = 8,
    /// 输出:
    /// [
    /// [1,1,6],
    /// [1,2,5],
    /// [1,7],
    /// [2,6]
    /// ]
    /// 
    /// 示例 2:
    /// 输入: candidates = [2,5,2,1,2], target = 5,
    /// 输出:
    /// [
    /// [1,2,2],
    /// [5]
    /// ]
    /// 
    /// 提示:
    /// 1 <= candidates.length <= 100
    /// 1 <= candidates[i] <= 50
    /// 1 <= target <= 30
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/combination-sum-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution40
    {
        /// <summary>
        /// 执行用时：140 ms, 在所有 C# 提交中击败了 42.42% 的用户
        /// 内存消耗：42.4 MB, 在所有 C# 提交中击败了 53.33% 的用户
        /// 通过测试用例：176 / 176
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var combine = new List<int>();
            var list = new List<IList<int>>();
            var visit = new bool[candidates.Length];
            Array.Sort(candidates);
            BackTrack(candidates, target, combine, list, 0, visit);
            return list;
        }

        private void BackTrack(int[] candidates, int target, List<int> combine,
            List<IList<int>> list, int i, bool[] visit)
        {
            if (target == 0)
            {
                list.Add(new List<int>(combine));
                return;
            }

            if (i == candidates.Length) return;

            BackTrack(candidates, target, combine, list, i + 1, visit);
            if (target - candidates[i] >= 0 &&
                !(visit[i] || (i > 0 && candidates[i] == candidates[i - 1] && !visit[i - 1])))
            {
                combine.Add(candidates[i]);
                visit[i] = true;
                BackTrack(candidates, target - candidates[i], combine, list, i + 1, visit);
                visit[i] = false;
                combine.RemoveAt(combine.Count - 1);
            }
        }
    }
}