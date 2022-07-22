using System;
using System.Linq;

namespace ConsoleApplicationLeetCodeSolutions.from2201to2400
{
    /// <summary>
    /// 2344. 使数组可以被整除的最少删除次数 | 难度：困难 | 标签：数组、数学、数论、排序、堆（优先队列）
    /// 给你两个正整数数组 nums 和 numsDivide 。你可以从 nums 中删除任意数目的元素。
    /// 
    /// 请你返回使 nums 中 最小 元素可以整除 numsDivide 中所有元素的 最少 删除次数。如果无法得到这样的元素，返回 -1 。
    /// 
    /// 如果 y % x == 0 ，那么我们说整数 x 整除 y 。
    /// 
    /// 示例 1：
    /// 输入：nums = [2,3,2,4,3], numsDivide = [9,6,9,3,15]
    /// 输出：2
    /// 解释：
    /// [2,3,2,4,3] 中最小元素是 2 ，它无法整除 numsDivide 中所有元素。
    /// 我们从 nums 中删除 2 个大小为 2 的元素，得到 nums = [3,4,3] 。
    /// [3,4,3] 中最小元素为 3 ，它可以整除 numsDivide 中所有元素。
    /// 可以证明 2 是最少删除次数。
    /// 
    /// 示例 2：
    /// 输入：nums = [4,3,6], numsDivide = [8,2,6,10]
    /// 输出：-1
    /// 解释：
    /// 我们想 nums 中的最小元素可以整除 numsDivide 中的所有元素。
    /// 没有任何办法可以达到这一目的。
    /// 
    /// 提示：
    /// 1 <= nums.length, numsDivide.length <= 105
    /// 1 <= nums[i], numsDivide[i] <= 109
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/minimum-deletions-to-make-array-divisible
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution2344
    {
        /// <summary>
        /// 执行用时：220 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗：56.8 MB, 在所有 C# 提交中击败了 100.00% 的用户
        /// 通过测试用例：49 / 49
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="numsDivide"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums, int[] numsDivide)
        {
            int gcdRes = gcd(numsDivide);
            var tuple = nums.Where(i => i <= gcdRes)
                .OrderBy(i => i)
                .Zip(Enumerable.Range(0, nums.Length), (num, i) => (num, i))
                .FirstOrDefault(t => gcdRes % t.num == 0);
            if (tuple == default) return -1;
            return tuple.i;
        }

        private int gcd(int a, int b) => b == 0 ? a : gcd(b, a % b);

        private int gcd(int[] arr) => arr.Aggregate((res, next) => gcd(res, next));
    }
}