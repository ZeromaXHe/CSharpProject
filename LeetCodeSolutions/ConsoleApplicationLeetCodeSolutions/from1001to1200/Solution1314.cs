namespace ConsoleApplicationLeetCodeSolutions.from1001to1200
{
    /// <summary>
    /// 1314. 矩阵区域和 | 难度：中等 | 标签：数组、矩阵、前缀和
    /// 给你一个 m x n 的矩阵 mat 和一个整数 k ，请你返回一个矩阵 answer ，其中每个 answer[i][j] 是所有满足下述条件的元素 mat[r][c] 的和： 
    /// 
    /// i - k <= r <= i + k,
    /// j - k <= c <= j + k 且
    /// (r, c) 在矩阵内。
    /// 
    /// 示例 1：
    /// 输入：mat = [[1,2,3],[4,5,6],[7,8,9]], k = 1
    /// 输出：[[12,21,16],[27,45,33],[24,39,28]]
    /// 
    /// 示例 2：
    /// 输入：mat = [[1,2,3],[4,5,6],[7,8,9]], k = 2
    /// 输出：[[45,45,45],[45,45,45],[45,45,45]]
    /// 
    /// 提示：
    /// m == mat.length
    /// n == mat[i].length
    /// 1 <= m, n, k <= 100
    /// 1 <= mat[i][j] <= 100
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/matrix-block-sum
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1314
    {
        /// <summary>
        /// 执行用时：136 ms, 在所有 C# 提交中击败了 88.24% 的用户
        /// 内存消耗：46.4 MB, 在所有 C# 提交中击败了 41.18% 的用户
        /// 通过测试用例：12 / 12
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] MatrixBlockSum(int[][] mat, int k)
        {
            int m = mat.Length;
            int n = mat[0].Length;
            int[,] preSum = new int[m + 1, n + 1];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    preSum[i + 1, j + 1] = preSum[i + 1, j] + preSum[i, j + 1] - preSum[i, j] + mat[i][j];
                }
            }

            int[][] result = new int[m][];
            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    result[i][j] = SumRegion(preSum, m, n, i - k, j - k, i + k, j + k);
                }
            }

            return result;
        }

        private int SumRegion(int[,] preSum, int m, int n, int row1, int col1, int row2, int col2)
        {
            if (row1 < 0) row1 = 0;
            if (col1 < 0) col1 = 0;
            if (row2 >= m) row2 = m - 1;
            if (col2 >= n) col2 = n - 1;
            return preSum[row2 + 1, col2 + 1] - preSum[row2 + 1, col1] - preSum[row1, col2 + 1] +
                   preSum[row1, col1];
        }
    }
}