using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1401to1600
{
    /// <summary>
    /// 1466. 重新规划路线 | 难度：中等 | 标签：深度优先搜索、广度优先搜索、图
    /// n 座城市，从 0 到 n-1 编号，其间共有 n-1 条路线。因此，要想在两座不同城市之间旅行只有唯一一条路线可供选择（路线网形成一颗树）。去年，交通运输部决定重新规划路线，以改变交通拥堵的状况。
    /// 
    /// 路线用 connections 表示，其中 connections[i] = [a, b] 表示从城市 a 到 b 的一条有向路线。
    /// 
    /// 今年，城市 0 将会举办一场大型比赛，很多游客都想前往城市 0 。
    /// 
    /// 请你帮助重新规划路线方向，使每个城市都可以访问城市 0 。返回需要变更方向的最小路线数。
    /// 
    /// 题目数据 保证 每个城市在重新规划路线方向后都能到达城市 0 。
    /// 
    /// 示例 1：
    /// 输入：n = 6, connections = [[0,1],[1,3],[2,3],[4,0],[4,5]]
    /// 输出：3
    /// 解释：更改以红色显示的路线的方向，使每个城市都可以到达城市 0 。
    /// 
    /// 示例 2：
    /// 输入：n = 5, connections = [[1,0],[1,2],[3,2],[3,4]]
    /// 输出：2
    /// 解释：更改以红色显示的路线的方向，使每个城市都可以到达城市 0 。
    /// 
    /// 示例 3：
    /// 输入：n = 3, connections = [[1,0],[2,0]]
    /// 输出：0
    /// 
    /// 提示：
    /// 2 <= n <= 5 * 10^4
    /// connections.length == n-1
    /// connections[i].length == 2
    /// 0 <= connections[i][0], connections[i][1] <= n-1
    /// connections[i][0] != connections[i][1]
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1466
    {
        /// <summary>
        /// 执行用时：372 ms, 在所有 C# 提交中击败了 37.50% 的用户
        /// 内存消耗：81.2 MB, 在所有 C# 提交中击败了 12.50% 的用户
        /// 通过测试用例：76 / 76
        /// </summary>
        /// <param name="n"></param>
        /// <param name="connections"></param>
        /// <returns></returns>
        public int MinReorder(int n, int[][] connections)
        {
            var fromToMap = new Dictionary<int, HashSet<int>>();
            var toFromMap = new Dictionary<int, HashSet<int>>();
            foreach (var c in connections)
            {
                if (!fromToMap.ContainsKey(c[0])) fromToMap[c[0]] = new HashSet<int>();
                fromToMap[c[0]].Add(c[1]);
                if (!toFromMap.ContainsKey(c[1])) toFromMap[c[1]] = new HashSet<int>();
                toFromMap[c[1]].Add(c[0]);
            }

            var visit = new bool[n];
            visit[0] = true;
            var queue = new Queue<int>();
            queue.Enqueue(0);
            var result = 0;
            while (queue.Count > 0)
            {
                var c = queue.Count;
                while (c > 0)
                {
                    var deq = queue.Dequeue();
                    if (fromToMap.ContainsKey(deq))
                    {
                        foreach (var to in fromToMap[deq])
                        {
                            if (!visit[to])
                            {
                                queue.Enqueue(to);
                                visit[to] = true;
                                result++;
                            }
                        }
                    }

                    if (toFromMap.ContainsKey(deq))
                    {
                        foreach (var from in toFromMap[deq])
                        {
                            if (!visit[from])
                            {
                                queue.Enqueue(from);
                                visit[from] = true;
                            }
                        }
                    }

                    c--;
                }
            }

            return result;
        }
    }
}