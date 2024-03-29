﻿using System;

namespace ConsoleApplicationLeetCodeSolutions.from1401to1600
{
    /// <summary>
    /// 1574. 删除最短的子数组使剩余数组有序 | 难度：中等 | 标签：栈、数组、双指针、二分查找、单调栈
    /// 给你一个整数数组 arr ，请你删除一个子数组（可以为空），使得 arr 中剩下的元素是 非递减 的。
    /// 
    /// 一个子数组指的是原数组中连续的一个子序列。
    /// 
    /// 请你返回满足题目要求的最短子数组的长度。
    /// 
    /// 示例 1：
    /// 输入：arr = [1,2,3,10,4,2,3,5]
    /// 输出：3
    /// 解释：我们需要删除的最短子数组是 [10,4,2] ，长度为 3 。剩余元素形成非递减数组 [1,2,3,3,5] 。
    /// 另一个正确的解为删除子数组 [3,10,4] 。
    /// 
    /// 示例 2：
    /// 输入：arr = [5,4,3,2,1]
    /// 输出：4
    /// 解释：由于数组是严格递减的，我们只能保留一个元素。所以我们需要删除长度为 4 的子数组，要么删除 [5,4,3,2]，要么删除 [4,3,2,1]。
    /// 
    /// 示例 3：
    /// 输入：arr = [1,2,3]
    /// 输出：0
    /// 解释：数组已经是非递减的了，我们不需要删除任何元素。
    /// 
    /// 示例 4：
    /// 输入：arr = [1]
    /// 输出：0
    /// 
    /// 提示：
    /// 1 <= arr.length <= 10^5
    /// 0 <= arr[i] <= 10^9
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/shortest-subarray-to-be-removed-to-make-array-sorted
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1574
    {
        /**
         * 执行用时：176 ms, 在所有 C# 提交中击败了 75.00% 的用户
         * 内存消耗：56.1 MB, 在所有 C# 提交中击败了 31.25% 的用户
         * 通过测试用例：117 / 117
         */
        public int FindLengthOfShortestSubarray(int[] arr)
        {
            if (arr.Length <= 1) return 0;
            var l = 0;
            var r = arr.Length - 1;
            while (l + 1 < r && arr[l + 1] >= arr[l]) l++;
            while (r - 1 > l && arr[r - 1] <= arr[r]) r--;
            if (arr[l] < arr[r]) return r - l - 1;
            var min = Math.Min(arr.Length - l - 1, r);
            if (arr[0] > arr[arr.Length - 1]) return min;
            var ptr = r;
            for (int i = 0; i <= l; i++)
            {
                if (arr[i] > arr[arr.Length - 1]) break;
                // 这里可以用二分查找优化
                while (arr[ptr] < arr[i]) ptr++;
                min = Math.Min(min, ptr - i - 1);
            }

            return min;
        }
    }
}