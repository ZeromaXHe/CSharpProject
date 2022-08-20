using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 119. 杨辉三角 II | 难度：简单 | 标签：
    /// 给定一个非负索引 rowIndex，返回「杨辉三角」的第 rowIndex 行。
    /// 
    /// 在「杨辉三角」中，每个数是它左上方和右上方的数的和。
    /// 
    /// 示例 1:
    /// 输入: rowIndex = 3
    /// 输出: [1,3,3,1]
    /// 
    /// 示例 2:
    /// 输入: rowIndex = 0
    /// 输出: [1]
    /// 
    /// 示例 3:
    /// 输入: rowIndex = 1
    /// 输出: [1,1]
    /// 
    /// 提示:
    /// 0 <= rowIndex <= 33
    /// 
    /// 进阶：
    /// 你可以优化你的算法到 O(rowIndex) 空间复杂度吗？
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/pascals-triangle-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution119
    {
        /// <summary>
        /// 执行用时：88 ms, 在所有 C# 提交中击败了 59.82% 的用户 
        /// 内存消耗：35.2 MB, 在所有 C# 提交中击败了 44.20% 的用户
        /// 通过测试用例：34 / 34
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> GetRow(int rowIndex)
        {
            var result = new List<int> {1};
            if (rowIndex == 0) return result;
            var pre = 1L;
            for (int i = 0; i < rowIndex; i++)
            {
                pre *= rowIndex - i;
                pre /= i + 1;
                result.Add((int) pre);
            }

            return result;
        }
    }
}