using System;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 4. 寻找两个正序数组的中位数 | 难度：困难 | 标签：数组、二分查找、分治
    /// 给定两个大小分别为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。请你找出并返回这两个正序数组的 中位数 。
    /// 
    /// 算法的时间复杂度应该为 O(log (m+n)) 。
    /// 
    /// 示例 1：
    /// 输入：nums1 = [1,3], nums2 = [2]
    /// 输出：2.00000
    /// 解释：合并数组 = [1,2,3] ，中位数 2
    /// 
    /// 示例 2：
    /// 输入：nums1 = [1,2], nums2 = [3,4]
    /// 输出：2.50000
    /// 解释：合并数组 = [1,2,3,4] ，中位数 (2 + 3) / 2 = 2.5
    /// 
    /// 提示：
    /// nums1.length == m
    /// nums2.length == n
    /// 0 <= m <= 1000
    /// 0 <= n <= 1000
    /// 1 <= m + n <= 2000
    /// -106 <= nums1[i], nums2[i] <= 106
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/median-of-two-sorted-arrays
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution4
    {
        /// <summary>
        /// 执行用时：92 ms, 在所有 C# 提交中击败了 83.58% 的用户
        /// 内存消耗：50.8 MB, 在所有 C# 提交中击败了 75.62% 的用户
        /// 通过测试用例：2094 / 2094
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length) return FindMedianSortedArrays(nums2, nums1);
            int l = 0;
            int r = nums1.Length;
            int median1 = -1;
            int median2 = -1;
            while (l <= r)
            {
                int mid1 = (l + r) / 2;
                int mid2 = (nums1.Length + nums2.Length) / 2 - mid1;
                int leftMax1 = mid1 == 0 ? int.MinValue : nums1[mid1 - 1];
                int leftMax2 = mid2 == 0 ? int.MinValue : nums2[mid2 - 1];
                int rightMin1 = mid1 == nums1.Length ? int.MaxValue : nums1[mid1];
                int rightMin2 = mid2 == nums2.Length ? int.MaxValue : nums2[mid2];
                // 使得 l 可以在 r 不变的情况下向右推进到最符合的位置
                if (leftMax1 < rightMin2)
                {
                    median1 = Math.Max(leftMax1, leftMax2);
                    median2 = Math.Min(rightMin1, rightMin2);
                    l++;
                }
                else r--;
            }

            if ((nums1.Length + nums2.Length) % 2 == 0) return (median1 + median2) / 2.0;
            return median2;
        }
        
        public void Test()
        {
            Console.WriteLine(FindMedianSortedArrays(new[] {1, 3}, new[] {2}));
            Console.WriteLine(FindMedianSortedArrays(new[] {1, 2}, new[] {3, 4}));
        }
    }
}