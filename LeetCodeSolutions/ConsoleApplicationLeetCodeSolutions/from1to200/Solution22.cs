using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 22. 括号生成 | 难度：中等 | 标签：字符串、动态规划、回溯
    /// 数字 n 代表生成括号的对数，请你设计一个函数，用于能够生成所有可能的并且 有效的 括号组合。
    /// 
    /// 示例 1：
    /// 输入：n = 3
    /// 输出：["((()))","(()())","(())()","()(())","()()()"]
    /// 
    /// 示例 2：
    /// 输入：n = 1
    /// 输出：["()"]
    /// 
    /// 提示：
    /// 1 <= n <= 8
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/generate-parentheses
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution22
    {
        /// <summary>
        /// 执行用时：140 ms, 在所有 C# 提交中击败了 15.54% 的用户
        /// 内存消耗：44.5 MB, 在所有 C# 提交中击败了 81.07% 的用户
        /// 通过测试用例：8 / 8
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            var sb = new StringBuilder();
            Backtrack(sb, 0, 0, n, result);
            return result;
        }

        private void Backtrack(StringBuilder sb, int left, int right, int n, List<string> result)
        {
            if (left + right == 2 * n)
            {
                result.Add(sb.ToString());
                return;
            }

            if (left < n)
            {
                sb.Append('(');
                Backtrack(sb, left + 1, right, n, result);
                sb.Remove(sb.Length - 1, 1);
            }

            if (right < left)
            {
                sb.Append(')');
                Backtrack(sb, left, right + 1, n, result);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}