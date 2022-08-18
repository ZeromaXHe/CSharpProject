using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 503. 下一个更大元素 II | 难度：中等 | 标签：栈、数组、单调栈
    /// 给定一个循环数组 nums （ nums[nums.length - 1] 的下一个元素是 nums[0] ），返回 nums 中每个元素的 下一个更大元素 。
    /// 
    /// 数字 x 的 下一个更大的元素 是按数组遍历顺序，这个数字之后的第一个比它更大的数，这意味着你应该循环地搜索它的下一个更大的数。如果不存在，则输出 -1 。
    /// 
    /// 示例 1:
    /// 输入: nums = [1,2,1]
    /// 输出: [2,-1,2]
    /// 解释: 第一个 1 的下一个更大的数是 2；
    /// 数字 2 找不到下一个更大的数； 
    /// 第二个 1 的下一个最大的数需要循环搜索，结果也是 2。
    /// 
    /// 示例 2:
    /// 输入: nums = [1,2,3,4,3]
    /// 输出: [2,3,4,-1,4]
    /// 
    /// 提示:
    /// 1 <= nums.length <= 104
    /// -109 <= nums[i] <= 109
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/next-greater-element-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution503
    {
        /// <summary>
        /// 执行用时：152 ms, 在所有 C# 提交中击败了 61.54% 的用户
        /// 内存消耗：54.9 MB, 在所有 C# 提交中击败了 60.00% 的用户
        /// 通过测试用例：223 / 223
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] NextGreaterElements(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = -1;
            }

            var stack = new Stack<int>();
            for (int i = 0; i < n * 2 - 1; i++)
            {
                while (stack.Count > 0 && nums[stack.Peek()] < nums[i % n])
                {
                    res[stack.Pop()] = nums[i % n];
                }

                stack.Push(i % n);
            }

            return res;
        }
    }
}