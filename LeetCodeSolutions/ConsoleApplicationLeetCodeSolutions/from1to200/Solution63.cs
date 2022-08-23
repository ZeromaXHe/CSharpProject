using System;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 63. 不同路径 II | 难度：中等 | 标签：数组、动态规划、矩阵
    /// 一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为 “Start” ）。
    /// 
    /// 机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为 “Finish”）。
    /// 
    /// 现在考虑网格中有障碍物。那么从左上角到右下角将会有多少条不同的路径？
    /// 
    /// 网格中的障碍物和空位置分别用 1 和 0 来表示。
    /// 
    /// 示例 1：
    /// 输入：obstacleGrid = [[0,0,0],[0,1,0],[0,0,0]]
    /// 输出：2
    /// 解释：3x3 网格的正中间有一个障碍物。
    /// 从左上角到右下角一共有 2 条不同的路径：
    /// 1. 向右 -> 向右 -> 向下 -> 向下
    /// 2. 向下 -> 向下 -> 向右 -> 向右
    /// 
    /// 示例 2：
    /// 输入：obstacleGrid = [[0,1],[0,0]]
    /// 输出：1
    /// 
    /// 提示：
    /// m == obstacleGrid.length
    /// n == obstacleGrid[i].length
    /// 1 <= m, n <= 100
    /// obstacleGrid[i][j] 为 0 或 1
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/unique-paths-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution63
    {
        public void Test()
        {
            Console.WriteLine(UniquePathsWithObstacles(new[] {new[] {0, 1}, new[] {0, 0}}));
            Console.WriteLine(UniquePathsWithObstacles(new[] {new[] {0, 1}}));
        }

        /// <summary>
        /// 执行用时：84 ms, 在所有 C# 提交中击败了 53.12% 的用户
        /// 内存消耗：37.8 MB, 在所有 C# 提交中击败了 8.59% 的用户
        /// 通过测试用例：41 / 41
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var m = obstacleGrid.Length;
            var n = obstacleGrid[0].Length;
            var dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (obstacleGrid[0][i] == 1) break;
                dp[i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 1) dp[j] = 0;
                    else if (j > 0 && obstacleGrid[i][j - 1] == 0) dp[j] += dp[j - 1];
                }
            }

            return dp[n - 1];
        }
    }
}