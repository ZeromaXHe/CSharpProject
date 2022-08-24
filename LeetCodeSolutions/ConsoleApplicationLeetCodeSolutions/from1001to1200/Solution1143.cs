using System;

namespace ConsoleApplicationLeetCodeSolutions.from1001to1200
{
    /// <summary>
    /// 1143. 最长公共子序列 | 难度：中等 | 标签：字符串、动态规划
    /// 给定两个字符串 text1 和 text2，返回这两个字符串的最长 公共子序列 的长度。如果不存在 公共子序列 ，返回 0 。
    /// 
    /// 一个字符串的 子序列 是指这样一个新的字符串：它是由原字符串在不改变字符的相对顺序的情况下删除某些字符（也可以不删除任何字符）后组成的新字符串。
    /// 
    /// 例如，"ace" 是 "abcde" 的子序列，但 "aec" 不是 "abcde" 的子序列。
    /// 两个字符串的 公共子序列 是这两个字符串所共同拥有的子序列。
    /// 
    /// 示例 1：
    /// 输入：text1 = "abcde", text2 = "ace" 
    /// 输出：3  
    /// 解释：最长公共子序列是 "ace" ，它的长度为 3 。
    /// 
    /// 示例 2：
    /// 输入：text1 = "abc", text2 = "abc"
    /// 输出：3
    /// 解释：最长公共子序列是 "abc" ，它的长度为 3 。
    /// 
    /// 示例 3：
    /// 输入：text1 = "abc", text2 = "def"
    /// 输出：0
    /// 解释：两个字符串没有公共子序列，返回 0 。
    /// 
    /// 提示：
    /// 1 <= text1.length, text2.length <= 1000
    /// text1 和 text2 仅由小写英文字符组成。
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/longest-common-subsequence
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1143
    {
        /// <summary>
        /// 执行用时：64 ms, 在所有 C# 提交中击败了 74.47% 的用户
        /// 内存消耗：39.3 MB, 在所有 C# 提交中击败了 65.96% 的用户
        /// 通过测试用例：45 / 45
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public int LongestCommonSubsequence(string text1, string text2)
        {
            var dp = new int[text1.Length, text2.Length];
            dp[0, 0] = text1[0] == text2[0] ? 1 : 0;
            for (int j = 1; j < text2.Length; j++)
            {
                if (dp[0, j - 1] == 1 || text2[j] == text1[0]) dp[0, j] = 1;
            }

            for (int i = 1; i < text1.Length; i++)
            {
                if (dp[i - 1, 0] == 1 || text1[i] == text2[0]) dp[i, 0] = 1;
                for (int j = 1; j < text2.Length; j++)
                {
                    if (text1[i] == text2[j]) dp[i, j] = dp[i - 1, j - 1] + 1;
                    else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return dp[text1.Length - 1, text2.Length - 1];
        }
    }
}