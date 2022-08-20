using System;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 154. 寻找旋转排序数组中的最小值 II | 难度：困难 | 标签：数组、二分查找
    /// 已知一个长度为 n 的数组，预先按照升序排列，经由 1 到 n 次 旋转 后，得到输入数组。例如，原数组 nums = [0,1,4,4,5,6,7] 在变化后可能得到：
    /// 若旋转 4 次，则可以得到 [4,5,6,7,0,1,4]
    /// 若旋转 7 次，则可以得到 [0,1,4,4,5,6,7]
    /// 注意，数组 [a[0], a[1], a[2], ..., a[n-1]] 旋转一次 的结果为数组 [a[n-1], a[0], a[1], a[2], ..., a[n-2]] 。
    /// 
    /// 给你一个可能存在 重复 元素值的数组 nums ，它原来是一个升序排列的数组，并按上述情形进行了多次旋转。请你找出并返回数组中的 最小元素 。
    /// 
    /// 你必须尽可能减少整个过程的操作步骤。
    /// 
    /// 示例 1：
    /// 输入：nums = [1,3,5]
    /// 输出：1
    /// 
    /// 示例 2：
    /// 输入：nums = [2,2,2,0,1]
    /// 输出：0
    /// 
    /// 提示：
    /// n == nums.length
    /// 1 <= n <= 5000
    /// -5000 <= nums[i] <= 5000
    /// nums 原来是一个升序排序的数组，并进行了 1 至 n 次旋转
    /// 
    /// 进阶：这道题与 寻找旋转排序数组中的最小值 类似，但 nums 可能包含重复元素。允许重复会影响算法的时间复杂度吗？会如何影响，为什么？
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/find-minimum-in-rotated-sorted-array-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution154
    {
        /// <summary>
        /// 执行用时：96 ms, 在所有 C# 提交中击败了 16.00% 的用户
        /// 内存消耗：38.7 MB, 在所有 C# 提交中击败了 58.00% 的用户
        /// 通过测试用例：193 / 193
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            var l = 0;
            var r = nums.Length - 1;
            var min = nums[0];
            while (l <= r)
            {
                var mid = (l + r) / 2;
                if (nums[mid] == nums[r] && nums[l] == nums[r])
                {
                    min = Math.Min(min, nums[l]);
                    l++;
                    r--;
                    continue;
                }

                if (nums[l] <= nums[mid])
                {
                    // l 到 mid 是递增或相等的
                    min = Math.Min(min, nums[l]);
                    l = mid + 1;
                }
                else
                {
                    // mid 到 right 是递增或相等的
                    min = Math.Min(min, nums[mid]);
                    r = mid - 1;
                }
            }

            return min;
        }
    }
}