﻿namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 81. 搜索旋转排序数组 II | 难度：中等 | 标签：数组、二分查找
    /// 已知存在一个按非降序排列的整数数组 nums ，数组中的值不必互不相同。
    /// 
    /// 在传递给函数之前，nums 在预先未知的某个下标 k（0 <= k < nums.length）上进行了 旋转 ，使数组变为 [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]]（下标 从 0 开始 计数）。例如， [0,1,2,4,4,4,5,6,6,7] 在下标 5 处经旋转后可能变为 [4,5,6,6,7,0,1,2,4,4] 。
    /// 
    /// 给你 旋转后 的数组 nums 和一个整数 target ，请你编写一个函数来判断给定的目标值是否存在于数组中。如果 nums 中存在这个目标值 target ，则返回 true ，否则返回 false 。
    /// 
    /// 你必须尽可能减少整个操作步骤。
    /// 
    /// 示例 1：
    /// 输入：nums = [2,5,6,0,0,1,2], target = 0
    /// 输出：true
    /// 
    /// 示例 2：
    /// 输入：nums = [2,5,6,0,0,1,2], target = 3
    /// 输出：false
    /// 
    /// 提示：
    /// 1 <= nums.length <= 5000
    /// -104 <= nums[i] <= 104
    /// 题目数据保证 nums 在预先未知的某个下标上进行了旋转
    /// -104 <= target <= 104
    /// 
    /// 进阶：
    /// 这是 搜索旋转排序数组 的延伸题目，本题中的 nums  可能包含重复元素。
    /// 这会影响到程序的时间复杂度吗？会有怎样的影响，为什么？
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/search-in-rotated-sorted-array-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution81
    {
        /// <summary>
        /// 执行用时：92 ms, 在所有 C# 提交中击败了 56.10% 的用户
        /// 内存消耗：40.7 MB, 在所有 C# 提交中击败了 23.17% 的用户
        /// 通过测试用例：280 / 280
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search(int[] nums, int target)
        {
            var l = 0;
            var r = nums.Length - 1;
            while (l <= r)
            {
                if (nums[l] == target) return true;
                if (nums[r] == target) return true;
                var mid = (l + r) / 2;
                if (nums[mid] == nums[r] && nums[l] == nums[r])
                {
                    l++;
                    r--;
                    continue;
                }

                if (nums[mid] == target) return true;
                if (nums[l] <= nums[mid])
                {
                    // l 到 mid 是递增或相等的
                    if (nums[mid] > target && target >= nums[l]) r = mid - 1;
                    else l = mid + 1;
                }
                else
                {
                    // mid 到 right 是递增或相等的
                    if (nums[mid] < target && target <= nums[r]) l = mid + 1;
                    else r = mid - 1;
                }
            }

            return false;
        }
    }
}