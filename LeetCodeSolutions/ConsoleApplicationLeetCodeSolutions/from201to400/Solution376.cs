using System;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 376. 摆动序列 | 难度：中等 | 标签：贪心、数组、动态规划
    /// 如果连续数字之间的差严格地在正数和负数之间交替，则数字序列称为 摆动序列 。第一个差（如果存在的话）可能是正数或负数。仅有一个元素或者含两个不等元素的序列也视作摆动序列。
    /// 
    /// 例如， [1, 7, 4, 9, 2, 5] 是一个 摆动序列 ，因为差值 (6, -3, 5, -7, 3) 是正负交替出现的。
    /// 
    /// 相反，[1, 4, 7, 2, 5] 和 [1, 7, 4, 5, 5] 不是摆动序列，第一个序列是因为它的前两个差值都是正数，第二个序列是因为它的最后一个差值为零。
    /// 子序列 可以通过从原始序列中删除一些（也可以不删除）元素来获得，剩下的元素保持其原始顺序。
    /// 
    /// 给你一个整数数组 nums ，返回 nums 中作为 摆动序列 的 最长子序列的长度 。
    /// 
    /// 示例 1：
    /// 输入：nums = [1,7,4,9,2,5]
    /// 输出：6
    /// 解释：整个序列均为摆动序列，各元素之间的差值为 (6, -3, 5, -7, 3) 。
    /// 
    /// 示例 2：
    /// 输入：nums = [1,17,5,10,13,15,10,5,16,8]
    /// 输出：7
    /// 解释：这个序列包含几个长度为 7 摆动序列。
    /// 其中一个是 [1, 17, 10, 13, 10, 16, 8] ，各元素之间的差值为 (16, -7, 3, -3, 6, -8) 。
    /// 
    /// 示例 3：
    /// 输入：nums = [1,2,3,4,5,6,7,8,9]
    /// 输出：2
    /// 
    /// 提示：
    /// 1 <= nums.length <= 1000
    /// 0 <= nums[i] <= 1000
    /// 
    /// 进阶：你能否用 O(n) 时间复杂度完成此题?
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/wiggle-subsequence
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution376
    {
        /// <summary>
        /// 执行用时：76 ms, 在所有 C# 提交中击败了 85.71% 的用户
        /// 内存消耗：37.2 MB, 在所有 C# 提交中击败了 53.06% 的用户
        /// 通过测试用例：31 / 31
        ///
        /// 参考题解做的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int WiggleMaxLength(int[] nums)
        {
            int n = nums.Length;
            if (n < 2) return n;
            int up = 1, down = 1;
            for (int i = 1; i < n; i++)
            {
                if (nums[i] > nums[i - 1]) up = down + 1;
                else if (nums[i] < nums[i - 1]) down = up + 1;
            }

            return Math.Max(up, down);
        }

        /// <summary>
        /// 执行用时：88 ms, 在所有 C# 提交中击败了 10.20% 的用户
        /// 内存消耗：37.3 MB, 在所有 C# 提交中击败了 8.16% 的用户
        /// 通过测试用例：31 / 31
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int WiggleMaxLength_Slow(int[] nums)
        {
            var dp = new int[nums.Length, 2];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i, 0] = 1;
                dp[i, 1] = 1;
            }

            var max = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j] && dp[j, 1] + 1 > dp[i, 0]) dp[i, 0] = dp[j, 1] + 1;
                    else if (nums[i] < nums[j] && dp[j, 0] + 1 > dp[i, 1]) dp[i, 1] = dp[j, 0] + 1;
                }

                if (dp[i, 0] > max) max = dp[i, 0];
                if (dp[i, 1] > max) max = dp[i, 1];
            }

            return max;
        }
    }
}