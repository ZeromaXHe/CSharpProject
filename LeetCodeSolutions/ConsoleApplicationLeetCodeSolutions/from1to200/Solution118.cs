using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 118. 杨辉三角 | 难度：简单 | 标签：
    /// 给定一个非负整数 numRows，生成「杨辉三角」的前 numRows 行。
    /// 
    /// 在「杨辉三角」中，每个数是它左上方和右上方的数的和。
    /// 
    /// 示例 1:
    /// 输入: numRows = 5
    /// 输出: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]
    /// 
    /// 示例 2:
    /// 输入: numRows = 1
    /// 输出: [[1]]
    /// 
    /// 提示:
    /// 1 <= numRows <= 30
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/pascals-triangle
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution118
    {
        /// <summary>
        /// 执行用时：92 ms, 在所有 C# 提交中击败了 48.86% 的用户
        /// 内存消耗：35.6 MB, 在所有 C# 提交中击败了 33.52% 的用户
        /// 通过测试用例：14 / 14
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>> {new List<int> {1}};
            if (numRows == 1) return result;
            var pre = new List<int> {1, 1};
            result.Add(pre);
            if (numRows == 2) return result;
            for (int i = 2; i < numRows; i++)
            {
                var num1 = -1;
                var next = new List<int> {1};
                foreach (var num2 in pre)
                {
                    if (num1 != -1) next.Add(num1 + num2);
                    num1 = num2;
                }

                next.Add(1);
                result.Add(next);
                pre = next;
            }

            return result;
        }
    }
}