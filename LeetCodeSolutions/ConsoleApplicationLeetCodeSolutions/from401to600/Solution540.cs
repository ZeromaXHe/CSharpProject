using System;

namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 540. 有序数组中的单一元素 | 难度：中等 | 标签：数组、二分查找
    /// 给你一个仅由整数组成的有序数组，其中每个元素都会出现两次，唯有一个数只会出现一次。
    /// 
    /// 请你找出并返回只出现一次的那个数。
    /// 
    /// 你设计的解决方案必须满足 O(log n) 时间复杂度和 O(1) 空间复杂度。
    /// 
    /// 示例 1:
    /// 输入: nums = [1,1,2,3,3,4,4,8,8]
    /// 输出: 2
    /// 
    /// 示例 2:
    /// 输入: nums =  [3,3,7,7,10,11,11]
    /// 输出: 10
    /// 
    /// 提示:
    /// 1 <= nums.length <= 105
    /// 0 <= nums[i] <= 105
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/single-element-in-a-sorted-array
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution540
    {
        public void Test()
        {
            Console.WriteLine(SingleNonDuplicate(new[] {1, 1, 2, 3, 3, 4, 4, 8, 8}));
        }

        /// <summary>
        /// 执行用时：100 ms, 在所有 C# 提交中击败了 68.75% 的用户
        /// 内存消耗：45.1 MB, 在所有 C# 提交中击败了 28.13% 的用户
        /// 通过测试用例：15 / 15
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNonDuplicate(int[] nums)
        {
            var l = 0;
            var r = (nums.Length - 3) / 2;
            var result = nums[nums.Length - 1];
            while (l <= r)
            {
                var mid = (l + r) / 2;
                if (nums[mid * 2] != nums[mid * 2 + 1])
                {
                    result = nums[mid * 2];
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return result;
        }
    }
}