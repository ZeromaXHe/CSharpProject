namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 96. 不同的二叉搜索树 | 难度：中等 | 标签：树、二叉搜索树、数学、动态规划、二叉树
    /// 给你一个整数 n ，求恰由 n 个节点组成且节点值从 1 到 n 互不相同的 二叉搜索树 有多少种？返回满足题意的二叉搜索树的种数。
    /// 
    /// 示例 1：
    /// 输入：n = 3
    /// 输出：5
    /// 
    /// 示例 2：
    /// 输入：n = 1
    /// 输出：1
    /// 
    /// 提示：
    /// 1 <= n <= 19
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/unique-binary-search-trees
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution96
    {
        /// <summary>
        /// 执行用时：20 ms, 在所有 C# 提交中击败了 79.69% 的用户
        /// 内存消耗：26 MB, 在所有 C# 提交中击败了 31.25% 的用户
        /// 通过测试用例：19 / 19
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumTrees(int n)
        {
            var dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    dp[i] += dp[j - 1] * dp[i - j];
                }
            }

            return dp[n];
        }
    }
}