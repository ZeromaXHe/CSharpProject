using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from2201to2400
{
    /// <summary>
    /// 2334. 元素值大于变化阈值的子数组 | 难度：困难 | 标签：栈、并查集、数组、单调栈
    /// 给你一个整数数组 nums 和一个整数 threshold 。
    /// 
    /// 找到长度为 k 的 nums 子数组，满足数组中 每个 元素都 大于 threshold / k 。
    /// 
    /// 请你返回满足要求的 任意 子数组的 大小 。如果没有这样的子数组，返回 -1 。
    /// 
    /// 子数组 是数组中一段连续非空的元素序列。
    /// 
    /// 示例 1：
    /// 输入：nums = [1,3,4,3,1], threshold = 6
    /// 输出：3
    /// 解释：子数组 [3,4,3] 大小为 3 ，每个元素都大于 6 / 3 = 2 。
    /// 注意这是唯一合法的子数组。
    /// 
    /// 示例 2：
    /// 输入：nums = [6,5,6,5,8], threshold = 7
    /// 输出：1
    /// 解释：子数组 [8] 大小为 1 ，且 8 > 7 / 1 = 7 。所以返回 1 。
    /// 注意子数组 [6,5] 大小为 2 ，每个元素都大于 7 / 2 = 3.5 。
    /// 类似的，子数组 [6,5,6] ，[6,5,6,5] ，[6,5,6,5,8] 都是符合条件的子数组。
    /// 所以返回 2, 3, 4 和 5 都可以。
    /// 
    /// 提示：
    /// 1 <= nums.length <= 105
    /// 1 <= nums[i], threshold <= 109
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/subarray-with-elements-greater-than-varying-threshold
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution2334
    {
        /// <summary>
        /// 执行用时：244 ms, 在所有 C# 提交中击败了 33.33% 的用户
        /// 内存消耗：54.3 MB, 在所有 C# 提交中击败了 33.33% 的用户
        /// 通过测试用例：68 / 68
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public int ValidSubarraySize(int[] nums, int threshold)
        {
            int n = nums.Length;
            int[] left = new int[n];
            int[] right = new int[n];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && nums[stack.Peek()] >= nums[i]) stack.Pop();
                left[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(i);
            }

            stack.Clear();
            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[stack.Peek()] >= nums[i]) stack.Pop();
                right[i] = stack.Count == 0 ? n : stack.Peek();
                stack.Push(i);
            }

            for (int i = 0; i < n; i++)
            {
                int k = right[i] - left[i] - 1;
                if (nums[i] > threshold / k) return k;
            }

            return -1;
        }
    }
}