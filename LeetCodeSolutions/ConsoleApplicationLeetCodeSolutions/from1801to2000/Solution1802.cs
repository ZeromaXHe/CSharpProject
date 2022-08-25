using System;

namespace ConsoleApplicationLeetCodeSolutions.from1801to2000
{
    /// <summary>
    /// 1802. 有界数组中指定下标处的最大值 | 难度：中等 | 标签：贪心、二分查找
    /// 给你三个正整数 n、index 和 maxSum 。你需要构造一个同时满足下述所有条件的数组 nums（下标 从 0 开始 计数）：
    /// 
    /// nums.length == n
    /// nums[i] 是 正整数 ，其中 0 <= i < n
    /// abs(nums[i] - nums[i+1]) <= 1 ，其中 0 <= i < n-1
    /// nums 中所有元素之和不超过 maxSum
    /// nums[index] 的值被 最大化
    /// 返回你所构造的数组中的 nums[index] 。
    /// 
    /// 注意：abs(x) 等于 x 的前提是 x >= 0 ；否则，abs(x) 等于 -x 。
    /// 
    /// 示例 1：
    /// 输入：n = 4, index = 2,  maxSum = 6
    /// 输出：2
    /// 解释：数组 [1,1,2,1] 和 [1,2,2,1] 满足所有条件。不存在其他在指定下标处具有更大值的有效数组。
    /// 
    /// 示例 2：
    /// 输入：n = 6, index = 1,  maxSum = 10
    /// 输出：3
    /// 
    /// 提示：
    /// 1 <= n <= maxSum <= 109
    /// 0 <= index < n
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/maximum-value-at-a-given-index-in-a-bounded-array
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1802
    {
        public void Test()
        {
            Console.WriteLine(MaxValue(9, 3, 16)); // 3
            Console.WriteLine(MaxValue(6, 2, 931384943)); // 155230825
        }

        /// <summary>
        /// 执行用时：20 ms, 在所有 C# 提交中击败了 83.33% 的用户
        /// 内存消耗：26.2 MB, 在所有 C# 提交中击败了 22.22% 的用户
        /// 通过测试用例：370 / 370
        /// </summary>
        /// <param name="n"></param>
        /// <param name="index"></param>
        /// <param name="maxSum"></param>
        /// <returns></returns>
        public int MaxValue(int n, int index, int maxSum)
        {
            var l = 2;
            var r = maxSum - n + 1;
            var result = 1;
            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var sum = n + mid - 1L;
                if (mid > 2)
                {
                    if (index > 0)
                    {
                        var lIndex = Math.Max(0, index - mid + 1);
                        var lValue = mid - (index - lIndex);
                        var rValue = mid - 1;
                        sum += (index - lIndex) * (lValue + rValue - 2L) / 2;
                    }

                    if (index < n - 1)
                    {
                        var rIndex = Math.Min(n - 1, index + mid - 1);
                        var rValue = mid - (rIndex - index);
                        var lValue = mid - 1;
                        sum += (rIndex - index) * (lValue + rValue - 2L) / 2;
                    }
                }

                if (sum > maxSum) r = mid - 1;
                else
                {
                    l = mid + 1;
                    result = mid;
                }
            }

            return result;
        }
    }
}