using System;

namespace ConsoleApplicationLeetCodeSolutions.from1401to1600
{
    /// <summary>
    /// 1464. 数组中两元素的最大乘积 | 难度：简单 | 标签：数组、排序、堆（优先队列）
    /// 给你一个整数数组 nums，请你选择数组的两个不同下标 i 和 j，使 (nums[i]-1)*(nums[j]-1) 取得最大值。
    /// 
    /// 请你计算并返回该式的最大值。
    /// 
    /// 示例 1：
    /// 输入：nums = [3,4,5,2]
    /// 输出：12 
    /// 解释：如果选择下标 i=1 和 j=2（下标从 0 开始），则可以获得最大值，(nums[1]-1)*(nums[2]-1) = (4-1)*(5-1) = 3*4 = 12 。 
    /// 
    /// 示例 2：
    /// 输入：nums = [1,5,4,5]
    /// 输出：16
    /// 解释：选择下标 i=1 和 j=3（下标从 0 开始），则可以获得最大值 (5-1)*(5-1) = 16 。
    /// 
    /// 示例 3：
    /// 输入：nums = [3,7]
    /// 输出：12
    /// 
    /// 提示：
    /// 2 <= nums.length <= 500
    /// 1 <= nums[i] <= 10^3
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/maximum-product-of-two-elements-in-an-array
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1464
    {
        /// <summary>
        /// 执行用时：96 ms, 在所有 C# 提交中击败了 8.57% 的用户
        /// 内存消耗：38.1 MB, 在所有 C# 提交中击败了 68.57% 的用户
        /// 通过测试用例：104 / 104
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxProduct(int[] nums)
        {
            int max1 = Math.Max(nums[0], nums[1]);
            int max2 = Math.Min(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] > max1)
                {
                    max2 = max1;
                    max1 = nums[i];
                }
                else if (nums[i] > max2)
                {
                    max2 = nums[i];
                }
            }

            return (max1 - 1) * (max2 - 1);
        }
    }
}