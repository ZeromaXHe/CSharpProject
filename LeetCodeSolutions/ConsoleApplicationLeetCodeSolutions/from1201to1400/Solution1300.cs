using System;

namespace ConsoleApplicationLeetCodeSolutions.from1201to1400
{
    /// <summary>
    /// 1300. 转变数组后最接近目标值的数组和 | 难度：中等 | 标签：数组、二分查找、排序
    /// 给你一个整数数组 arr 和一个目标值 target ，请你返回一个整数 value ，使得将数组中所有大于 value 的值变成 value 后，数组的和最接近  target （最接近表示两者之差的绝对值最小）。
    /// 
    /// 如果有多种使得和最接近 target 的方案，请你返回这些整数中的最小值。
    /// 
    /// 请注意，答案不一定是 arr 中的数字。
    /// 
    /// 示例 1：
    /// 输入：arr = [4,9,3], target = 10
    /// 输出：3
    /// 解释：当选择 value 为 3 时，数组会变成 [3, 3, 3]，和为 9 ，这是最接近 target 的方案。
    /// 
    /// 示例 2：
    /// 输入：arr = [2,3,5], target = 10
    /// 输出：5
    /// 
    /// 示例 3：
    /// 输入：arr = [60864,25176,27249,21296,20204], target = 56803
    /// 输出：11361
    /// 
    /// 提示：
    /// 1 <= arr.length <= 10^4
    /// 1 <= arr[i], target <= 10^5
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/sum-of-mutated-array-closest-to-target
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1300
    {
        /// <summary>
        /// 执行用时：96 ms, 在所有 C# 提交中击败了 63.16% 的用户
        /// 内存消耗：41 MB, 在所有 C# 提交中击败了 21.05% 的用户
        /// 通过测试用例：21 / 21
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindBestValue(int[] arr, int target)
        {
            Array.Sort(arr);
            var preSum = new int[arr.Length + 1];
            var sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                preSum[i + 1] = sum;
            }

            if (sum <= target) return arr[arr.Length - 1];
            var l = 1;
            var r = arr.Length;
            var idx = 0;
            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var test = preSum[mid] + (arr.Length - mid) * arr[mid - 1];
                if (test > target) r = mid - 1;
                else if (test == target) return arr[mid - 1];
                else
                {
                    l = mid + 1;
                    idx = mid;
                }
            }


            var test1 = (target - preSum[idx]) / (arr.Length - idx);
            var test2 = test1 + 1;
            return Math.Abs(preSum[idx] + (arr.Length - idx) * test1 - target) <=
                   Math.Abs(preSum[idx] + (arr.Length - idx) * test2 - target)
                ? test1
                : test2;
        }
    }
}