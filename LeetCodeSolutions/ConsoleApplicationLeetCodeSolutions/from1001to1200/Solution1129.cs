using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1001to1200
{
    /// <summary>
    /// 1129. 颜色交替的最短路径 | 难度：中等 | 标签：广度优先搜索、图
    /// 在一个有向图中，节点分别标记为 0, 1, ..., n-1。图中每条边为红色或者蓝色，且存在自环或平行边。
    /// 
    /// red_edges 中的每一个 [i, j] 对表示从节点 i 到节点 j 的红色有向边。类似地，blue_edges 中的每一个 [i, j] 对表示从节点 i 到节点 j 的蓝色有向边。
    /// 
    /// 返回长度为 n 的数组 answer，其中 answer[X] 是从节点 0 到节点 X 的红色边和蓝色边交替出现的最短路径的长度。如果不存在这样的路径，那么 answer[x] = -1。
    /// 
    /// 示例 1：
    /// 输入：n = 3, red_edges = [[0,1],[1,2]], blue_edges = []
    /// 输出：[0,1,-1]
    /// 
    /// 示例 2：
    /// 输入：n = 3, red_edges = [[0,1]], blue_edges = [[2,1]]
    /// 输出：[0,1,-1]
    /// 
    /// 示例 3：
    /// 输入：n = 3, red_edges = [[1,0]], blue_edges = [[2,1]]
    /// 输出：[0,-1,-1]
    /// 
    /// 示例 4：
    /// 输入：n = 3, red_edges = [[0,1]], blue_edges = [[1,2]]
    /// 输出：[0,1,2]
    /// 
    /// 示例 5：
    /// 输入：n = 3, red_edges = [[0,1],[0,2]], blue_edges = [[1,0]]
    /// 输出：[0,1,1]
    /// 
    /// 提示：
    /// 1 <= n <= 100
    /// red_edges.length <= 400
    /// blue_edges.length <= 400
    /// red_edges[i].length == blue_edges[i].length == 2
    /// 0 <= red_edges[i][j], blue_edges[i][j] < n
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/shortest-path-with-alternating-colors
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1129
    {
        /// <summary>
        /// 执行用时：156 ms, 在所有 C# 提交中击败了 33.33% 的用户
        /// 内存消耗：46 MB, 在所有 C# 提交中击败了 33.33% 的用户
        /// 通过测试用例：90 / 90
        /// </summary>
        /// <param name="n"></param>
        /// <param name="redEdges"></param>
        /// <param name="blueEdges"></param>
        /// <returns></returns>
        public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
        {
            var redMap = new Dictionary<int, List<int>>();
            var blueMap = new Dictionary<int, List<int>>();
            foreach (var redEdge in redEdges)
            {
                if (redEdge[1] == 0) continue;
                if (!redMap.ContainsKey(redEdge[0]))
                {
                    redMap[redEdge[0]] = new List<int>();
                }

                redMap[redEdge[0]].Add(redEdge[1]);
            }

            foreach (var blueEdge in blueEdges)
            {
                if (blueEdge[1] == 0) continue;
                if (!blueMap.ContainsKey(blueEdge[0]))
                {
                    blueMap[blueEdge[0]] = new List<int>();
                }

                blueMap[blueEdge[0]].Add(blueEdge[1]);
            }

            var result = new int[n];
            for (int i = 1; i < n; i++)
            {
                result[i] = -1;
            }

            var queue = new Queue<int>();
            if (redMap.ContainsKey(0))
            {
                foreach (var red in redMap[0])
                {
                    queue.Enqueue(red);
                }
            }

            if (blueMap.ContainsKey(0))
            {
                foreach (var blue in blueMap[0])
                {
                    queue.Enqueue(-blue);
                }
            }

            var visitRed = new bool[n];
            var visitBlue = new bool[n];
            var dist = 1;
            while (queue.Count > 0)
            {
                var c = queue.Count;
                while (c > 0)
                {
                    var deq = queue.Dequeue();
                    c--;
                    if (deq < 0)
                    {
                        if (visitBlue[-deq]) continue;
                        if (redMap.ContainsKey(-deq))
                        {
                            foreach (var next in redMap[-deq])
                            {
                                if (!visitRed[next]) queue.Enqueue(next);
                            }
                        }

                        if (result[-deq] == -1 || result[-deq] > dist) result[-deq] = dist;
                        visitBlue[-deq] = true;
                    }
                    else
                    {
                        if (visitRed[deq]) continue;
                        if (blueMap.ContainsKey(deq))
                        {
                            foreach (var next in blueMap[deq])
                            {
                                if (!visitBlue[next]) queue.Enqueue(-next);
                            }
                        }

                        if (result[deq] == -1 || result[deq] > dist) result[deq] = dist;
                        visitRed[deq] = true;
                    }
                }

                dist++;
            }

            return result;
        }
    }
}