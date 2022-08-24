using System;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 221. 最大正方形 | 难度：中等 | 标签：数组、动态规划、矩阵
    /// 在一个由 '0' 和 '1' 组成的二维矩阵内，找到只包含 '1' 的最大正方形，并返回其面积。
    /// 
    /// 示例 1：
    /// 输入：matrix = [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
    /// 输出：4
    /// 
    /// 示例 2：
    /// 输入：matrix = [["0","1"],["1","0"]]
    /// 输出：1
    /// 
    /// 示例 3：
    /// 输入：matrix = [["0"]]
    /// 输出：0
    /// 
    /// 提示：
    /// m == matrix.length
    /// n == matrix[i].length
    /// 1 <= m, n <= 300
    /// matrix[i][j] 为 '0' 或 '1'
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/maximal-square
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution221
    {
        /// <summary>
        /// 执行用时：148 ms, 在所有 C# 提交中击败了 36.04% 的用户
        /// 内存消耗：58.4 MB, 在所有 C# 提交中击败了 42.34% 的用户
        /// 通过测试用例：77 / 77
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalSquare(char[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var preSum = new int[m + 1, n + 1];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    preSum[i + 1, j + 1] = preSum[i + 1, j] + preSum[i, j + 1] - preSum[i, j] + matrix[i][j] - '0';
                }
            }

            var r = Math.Min(m, n);
            var res = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int c = res + 1; c <= r; c++)
                    {
                        if (i + c - 1 < m && j + c - 1 < n && SumRegion(preSum, i, j, i + c - 1, j + c - 1) == c * c)
                            res += 1;
                        else break;
                    }
                }
            }

            return res * res;
        }

        private int SumRegion(int[,] preSum, int r1, int c1, int r2, int c2)
        {
            return preSum[r2 + 1, c2 + 1] - preSum[r2 + 1, c1] - preSum[r1, c2 + 1] + preSum[r1, c1];
        }
    }
}