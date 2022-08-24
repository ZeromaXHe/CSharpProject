using System;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 64. 最小路径和 | 难度：中等 | 标签：
    /// 给定一个包含非负整数的 m x n 网格 grid ，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
    /// 
    /// 说明：每次只能向下或者向右移动一步。
    /// 
    /// 示例 1：
    /// 输入：grid = [[1,3,1],[1,5,1],[4,2,1]]
    /// 输出：7
    /// 解释：因为路径 1→3→1→1→1 的总和最小。
    /// 
    /// 示例 2：
    /// 输入：grid = [[1,2,3],[4,5,6]]
    /// 输出：12
    /// 
    /// 提示：
    /// m == grid.length
    /// n == grid[i].length
    /// 1 <= m, n <= 200
    /// 0 <= grid[i][j] <= 100
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/minimum-path-sum
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution64
    {
        /// <summary>
        /// 执行用时：80 ms, 在所有 C# 提交中击败了 91.85% 的用户
        /// 内存消耗：39.1 MB, 在所有 C# 提交中击败了 98.28% 的用户
        /// 通过测试用例：61 / 61
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum(int[][] grid)
        {
            var dp = new int[grid.Length];
            dp[0] = grid[0][0];
            for (int i = 1; i < grid.Length; i++)
            {
                dp[i] = dp[i - 1] + grid[i][0];
            }

            for (int j = 1; j < grid[0].Length; j++)
            {
                dp[0] += grid[0][j];
                for (int i = 1; i < grid.Length; i++)
                {
                    dp[i] = Math.Min(dp[i - 1], dp[i]) + grid[i][j];
                }
            }

            return dp[dp.Length - 1];
        }
    }
}