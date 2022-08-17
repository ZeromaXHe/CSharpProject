using System;

namespace ConsoleApplicationLeetCodeSolutions.from1801to2000
{
    /// <summary>
    /// 1838. 最高频元素的频数 | 难度：中等 | 标签：数组、二分查找、前缀和、滑动窗口
    /// 元素的 频数 是该元素在一个数组中出现的次数。
    /// 
    /// 给你一个整数数组 nums 和一个整数 k 。在一步操作中，你可以选择 nums 的一个下标，并将该下标对应元素的值增加 1 。
    /// 
    /// 执行最多 k 次操作后，返回数组中最高频元素的 最大可能频数 。
    /// 
    /// 示例 1：
    /// 输入：nums = [1,2,4], k = 5
    /// 输出：3
    /// 解释：对第一个元素执行 3 次递增操作，对第二个元素执 2 次递增操作，此时 nums = [4,4,4] 。
    /// 4 是数组中最高频元素，频数是 3 。
    /// 
    /// 示例 2：
    /// 输入：nums = [1,4,8,13], k = 5
    /// 输出：2
    /// 解释：存在多种最优解决方案：
    /// - 对第一个元素执行 3 次递增操作，此时 nums = [4,4,8,13] 。4 是数组中最高频元素，频数是 2 。
    /// - 对第二个元素执行 4 次递增操作，此时 nums = [1,8,8,13] 。8 是数组中最高频元素，频数是 2 。
    /// - 对第三个元素执行 5 次递增操作，此时 nums = [1,4,13,13] 。13 是数组中最高频元素，频数是 2 。
    /// 
    /// 示例 3：
    /// 输入：nums = [3,9,6], k = 2
    /// 输出：1
    /// 
    /// 提示：
    /// 1 <= nums.length <= 105
    /// 1 <= nums[i] <= 105
    /// 1 <= k <= 105
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/frequency-of-the-most-frequent-element
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1838
    {
        /// <summary>
        /// 执行用时：264 ms, 在所有 C# 提交中击败了 63.64% 的用户
        /// 内存消耗：53.8 MB, 在所有 C# 提交中击败了 72.73% 的用户
        /// 通过测试用例：71 / 71
        ///
        /// 参考题解做的
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxFrequency(int[] nums, int k)
        {
            Array.Sort(nums);
            long total = 0;
            int l = 0, res = 1;
            for (int r = 1; r < nums.Length; ++r)
            {
                total += (long) (nums[r] - nums[r - 1]) * (r - l);
                while (total > k)
                {
                    total -= nums[r] - nums[l];
                    ++l;
                }

                res = Math.Max(res, r - l + 1);
            }

            return res;
        }
    }
}