﻿namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 240. 搜索二维矩阵 II | 难度：中等 | 标签：数组、二分查找、分治、矩阵
    /// 编写一个高效的算法来搜索 m x n 矩阵 matrix 中的一个目标值 target 。该矩阵具有以下特性：
    /// 
    /// 每行的元素从左到右升序排列。
    /// 每列的元素从上到下升序排列。
    /// 
    /// 示例 1：
    /// 输入：matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]], target = 5
    /// 输出：true
    /// 
    /// 示例 2：
    /// 输入：matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]], target = 20
    /// 输出：false
    /// 
    /// 提示：
    /// m == matrix.length
    /// n == matrix[i].length
    /// 1 <= n, m <= 300
    /// -109 <= matrix[i][j] <= 109
    /// 每行的所有元素从左到右升序排列
    /// 每列的所有元素从上到下升序排列
    /// -109 <= target <= 109
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/search-a-2d-matrix-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution240
    {
        /// <summary>
        /// 执行用时：124 ms, 在所有 C# 提交中击败了 68.45% 的用户
        /// 内存消耗：61.7 MB, 在所有 C# 提交中击败了 24.60% 的用户
        /// 通过测试用例：129 / 129
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            var i = matrix.Length - 1;
            var j = 0;
            while (j < matrix[0].Length && i >= 0)
            {
                if (matrix[i][j] == target) return true;
                if (matrix[i][j] < target) j++;
                else i--;
            }

            return false;
        }
    }
}