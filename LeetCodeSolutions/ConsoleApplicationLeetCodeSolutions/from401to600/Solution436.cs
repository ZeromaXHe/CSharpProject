using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 436. 寻找右区间 | 难度：中等 | 标签：数组、二分查找、排序
    /// 给你一个区间数组 intervals ，其中 intervals[i] = [starti, endi] ，且每个 starti 都 不同 。
    /// 
    /// 区间 i 的 右侧区间 可以记作区间 j ，并满足 startj >= endi ，且 startj 最小化 。
    /// 
    /// 返回一个由每个区间 i 的 右侧区间 在 intervals 中对应下标组成的数组。如果某个区间 i 不存在对应的 右侧区间 ，则下标 i 处的值设为 -1 。
    /// 
    /// 示例 1：
    /// 输入：intervals = [[1,2]]
    /// 输出：[-1]
    /// 解释：集合中只有一个区间，所以输出-1。
    /// 
    /// 示例 2：
    /// 输入：intervals = [[3,4],[2,3],[1,2]]
    /// 输出：[-1,0,1]
    /// 解释：对于 [3,4] ，没有满足条件的“右侧”区间。
    /// 对于 [2,3] ，区间[3,4]具有最小的“右”起点;
    /// 对于 [1,2] ，区间[2,3]具有最小的“右”起点。
    /// 
    /// 示例 3：
    /// 输入：intervals = [[1,4],[2,3],[3,4]]
    /// 输出：[-1,2,-1]
    /// 解释：对于区间 [1,4] 和 [3,4] ，没有满足条件的“右侧”区间。
    /// 对于 [2,3] ，区间 [3,4] 有最小的“右”起点。
    /// 
    /// 提示：
    /// 1 <= intervals.length <= 2 * 104
    /// intervals[i].length == 2
    /// -106 <= starti <= endi <= 106
    /// 每个间隔的起点都 不相同
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/find-right-interval
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution436
    {
        /// <summary>
        /// 执行用时：228 ms, 在所有 C# 提交中击败了 22.13% 的用户
        /// 内存消耗：59.6 MB, 在所有 C# 提交中击败了 16.99% 的用户
        /// 通过测试用例：19 / 19
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[] FindRightInterval(int[][] intervals)
        {
            int n = intervals.Length;
            Tuple<int, int>[] startIntervals = new Tuple<int, int>[n];
            Tuple<int, int>[] endIntervals = new Tuple<int, int>[n];
            for (int i = 0; i < n; i++)
            {
                startIntervals[i] = Tuple.Create(intervals[i][0], i);
                endIntervals[i] = Tuple.Create(intervals[i][1], i);
            }

            Array.Sort(startIntervals, (o1, o2) => o1.Item1 - o2.Item1);
            Array.Sort(endIntervals, (o1, o2) => o1.Item1 - o2.Item1);

            int[] result = new int[n];
            for (int i = 0, j = 0; i < n; i++)
            {
                while (j < n && endIntervals[i].Item1 > startIntervals[j].Item1) j++;
                if (j < n) result[endIntervals[i].Item2] = startIntervals[j].Item2;
                else result[endIntervals[i].Item2] = -1;
            }

            return result;
        }
    }
}