namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 304. 二维区域和检索 - 矩阵不可变 | 难度：中等 | 标签：设计、数组、矩阵、前缀和
    /// 给定一个二维矩阵 matrix，以下类型的多个请求：
    /// 
    /// 计算其子矩形范围内元素的总和，该子矩阵的 左上角 为 (row1, col1) ，右下角 为 (row2, col2) 。
    /// 实现 NumMatrix 类：
    /// 
    /// NumMatrix(int[][] matrix) 给定整数矩阵 matrix 进行初始化
    /// int sumRegion(int row1, int col1, int row2, int col2) 返回 左上角 (row1, col1) 、右下角 (row2, col2) 所描述的子矩阵的元素 总和 。
    /// 
    /// 示例 1：
    /// 输入: 
    /// ["NumMatrix","sumRegion","sumRegion","sumRegion"]
    /// [[[[3,0,1,4,2],[5,6,3,2,1],[1,2,0,1,5],[4,1,0,1,7],[1,0,3,0,5]]],[2,1,4,3],[1,1,2,2],[1,2,2,4]]
    /// 输出: 
    /// [null, 8, 11, 12]
    /// 
    /// 解释:
    /// NumMatrix numMatrix = new NumMatrix([[3,0,1,4,2],[5,6,3,2,1],[1,2,0,1,5],[4,1,0,1,7],[1,0,3,0,5]]);
    /// numMatrix.sumRegion(2, 1, 4, 3); // return 8 (红色矩形框的元素总和)
    /// numMatrix.sumRegion(1, 1, 2, 2); // return 11 (绿色矩形框的元素总和)
    /// numMatrix.sumRegion(1, 2, 2, 4); // return 12 (蓝色矩形框的元素总和)
    /// 
    /// 提示：
    /// m == matrix.length
    /// n == matrix[i].length
    /// 1 <= m, n <= 200
    /// -105 <= matrix[i][j] <= 105
    /// 0 <= row1 <= row2 < m
    /// 0 <= col1 <= col2 < n
    /// 最多调用 104 次 sumRegion 方法
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/range-sum-query-2d-immutable
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution304
    {
        /// <summary>
        /// 执行用时：972 ms, 在所有 C# 提交中击败了 54.55% 的用户
        /// 内存消耗：100.6 MB, 在所有 C# 提交中击败了 9.09% 的用户
        /// 通过测试用例：22 / 22
        /// </summary>
        public class NumMatrix
        {
            private int[,] preSum;

            public NumMatrix(int[][] matrix)
            {
                preSum = new int[matrix.Length + 1, matrix[0].Length + 1];
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        preSum[i + 1, j + 1] = preSum[i + 1, j] + preSum[i, j + 1] - preSum[i, j] + matrix[i][j];
                    }
                }
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                return preSum[row2 + 1, col2 + 1] - preSum[row2 + 1, col1] - preSum[row1, col2 + 1] +
                       preSum[row1, col1];
            }
        }

        /**
         * Your NumMatrix object will be instantiated and called as such:
         * NumMatrix obj = new NumMatrix(matrix);
         * int param_1 = obj.SumRegion(row1,col1,row2,col2);
         */
    }
}