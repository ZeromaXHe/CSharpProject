using System;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 5. 最长回文子串 | 难度：中等 | 标签：字符串、动态规划
    /// 给你一个字符串 s，找到 s 中最长的回文子串。
    /// 
    /// 示例 1：
    /// 输入：s = "babad"
    /// 输出："bab"
    /// 解释："aba" 同样是符合题意的答案。
    /// 
    /// 示例 2：
    /// 输入：s = "cbbd"
    /// 输出："bb"
    /// 
    /// 提示：
    /// 1 <= s.length <= 1000
    /// s 仅由数字和英文字母组成
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/longest-palindromic-substring
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution5
    {
        /// <summary>
        /// 执行用时：96 ms, 在所有 C# 提交中击败了 65.96% 的用户
        /// 内存消耗：37.1 MB, 在所有 C# 提交中击败了 80.12% 的用户
        /// 通过测试用例：180 / 180
        ///
        /// 中心扩展法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            if (s.Length == 1) return s;
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len = Math.Max(ExpandAroundCenter(s, i, i), ExpandAroundCenter(s, i, i + 1));
                if (len > end + 1 - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end + 1 - start);
        }

        private int ExpandAroundCenter(string s, int l, int r)
        {
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }

            return r - l - 1;
        }

        public void Test()
        {
            Console.WriteLine(LongestPalindrome("babad"));
        }
    }
}