using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 139. 单词拆分 | 难度：中等 | 标签：字典树、记忆化搜索、哈希表、字符串、动态规划
    /// 给你一个字符串 s 和一个字符串列表 wordDict 作为字典。请你判断是否可以利用字典中出现的单词拼接出 s 。
    /// 
    /// 注意：不要求字典中出现的单词全部都使用，并且字典中的单词可以重复使用。
    /// 
    /// 示例 1：
    /// 输入: s = "leetcode", wordDict = ["leet", "code"]
    /// 输出: true
    /// 解释: 返回 true 因为 "leetcode" 可以由 "leet" 和 "code" 拼接成。
    /// 
    /// 示例 2：
    /// 输入: s = "applepenapple", wordDict = ["apple", "pen"]
    /// 输出: true
    /// 解释: 返回 true 因为 "applepenapple" 可以由 "apple" "pen" "apple" 拼接成。
    /// 注意，你可以重复使用字典中的单词。
    /// 
    /// 示例 3：
    /// 输入: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
    /// 输出: false
    /// 
    /// 提示：
    /// 1 <= s.length <= 300
    /// 1 <= wordDict.length <= 1000
    /// 1 <= wordDict[i].length <= 20
    /// s 和 wordDict[i] 仅有小写英文字母组成
    /// wordDict 中的所有字符串 互不相同
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/word-break
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution139
    {
        /// <summary>
        /// 执行用时：92 ms, 在所有 C# 提交中击败了 83.85% 的用户
        /// 内存消耗：41.6 MB, 在所有 C# 提交中击败了 69.27% 的用户
        /// 通过测试用例：45 / 45
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var dict = new Trie('#', false);
            dict.BuildDict(wordDict);
            var dp = new bool [s.Length + 1];
            dp[0] = true;
            for (int i = 1; i <= s.Length; ++i) 
            {
                for (int j = 0; j < i; ++j) 
                {
                    // .NET Core 2.1 和 C# 7.2 可以尝试使用字符串 Span 的原生支持：AsSpan 方法直接哈希表？
                    if (dp[j] && dict.Contains(s, j, i)) 
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }

        class Trie
        {
            public Trie(char ch, bool end)
            {
                Ch = ch;
                End = end;
            }

            public char Ch { get; }
            public bool End { get; set; }
            public Trie[] Child { get; } = new Trie[26];

            public void BuildDict(IList<string> wordDict)
            {
                var pre = this;
                foreach (var word in wordDict)
                {
                    pre = this;
                    for (var i = 0; i < word.Length; i++)
                    {
                        var idx = word[i] - 'a';
                        if (pre.Child[idx] == null) pre.Child[idx] = new Trie(word[i], false);
                        pre = pre.Child[idx];
                    }

                    pre.End = true;
                }
            }

            public bool Contains(string s, int from, int to)
            {
                var node = this;
                for (int i = from; i < to; i++)
                {
                    if (node.Child[s[i] - 'a'] == null) return false;
                    node = node.Child[s[i] - 'a'];
                }

                return node.End;
            }
        }
        
        /**
         * 超时
         * "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab"
         * ["a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"]
         */
        public bool WordBreak_Backtrack(string s, IList<string> wordDict)
        {
            var dict = new Trie('#', false);
            dict.BuildDict(wordDict);
            return Backtrack(dict, dict, s, 0);
        }

        private bool Backtrack(Trie dict, Trie pre, string s, int i)
        {
            if (i == s.Length || pre.Child[s[i] - 'a'] == null) return false;
            if (Backtrack(dict, pre.Child[s[i] - 'a'], s, i + 1)) return true;
            return pre.Child[s[i] - 'a'].End && (i == s.Length - 1 || Backtrack(dict, dict, s, i + 1));
        }
    }
}