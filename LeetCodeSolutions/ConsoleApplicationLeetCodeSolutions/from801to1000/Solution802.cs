﻿using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplicationLeetCodeSolutions.from801to1000
{
    /// <summary>
    /// 802. 找到最终的安全状态 | 难度：中等 | 标签：
    /// 有一个有 n 个节点的有向图，节点按 0 到 n - 1 编号。图由一个 索引从 0 开始 的 2D 整数数组 graph表示， graph[i]是与节点 i 相邻的节点的整数数组，这意味着从节点 i 到 graph[i]中的每个节点都有一条边。
    /// 
    /// 如果一个节点没有连出的有向边，则它是 终端节点 。如果没有出边，则节点为终端节点。如果从该节点开始的所有可能路径都通向 终端节点 ，则该节点为 安全节点 。
    /// 
    /// 返回一个由图中所有 安全节点 组成的数组作为答案。答案数组中的元素应当按 升序 排列。
    /// 
    /// 示例 1：
    /// 输入：graph = [[1,2],[2,3],[5],[0],[5],[],[]]
    /// 输出：[2,4,5,6]
    /// 解释：示意图如上。
    /// 节点 5 和节点 6 是终端节点，因为它们都没有出边。
    /// 从节点 2、4、5 和 6 开始的所有路径都指向节点 5 或 6 。
    /// 
    /// 示例 2：
    /// 输入：graph = [[1,2,3,4],[1,2],[3,4],[0,4],[]]
    /// 输出：[4]
    /// 解释:
    /// 只有节点 4 是终端节点，从节点 4 开始的所有路径都通向节点 4 。
    /// 
    /// 提示：
    /// n == graph.length
    /// 1 <= n <= 104
    /// 0 <= graph[i].length <= n
    /// 0 <= graph[i][j] <= n - 1
    /// graph[i] 按严格递增顺序排列。
    /// 图中可能包含自环。
    /// 图中边的数目在范围 [1, 4 * 104] 内。
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/find-eventual-safe-states
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution802
    {
        /**
         * 执行用时：268 ms, 在所有 C# 提交中击败了 35.71% 的用户
         * 内存消耗：66.6 MB, 在所有 C# 提交中击败了 28.57% 的用户
         * 通过测试用例：112 / 112
         */
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            var safe = new int[graph.Length];
            var res = new List<int>();
            for (int i = 0; i < graph.Length; i++)
            {
                if (isSafe(graph, i, safe)) res.Add(i);
            }

            return res;
        }

        private bool isSafe(int[][] graph, int i, int[] safe)
        {
            if (safe[i] == 1) return true;
            if (safe[i] == -1) return false;
            if (graph[i].Length == 0)
            {
                safe[i] = 1;
                return true;
            }

            // 先把自己设置为不安全，防止成环
            safe[i] = -1;
            var safeBool = graph[i].All(j => isSafe(graph, j, safe));
            safe[i] = safeBool ? 1 : -1;
            return safeBool;
        }
    }
}