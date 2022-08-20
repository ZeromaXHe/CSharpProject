using System;

namespace ConsoleApplicationLeetCodeSolutions.from801to1000
{
    /// <summary>
    /// 931. 下降路径最小和 | 难度：中等 | 标签：数组、动态规划、矩阵
    /// 给你一个 n x n 的 方形 整数数组 matrix ，请你找出并返回通过 matrix 的下降路径 的 最小和 。
    /// 
    /// 下降路径 可以从第一行中的任何元素开始，并从每一行中选择一个元素。在下一行选择的元素和当前行所选元素最多相隔一列（即位于正下方或者沿对角线向左或者向右的第一个元素）。具体来说，位置 (row, col) 的下一个元素应当是 (row + 1, col - 1)、(row + 1, col) 或者 (row + 1, col + 1) 。
    /// 
    /// 示例 1：
    /// 输入：matrix = [[2,1,3],[6,5,4],[7,8,9]]
    /// 输出：13
    /// 解释：如图所示，为和最小的两条下降路径
    /// 
    /// 示例 2：
    /// 输入：matrix = [[-19,57],[-40,-5]]
    /// 输出：-59
    /// 解释：如图所示，为和最小的下降路径
    /// 
    /// 提示：
    /// n == matrix.length == matrix[i].length
    /// 1 <= n <= 100
    /// -100 <= matrix[i][j] <= 100
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/minimum-falling-path-sum
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution931
    {
        /// <summary>
        /// 执行用时：96 ms, 在所有 C# 提交中击败了 33.33% 的用户
        /// 内存消耗：40.6 MB, 在所有 C# 提交中击败了 86.27% 的用户
        /// 通过测试用例：49 / 49
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MinFallingPathSum(int[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var dp = new int[n, 2];
            var min = int.MaxValue;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var now = i % 2;
                    var pre = (i + 1) % 2;
                    dp[j, now] = dp[j, pre];
                    if (j - 1 >= 0 && dp[j - 1, pre] < dp[j, now]) dp[j, now] = dp[j - 1, pre];
                    if (j + 1 < n && dp[j + 1, pre] < dp[j, now]) dp[j, now] = dp[j + 1, pre];
                    dp[j, now] += matrix[i][j];
                    if (i == m - 1 && dp[j, now] < min) min = dp[j, now];
                }
            }

            return min;
        }
    }
}