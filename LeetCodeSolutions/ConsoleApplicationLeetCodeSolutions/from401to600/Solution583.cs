using System;

namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 583. 两个字符串的删除操作 | 难度：中等 | 标签：字符串、动态规划
    /// 给定两个单词 word1 和 word2 ，返回使得 word1 和  word2 相同所需的最小步数。
    /// 
    /// 每步 可以删除任意一个字符串中的一个字符。
    /// 
    /// 示例 1：
    /// 输入: word1 = "sea", word2 = "eat"
    /// 输出: 2
    /// 解释: 第一步将 "sea" 变为 "ea" ，第二步将 "eat "变为 "ea"
    /// 
    /// 示例  2:
    /// 输入：word1 = "leetcode", word2 = "etco"
    /// 输出：4
    /// 
    /// 提示：
    /// 1 <= word1.length, word2.length <= 500
    /// word1 和 word2 只包含小写英文字母
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/delete-operation-for-two-strings
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution583
    {
        public void Test()
        {
            Console.WriteLine(MinDistance("sea", "eat"));
        }

        /// <summary>
        /// 执行用时：60 ms, 在所有 C# 提交中击败了 90.74% 的用户
        /// 内存消耗：44.8 MB, 在所有 C# 提交中击败了 33.33% 的用户
        /// 通过测试用例：1306 / 1306
        ///
        /// 总长度减掉 1143 题的最长公共子序列长度的两倍即可
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            var dp = new int[word1.Length + 1, word2.Length + 1];
            for (int i = 1; i <= word1.Length; i++)
            {
                for (int j = 1; j <= word2.Length; j++)
                {
                    if (word1[i - 1] == word2[j - 1]) dp[i, j] = dp[i - 1, j - 1] + 1;
                    else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return word1.Length + word2.Length - 2 * dp[word1.Length, word2.Length];
        }
    }
}