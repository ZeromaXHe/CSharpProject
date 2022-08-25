namespace ConsoleApplicationLeetCodeSolutions.from1801to2000
{
    /// <summary>
    /// 1901. 寻找峰值 II | 难度：中等 | 标签：数组、二分查找、矩阵
    /// 一个 2D 网格中的 峰值 是指那些 严格大于 其相邻格子(上、下、左、右)的元素。
    /// 
    /// 给你一个 从 0 开始编号 的 m x n 矩阵 mat ，其中任意两个相邻格子的值都 不相同 。找出 任意一个 峰值 mat[i][j] 并 返回其位置 [i,j] 。
    /// 
    /// 你可以假设整个矩阵周边环绕着一圈值为 -1 的格子。
    /// 
    /// 要求必须写出时间复杂度为 O(m log(n)) 或 O(n log(m)) 的算法
    /// 
    /// 示例 1:
    /// 输入: mat = [[1,4],[3,2]]
    /// 输出: [0,1]
    /// 解释: 3 和 4 都是峰值，所以[1,0]和[0,1]都是可接受的答案。
    /// 
    /// 示例 2:
    /// 输入: mat = [[10,20,15],[21,30,14],[7,16,32]]
    /// 输出: [1,1]
    /// 解释: 30 和 32 都是峰值，所以[1,1]和[2,2]都是可接受的答案。
    /// 
    /// 提示：
    /// m == mat.length
    /// n == mat[i].length
    /// 1 <= m, n <= 500
    /// 1 <= mat[i][j] <= 105
    /// 任意两个相邻元素均不相等.
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/find-a-peak-element-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1901
    {
        /// <summary>
        /// 执行用时：300 ms, 在所有 C# 提交中击败了 50.00% 的用户
        /// 内存消耗：71.4 MB, 在所有 C# 提交中击败了 91.67% 的用户
        /// 通过测试用例：48 / 48
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[] FindPeakGrid(int[][] mat)
        {
            var m = mat.Length;
            var n = mat[0].Length;
            var result = new int[2];
            var found = false;
            while (!found)
            {
                var i = result[0];
                var j = result[1];
                if (result[0] > 0 && mat[result[0] - 1][result[1]] > mat[i][j])
                {
                    i = result[0] - 1;
                }

                if (result[0] < m - 1 && mat[result[0] + 1][result[1]] > mat[i][j])
                {
                    i = result[0] + 1;
                }

                if (result[1] > 0 && mat[result[0]][result[1] - 1] > mat[i][j])
                {
                    i = result[0];
                    j = result[1] - 1;
                }

                if (result[1] < n - 1 && mat[result[0]][result[1] + 1] > mat[i][j])
                {
                    i = result[0];
                    j = result[1] + 1;
                }

                if (i == result[0] && j == result[1]) found = true;
                result[0] = i;
                result[1] = j;
            }

            return result;
        }

        /// <summary>
        /// 执行用时：348 ms, 在所有 C# 提交中击败了 8.33% 的用户
        /// 内存消耗：71.8 MB, 在所有 C# 提交中击败了 25.00% 的用户
        /// 通过测试用例：48 / 48
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[] FindPeakGrid_BinarySearch(int[][] mat)
        {
            var l = 0;
            var r = mat[0].Length - 1;
            var res = new int[2];
            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var idx = 0;
                for (int i = 1; i < mat.Length; i++)
                {
                    if (mat[i][mid] > mat[idx][mid]) idx = i;
                }

                if (mid > 0 && mat[idx][mid - 1] > mat[idx][mid]) r = mid - 1;
                else if (mid + 1 < mat[0].Length && mat[idx][mid + 1] > mat[idx][mid]) l = mid + 1;
                else
                {
                    res = new[] {idx, mid};
                    break;
                }
            }

            return res;
        }
    }
}