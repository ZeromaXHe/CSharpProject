using System;
using System.Linq;

namespace ConsoleApplicationLeetCodeSolutions.from601to800
{
    /// <summary>
    /// 740. 删除并获得点数 | 难度：中等 | 标签：数组、哈希表、动态规划
    /// 给你一个整数数组 nums ，你可以对它进行一些操作。
    /// 
    /// 每次操作中，选择任意一个 nums[i] ，删除它并获得 nums[i] 的点数。之后，你必须删除 所有 等于 nums[i] - 1 和 nums[i] + 1 的元素。
    /// 
    /// 开始你拥有 0 个点数。返回你能通过这些操作获得的最大点数。
    /// 
    /// 示例 1：
    /// 输入：nums = [3,4,2]
    /// 输出：6
    /// 解释：
    /// 删除 4 获得 4 个点数，因此 3 也被删除。
    /// 之后，删除 2 获得 2 个点数。总共获得 6 个点数。
    /// 
    /// 示例 2：
    /// 输入：nums = [2,2,3,3,3,4]
    /// 输出：9
    /// 解释：
    /// 删除 3 获得 3 个点数，接着要删除两个 2 和 4 。
    /// 之后，再次删除 3 获得 3 个点数，再次删除 3 获得 3 个点数。
    /// 总共获得 9 个点数。
    /// 
    /// 提示：
    /// 1 <= nums.length <= 2 * 104
    /// 1 <= nums[i] <= 104
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/delete-and-earn
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution740
    {
        /// <summary>
        /// 执行用时：96 ms, 在所有 C# 提交中击败了 20.69% 的用户
        /// 内存消耗：43.2 MB, 在所有 C# 提交中击败了 8.62% 的用户
        /// 通过测试用例：50 / 50
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DeleteAndEarn(int[] nums)
        {
            var dict = nums.GroupBy(i => i).ToDictionary(g => g.Key, g => g.Sum());
            var min = nums.Min();
            var max = nums.Max();
            int[] dp = new int[2];
            for (int i = min; i <= max; i++)
            {
                // C# 从字典里面获取不到时赋默认值的方法这么恶心的吗？好像确实没有其他写法，这样写太蠢了
                int sum;
                dict.TryGetValue(i, out sum);
                dp[i % 2] = Math.Max(dp[i % 2] + sum, dp[(i + 1) % 2]);
            }

            return Math.Max(dp[0], dp[1]);
        }
    }
}