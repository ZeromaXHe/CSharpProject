using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from801to1000
{
    /// <summary>
    /// 847. 访问所有节点的最短路径 | 难度：困难 | 标签：位运算、广度优先搜索、图、动态规划、状态压缩
    /// 存在一个由 n 个节点组成的无向连通图，图中的节点按从 0 到 n - 1 编号。
    /// 
    /// 给你一个数组 graph 表示这个图。其中，graph[i] 是一个列表，由所有与节点 i 直接相连的节点组成。
    /// 
    /// 返回能够访问所有节点的最短路径的长度。你可以在任一节点开始和停止，也可以多次重访节点，并且可以重用边。
    /// 
    /// 示例 1：
    /// 输入：graph = [[1,2,3],[0],[0],[0]]
    /// 输出：4
    /// 解释：一种可能的路径为 [1,0,2,0,3]
    /// 
    /// 示例 2：
    /// 输入：graph = [[1],[0,2,4],[1,3,4],[2],[1,2]]
    /// 输出：4
    /// 解释：一种可能的路径为 [0,1,4,2,3]
    /// 
    /// 提示：
    /// n == graph.length
    /// 1 <= n <= 12
    /// 0 <= graph[i].length < n
    /// graph[i] 不包含 i
    /// 如果 graph[a] 包含 b ，那么 graph[b] 也包含 a
    /// 输入的图总是连通图
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/shortest-path-visiting-all-nodes
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution847
    {
        /// <summary>
        /// 执行用时：92 ms, 在所有 C# 提交中击败了 50.00% 的用户
        /// 内存消耗：41.8 MB, 在所有 C# 提交中击败了 27.27% 的用户
        /// 通过测试用例：51 / 51
        ///
        /// 题解 cv
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public int ShortestPathLength(int[][] graph)
        {
            int n = graph.Length;
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            bool[,] seen = new bool[n, 1 << n];
            for (int i = 0; i < n; ++i)
            {
                queue.Enqueue(new Tuple<int, int, int>(i, 1 << i, 0));
                seen[i, 1 << i] = true;
            }

            int ans = 0;
            while (queue.Count > 0)
            {
                Tuple<int, int, int> tuple = queue.Dequeue();
                // u 表示当前位于的节点编号；
                // mask 是一个长度为 n 的二进制数，表示每一个节点是否经过。
                // 如果 mask 的第 i 位是 1，则表示节点 i 已经过，否则表示节点 i 未经过；
                // dist 表示到当前节点为止经过的路径长度。
                int u = tuple.Item1, mask = tuple.Item2, dist = tuple.Item3;
                if (mask == (1 << n) - 1)
                {
                    ans = dist;
                    break;
                }

                // 搜索相邻的节点
                foreach (int v in graph[u])
                {
                    // 将 mask 的第 v 位置为 1
                    int maskV = mask | (1 << v);
                    if (!seen[v, maskV])
                    {
                        queue.Enqueue(new Tuple<int, int, int>(v, maskV, dist + 1));
                        seen[v, maskV] = true;
                    }
                }
            }

            return ans;
        }
    }
}