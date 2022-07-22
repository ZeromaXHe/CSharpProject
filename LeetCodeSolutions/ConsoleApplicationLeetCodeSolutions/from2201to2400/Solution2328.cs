using System;

namespace ConsoleApplicationLeetCodeSolutions.from2201to2400
{
    /// <summary>
    /// 2328. 网格图中递增路径的数目 | 难度：困难 | 标签：深度优先搜索、广度优先搜索、图、拓扑排序、记忆化搜索、数组、动态规划、矩阵
    /// 给你一个 m x n 的整数网格图 grid ，你可以从一个格子移动到 4 个方向相邻的任意一个格子。
    /// 
    /// 请你返回在网格图中从 任意 格子出发，达到 任意 格子，且路径中的数字是 严格递增 的路径数目。由于答案可能会很大，请将结果对 109 + 7 取余 后返回。
    /// 
    /// 如果两条路径中访问过的格子不是完全相同的，那么它们视为两条不同的路径。
    /// 
    /// 示例 1：
    /// 输入：grid = [[1,1],[3,4]]
    /// 输出：8
    /// 解释：严格递增路径包括：
    /// - 长度为 1 的路径：[1]，[1]，[3]，[4] 。
    /// - 长度为 2 的路径：[1 -> 3]，[1 -> 4]，[3 -> 4] 。
    /// - 长度为 3 的路径：[1 -> 3 -> 4] 。
    /// 路径数目为 4 + 3 + 1 = 8 。
    /// 
    /// 示例 2：
    /// 输入：grid = [[1],[2]]
    /// 输出：3
    /// 解释：严格递增路径包括：
    /// - 长度为 1 的路径：[1]，[2] 。
    /// - 长度为 2 的路径：[1 -> 2] 。
    /// 路径数目为 2 + 1 = 3 。
    /// 
    /// 提示：
    /// m == grid.length
    /// n == grid[i].length
    /// 1 <= m, n <= 1000
    /// 1 <= m * n <= 105
    /// 1 <= grid[i][j] <= 105
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/number-of-increasing-paths-in-a-grid
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution2328
    {
        private static readonly int MOD = (int) 1e9 + 7;
        private static int[,] DIRS = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};
        private int m, n;
        private int[][] grid;
        private int[,] dp;

        /// <summary>
        /// 执行用时：260 ms, 在所有 C# 提交中击败了 80.00% 的用户
        /// 内存消耗：54.4 MB, 在所有 C# 提交中击败了 60.00% 的用户
        /// 通过测试用例：36 / 36
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int CountPaths(int[][] grid)
        {
            m = grid.Length;
            n = grid[0].Length;
            this.grid = grid;
            dp = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dp[i, j] = -1;
                }
            }

            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    count = (count + dfs(i, j)) % MOD;
                }
            }

            return count;
        }

        private int dfs(int i, int j)
        {
            if (dp[i, j] != -1) return dp[i, j];
            int res = 1;
            for (int k = 0; k < DIRS.GetLength(0); k++)
            {
                int x = i + DIRS[k, 0], y = j + DIRS[k, 1];
                if (0 <= x && x < m && 0 <= y && y < n && grid[x][y] > grid[i][j])
                {
                    res = (res + dfs(x, y)) % MOD;
                }
            }

            return dp[i, j] = res;
        }

        public void Test()
        {
            var grid = new int[2][];
            grid[0] = new[] {1, 1};
            grid[1] = new[] {3, 4};
            Console.WriteLine(CountPaths(grid));
            var grid2 = new int[1][];
            grid2[0] = new[]
            {
                12469, 18741, 68716, 30594, 65029, 44019, 92944, 84784, 92781, 5655, 43120, 81333, 54113, 88220, 23446,
                6129, 2904, 48677, 20506, 79604, 82841, 3938, 46511, 60870, 10825, 31759, 78612, 19776, 43160, 86915,
                74498, 38366, 28228, 23687, 40729, 42613, 61154, 22726, 51028, 45603, 53586, 44657, 97573, 61067, 27187,
                4619, 6135, 24668, 69634, 24564, 30255, 51939, 67573, 87012, 4106, 76312, 28737, 7704, 35798
            };
            Console.WriteLine(CountPaths(grid2));
        }
    }
}