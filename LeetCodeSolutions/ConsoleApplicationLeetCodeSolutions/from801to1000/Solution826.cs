using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from801to1000
{
    /// <summary>
    /// 826. 安排工作以达到最大收益 | 难度：中等 | 标签：贪心、数组、双指针、二分查找、排序
    /// 你有 n 个工作和 m 个工人。给定三个数组： difficulty, profit 和 worker ，其中:
    /// 
    /// difficulty[i] 表示第 i 个工作的难度，profit[i] 表示第 i 个工作的收益。
    /// worker[i] 是第 i 个工人的能力，即该工人只能完成难度小于等于 worker[i] 的工作。
    /// 每个工人 最多 只能安排 一个 工作，但是一个工作可以 完成多次 。
    /// 
    /// 举个例子，如果 3 个工人都尝试完成一份报酬为 $1 的同样工作，那么总收益为 $3 。如果一个工人不能完成任何工作，他的收益为 $0 。
    /// 返回 在把工人分配到工作岗位后，我们所能获得的最大利润 。
    /// 
    /// 示例 1：
    /// 输入: difficulty = [2,4,6,8,10], profit = [10,20,30,40,50], worker = [4,5,6,7]
    /// 输出: 100 
    /// 解释: 工人被分配的工作难度是 [4,4,6,6] ，分别获得 [20,20,30,30] 的收益。
    /// 
    /// 示例 2:
    /// 输入: difficulty = [85,47,57], profit = [24,66,99], worker = [40,25,25]
    /// 输出: 0
    /// 
    /// 提示:
    /// n == difficulty.length
    /// n == profit.length
    /// m == worker.length
    /// 1 <= n, m <= 104
    /// 1 <= difficulty[i], profit[i], worker[i] <= 105
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/most-profit-assigning-work
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution826
    {
        /// <summary>
        /// 执行用时：132 ms, 在所有 C# 提交中击败了 85.71% 的用户
        /// 内存消耗：54.4 MB, 在所有 C# 提交中击败了 78.57% 的用户
        /// 通过测试用例：57 / 57
        /// </summary>
        /// <param name="difficulty"></param>
        /// <param name="profit"></param>
        /// <param name="worker"></param>
        /// <returns></returns>
        public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {
            var n = difficulty.Length;
            var sort = new int[n];
            for (int i = 0; i < n; i++)
            {
                sort[i] = i;
            }

            Array.Sort(sort, (i1, i2) =>
            {
                if (difficulty[i1] != difficulty[i2]) return difficulty[i1] - difficulty[i2];
                return profit[i1] - profit[i2];
            });

            Array.Sort(worker);
            var ptr = -1;
            var maxProfit = 0;
            var total = 0;
            for (int i = 0; i < worker.Length; i++)
            {
                while (ptr + 1 < n && difficulty[sort[ptr + 1]] <= worker[i])
                {
                    ptr++;
                    if (profit[sort[ptr]] > maxProfit) maxProfit = profit[sort[ptr]];
                }

                total += maxProfit;
            }

            return total;
        }
    }
}