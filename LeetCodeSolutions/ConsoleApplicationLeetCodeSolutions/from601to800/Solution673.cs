using System;

namespace ConsoleApplicationLeetCodeSolutions.from601to800
{
    /// <summary>
    /// 673. 最长递增子序列的个数 | 难度：中等 | 标签：树状数组、线段树、数组、动态规划
    /// 给定一个未排序的整数数组 nums ， 返回最长递增子序列的个数 。
    /// 
    /// 注意 这个数列必须是 严格 递增的。
    /// 
    /// 示例 1:
    /// 输入: [1,3,5,4,7]
    /// 输出: 2
    /// 解释: 有两个最长递增子序列，分别是 [1, 3, 4, 7] 和[1, 3, 5, 7]。
    /// 
    /// 示例 2:
    /// 输入: [2,2,2,2,2]
    /// 输出: 5
    /// 解释: 最长递增子序列的长度是1，并且存在5个子序列的长度为1，因此输出5。
    /// 
    /// 提示:
    /// 1 <= nums.length <= 2000
    /// -106 <= nums[i] <= 106
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/number-of-longest-increasing-subsequence
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution673
    {
        public void Test()
        {
            Console.WriteLine(FindNumberOfLIS(new[] {1, 2, 4, 3, 5, 4, 7, 2}));
        }

        /// <summary>
        /// 执行用时：112 ms, 在所有 C# 提交中击败了 28.21% 的用户 
        /// 内存消耗：39.1 MB, 在所有 C# 提交中击败了 23.08% 的用户
        /// 通过测试用例：223 / 223
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindNumberOfLIS(int[] nums)
        {
            var dp = new int[nums.Length, 2];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i, 0] = 1;
                dp[i, 1] = 1;
            }

            var max = 1;
            var count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (dp[j, 0] + 1 == dp[i, 0]) dp[i, 1] += dp[j, 1];
                        else if (dp[j, 0] + 1 > dp[i, 0])
                        {
                            dp[i, 0] = dp[j, 0] + 1;
                            dp[i, 1] = dp[j, 1];
                        }
                    }
                }

                if (dp[i, 0] > max)
                {
                    max = dp[i, 0];
                    count = dp[i, 1];
                }
                else if (dp[i, 0] == max) count += dp[i, 1];
            }

            return count;
        }
    }
}