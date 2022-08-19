using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 17. 电话号码的字母组合 | 难度：中等 | 标签：哈希表、字符串、回溯
    /// 给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。答案可以按 任意顺序 返回。
    /// 
    /// 给出数字到字母的映射如下（与电话按键相同）。注意 1 不对应任何字母。
    /// 
    /// 示例 1：
    /// 输入：digits = "23"
    /// 输出：["ad","ae","af","bd","be","bf","cd","ce","cf"]
    /// 
    /// 示例 2：
    /// 输入：digits = ""
    /// 输出：[]
    /// 
    /// 示例 3：
    /// 输入：digits = "2"
    /// 输出：["a","b","c"]
    /// 
    /// 提示：
    /// 0 <= digits.length <= 4
    /// digits[i] 是范围 ['2', '9'] 的一个数字。
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/letter-combinations-of-a-phone-number
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution17
    {
        private string[] map = {"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};

        /// <summary>
        /// 执行用时：128 ms, 在所有 C# 提交中击败了 87.87% 的用户
        /// 内存消耗：42.7 MB, 在所有 C# 提交中击败了 65.22% 的用户
        /// 通过测试用例：25 / 25
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            var sb = new StringBuilder();
            Backtrack(sb, digits, 0, result);
            return result;
        }

        private void Backtrack(StringBuilder sb, string digits, int i, List<string> result)
        {
            if (i == digits.Length)
            {
                if (sb.Length > 0) result.Add(sb.ToString());
                return;
            }

            var choices = map[digits[i] - '2'];
            for (int j = 0; j < choices.Length; j++)
            {
                sb.Append(choices[j]);
                Backtrack(sb, digits, i + 1, result);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}