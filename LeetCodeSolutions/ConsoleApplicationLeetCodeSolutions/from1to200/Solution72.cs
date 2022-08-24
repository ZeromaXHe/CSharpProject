using System;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 72. 编辑距离 | 难度：困难 | 标签：字符串、动态规划
    /// 给你两个单词 word1 和 word2， 请返回将 word1 转换成 word2 所使用的最少操作数  。
    /// 
    /// 你可以对一个单词进行如下三种操作：
    /// 
    /// 插入一个字符
    /// 删除一个字符
    /// 替换一个字符
    /// 
    /// 示例 1：
    /// 输入：word1 = "horse", word2 = "ros"
    /// 输出：3
    /// 解释：
    /// horse -> rorse (将 'h' 替换为 'r')
    /// rorse -> rose (删除 'r')
    /// rose -> ros (删除 'e')
    /// 
    /// 示例 2：
    /// 输入：word1 = "intention", word2 = "execution"
    /// 输出：5
    /// 解释：
    /// intention -> inention (删除 't')
    /// inention -> enention (将 'i' 替换为 'e')
    /// enention -> exention (将 'n' 替换为 'x')
    /// exention -> exection (将 'n' 替换为 'c')
    /// exection -> execution (插入 'u')
    /// 
    /// 提示：
    /// 0 <= word1.length, word2.length <= 500
    /// word1 和 word2 由小写英文字母组成
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/edit-distance
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution72
    {
        /// <summary>
        /// 执行用时：64 ms, 在所有 C# 提交中击败了 67.69% 的用户
        /// 内存消耗：42 MB, 在所有 C# 提交中击败了 83.08% 的用户
        /// 通过测试用例：1146 / 1146
        ///
        /// 参考题解做的
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            int n = word1.Length;
            int m = word2.Length;
            // 有一个字符串为空串
            if (n * m == 0) return n + m;
            // DP 数组
            int[,] D = new int[n + 1, m + 1];
            // 边界状态初始化
            for (int i = 0; i < n + 1; i++) D[i, 0] = i;
            for (int j = 0; j < m + 1; j++) D[0, j] = j;
            // 计算所有 DP 值
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    int left = D[i - 1, j] + 1;
                    int down = D[i, j - 1] + 1;
                    int leftDown = D[i - 1, j - 1];
                    if (word1[i - 1] != word2[j - 1]) leftDown += 1;
                    D[i, j] = Math.Min(left, Math.Min(down, leftDown));
                }
            }

            return D[n, m];
        }
    }
}