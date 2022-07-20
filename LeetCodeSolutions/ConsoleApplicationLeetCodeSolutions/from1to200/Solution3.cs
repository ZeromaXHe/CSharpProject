using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 3. 无重复字符的最长子串 | 难度：中等 | 标签：哈希表、字符串、滑动窗口
    /// 给定一个字符串 s ，请你找出其中不含有重复字符的 最长子串 的长度。
    /// 
    /// 示例 1:
    /// 输入: s = "abcabcbb"
    /// 输出: 3 
    /// 解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
    /// 
    /// 示例 2:
    /// 输入: s = "bbbbb"
    /// 输出: 1
    /// 解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
    /// 
    /// 示例 3:
    /// 输入: s = "pwwkew"
    /// 输出: 3
    /// 解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
    /// 请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
    /// 
    /// 提示：
    /// 0 <= s.length <= 5 * 104
    /// s 由英文字母、数字、符号和空格组成
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/longest-substring-without-repeating-characters
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution3
    {
        /// <summary>
        /// 执行用时：60 ms, 在所有 C# 提交中击败了 92.05% 的用户
        /// 内存消耗：38.8 MB, 在所有 C# 提交中击败了 59.89% 的用户
        /// 通过测试用例：987 / 987
        ///
        /// 其实可以用 HashSet 的，脑子想糊涂了
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            if ("".Equals(s)) return 0;
            int l = 0;
            int r = 1;
            int max = 1;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict[s[l]] = 1;
            while (r < s.Length)
            {
                while (dict.ContainsKey(s[r]))
                {
                    if (dict[s[l]] == 1) dict.Remove(s[l]);
                    else dict[s[l]]--;
                    l++;
                }

                dict[s[r]] = 1;
                r++;
                if (r - l > max) max = r - l;
            }

            return max;
        }
    }
}