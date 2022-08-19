using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 438. 找到字符串中所有字母异位词 | 难度：中等 | 标签：哈希表、字符串、滑动窗口
    /// 给定两个字符串 s 和 p，找到 s 中所有 p 的 异位词 的子串，返回这些子串的起始索引。不考虑答案输出的顺序。
    /// 
    /// 异位词 指由相同字母重排列形成的字符串（包括相同的字符串）。
    /// 
    /// 示例 1:
    /// 输入: s = "cbaebabacd", p = "abc"
    /// 输出: [0,6]
    /// 解释:
    /// 起始索引等于 0 的子串是 "cba", 它是 "abc" 的异位词。
    /// 起始索引等于 6 的子串是 "bac", 它是 "abc" 的异位词。
    /// 
    /// 示例 2:
    /// 输入: s = "abab", p = "ab"
    /// 输出: [0,1,2]
    /// 解释:
    /// 起始索引等于 0 的子串是 "ab", 它是 "ab" 的异位词。
    /// 起始索引等于 1 的子串是 "ba", 它是 "ab" 的异位词。
    /// 起始索引等于 2 的子串是 "ab", 它是 "ab" 的异位词。
    /// 
    /// 提示:
    /// 1 <= s.length, p.length <= 3 * 104
    /// s 和 p 仅包含小写字母
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/find-all-anagrams-in-a-string
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution438
    {
        /// <summary>
        /// 执行用时：128 ms, 在所有 C# 提交中击败了 69.33% 的用户
        /// 内存消耗：45.7 MB, 在所有 C# 提交中击败了 68.00% 的用户
        /// 通过测试用例：61 / 61
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams(string s, string p)
        {
            var result = new List<int>();
            if (s.Length < p.Length) return result;
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < p.Length; i++)
            {
                dict[p[i]] = dict.ContainsKey(p[i]) ? dict[p[i]] + 1 : 1;
            }

            for (int i = 0; i < p.Length; i++)
            {
                var ch = s[i];
                if (dict.ContainsKey(ch) && dict[ch] == 1) dict.Remove(ch);
                else dict[ch] = dict.ContainsKey(ch) ? dict[ch] - 1 : -1;
            }

            if (dict.Count == 0) result.Add(0);
            for (int i = 0; i < s.Length - p.Length; i++)
            {
                var removeCh = s[i];
                if (dict.ContainsKey(removeCh) && dict[removeCh] == -1) dict.Remove(removeCh);
                else dict[removeCh] = dict.ContainsKey(removeCh) ? dict[removeCh] + 1 : 1;
                var addCh = s[i + p.Length];
                if (dict.ContainsKey(addCh) && dict[addCh] == 1) dict.Remove(addCh);
                else dict[addCh] = dict.ContainsKey(addCh) ? dict[addCh] - 1 : -1;
                if (dict.Count == 0) result.Add(i + 1);
            }

            return result;
        }
    }
}