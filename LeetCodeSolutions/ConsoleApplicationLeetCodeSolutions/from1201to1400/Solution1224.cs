using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplicationLeetCodeSolutions.from1201to1400
{
    /// <summary>
    /// 1224. 最大相等频率 | 难度：困难 | 标签：数组、哈希表
    /// 给你一个正整数数组 nums，请你帮忙从该数组中找出能满足下面要求的 最长 前缀，并返回该前缀的长度：
    /// 
    /// 从前缀中 恰好删除一个 元素后，剩下每个数字的出现次数都相同。
    /// 如果删除这个元素后没有剩余元素存在，仍可认为每个数字都具有相同的出现次数（也就是 0 次）。
    /// 
    /// 示例 1：
    /// 输入：nums = [2,2,1,1,5,3,3,5]
    /// 输出：7
    /// 解释：对于长度为 7 的子数组 [2,2,1,1,5,3,3]，如果我们从中删去 nums[4] = 5，就可以得到 [2,2,1,1,3,3]，里面每个数字都出现了两次。
    /// 
    /// 示例 2：
    /// 输入：nums = [1,1,1,2,2,2,3,3,3,4,4,4,5]
    /// 输出：13
    /// 
    /// 提示：
    /// 2 <= nums.length <= 105
    /// 1 <= nums[i] <= 105
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/maximum-equal-frequency
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1224
    {
        /// <summary>
        /// 执行用时：248 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗：57.3 MB, 在所有 C# 提交中击败了 100.00% 的用户
        /// 通过测试用例：45 / 45
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxEqualFreq(int[] nums)
        {
            var numToCount = new Dictionary<int, int>();
            var countToCount = new Dictionary<int, int>();
            var result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (!numToCount.ContainsKey(num))
                {
                    numToCount[num] = 1;
                }
                else
                {
                    var preCount = numToCount[num];
                    countToCount[preCount]--;
                    if (countToCount[preCount] == 0) countToCount.Remove(preCount);

                    numToCount[num]++;
                }

                if (!countToCount.ContainsKey(numToCount[num])) countToCount[numToCount[num]] = 1;
                else countToCount[numToCount[num]]++;

                if (countToCount.Count == 2)
                {
                    var big = countToCount.Keys.Max();
                    var small = countToCount.Keys.Min();
                    if ((big == small + 1 && countToCount[big] == 1)
                        || (small == 1 && countToCount[small] == 1)) result = i + 1;
                }
                else if (countToCount.Count == 1
                         && (countToCount.ContainsKey(1) || countToCount.Values.All(v => v == 1))) result = i + 1;
            }

            return result;
        }
    }
}