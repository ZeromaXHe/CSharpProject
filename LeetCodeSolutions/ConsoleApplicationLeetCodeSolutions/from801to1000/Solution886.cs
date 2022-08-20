using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from801to1000
{
    /// <summary>
    /// 886. 可能的二分法 | 难度：中等 | 标签：深度优先搜索、广度优先搜索、并查集、图
    /// 给定一组 n 人（编号为 1, 2, ..., n）， 我们想把每个人分进任意大小的两组。每个人都可能不喜欢其他人，那么他们不应该属于同一组。
    /// 
    /// 给定整数 n 和数组 dislikes ，其中 dislikes[i] = [ai, bi] ，表示不允许将编号为 ai 和  bi的人归入同一组。当可以用这种方法将所有人分进两组时，返回 true；否则返回 false。
    /// 
    /// 示例 1：
    /// 输入：n = 4, dislikes = [[1,2],[1,3],[2,4]]
    /// 输出：true
    /// 解释：group1 [1,4], group2 [2,3]
    /// 
    /// 示例 2：
    /// 输入：n = 3, dislikes = [[1,2],[1,3],[2,3]]
    /// 输出：false
    /// 
    /// 示例 3：
    /// 输入：n = 5, dislikes = [[1,2],[2,3],[3,4],[4,5],[1,5]]
    /// 输出：false
    /// 
    /// 提示：
    /// 1 <= n <= 2000
    /// 0 <= dislikes.length <= 104
    /// dislikes[i].length == 2
    /// 1 <= dislikes[i][j] <= n
    /// ai < bi
    /// dislikes 中每一组都 不同
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/possible-bipartition
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution886
    {
        List<int>[] graph;
        int[] color;

        /// <summary>
        /// 执行用时：208 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗：65.9 MB, 在所有 C# 提交中击败了 76.92% 的用户
        /// 通过测试用例：70 / 70
        /// </summary>
        /// <param name="n"></param>
        /// <param name="dislikes"></param>
        /// <returns></returns>
        public bool PossibleBipartition(int n, int[][] dislikes)
        {
            graph = new List<int>[n + 1];
            for (int i = 1; i <= n; ++i)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in dislikes)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            color = new int[n + 1];
            for (int i = 1; i <= n; ++i)
            {
                if (color[i] == 0 && !Dfs(i, 1)) return false;
            }

            return true;
        }

        public bool Dfs(int i, int c)
        {
            if (color[i] != 0) return color[i] == c;
            color[i] = c;

            foreach (var next in graph[i])
            {
                if (!Dfs(next, c ^ 3)) return false;
            }

            return true;
        }
    }
}