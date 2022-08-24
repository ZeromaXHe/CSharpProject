namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 377. 组合总和 Ⅳ | 难度：中等 | 标签：数组、动态规划
    /// 给你一个由 不同 整数组成的数组 nums ，和一个目标整数 target 。请你从 nums 中找出并返回总和为 target 的元素组合的个数。
    /// 
    /// 题目数据保证答案符合 32 位整数范围。
    /// 
    /// 示例 1：
    /// 输入：nums = [1,2,3], target = 4
    /// 输出：7
    /// 解释：
    /// 所有可能的组合为：
    /// (1, 1, 1, 1)
    /// (1, 1, 2)
    /// (1, 2, 1)
    /// (1, 3)
    /// (2, 1, 1)
    /// (2, 2)
    /// (3, 1)
    /// 请注意，顺序不同的序列被视作不同的组合。
    /// 
    /// 示例 2：
    /// 输入：nums = [9], target = 3
    /// 输出：0
    /// 
    /// 提示：
    /// 1 <= nums.length <= 200
    /// 1 <= nums[i] <= 1000
    /// nums 中的所有元素 互不相同
    /// 1 <= target <= 1000
    /// 
    /// 进阶：如果给定的数组中含有负数会发生什么？问题会产生何种变化？如果允许负数出现，需要向题目中添加哪些限制条件？
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/combination-sum-iv
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution377
    {
        /// <summary>
        /// 执行用时：72 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗：37.2 MB, 在所有 C# 提交中击败了 64.71% 的用户
        /// 通过测试用例：15 / 15
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CombinationSum4(int[] nums, int target)
        {
            int[] dp = new int[target + 1];
            dp[0] = 1;
            for (int i = 0; i <= target; i++)
            {
                foreach (var num in nums)
                {
                    if (i - num >= 0) dp[i] += dp[i - num];
                }
            }

            return dp[target];
        }
    }
}