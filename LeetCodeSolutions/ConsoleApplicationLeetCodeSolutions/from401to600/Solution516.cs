using System;

namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 516. 最长回文子序列 | 难度：中等 | 标签：字符串、动态规划
    /// 给你一个字符串 s ，找出其中最长的回文子序列，并返回该序列的长度。
    /// 
    /// 子序列定义为：不改变剩余字符顺序的情况下，删除某些字符或者不删除任何字符形成的一个序列。
    /// 
    /// 示例 1：
    /// 输入：s = "bbbab"
    /// 输出：4
    /// 解释：一个可能的最长回文子序列为 "bbbb" 。
    /// 
    /// 示例 2：
    /// 输入：s = "cbbd"
    /// 输出：2
    /// 解释：一个可能的最长回文子序列为 "bb" 。
    /// 
    /// 提示：
    /// 1 <= s.length <= 1000
    /// s 仅由小写英文字母组成
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/longest-palindromic-subsequence
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution516
    {
        /// <summary>
        /// 执行用时：80 ms, 在所有 C# 提交中击败了 75.56% 的用户
        /// 内存消耗：39.5 MB, 在所有 C# 提交中击败了 57.78% 的用户
        /// 通过测试用例：86 / 86
        ///
        /// 参考题解做的
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestPalindromeSubseq(string s)
        {
            int n = s.Length;
            int[,] dp = new int[n, n];
            for (int i = n - 1; i >= 0; i--)
            {
                dp[i, i] = 1;
                char c1 = s[i];
                for (int j = i + 1; j < n; j++)
                {
                    char c2 = s[j];
                    if (c1 == c2) dp[i, j] = dp[i + 1, j - 1] + 2;
                    else dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }

            return dp[0, n - 1];
        }
    }
}