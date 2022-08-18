namespace ConsoleApplicationLeetCodeSolutions.from1601to1800
{
    /// <summary>
    /// 1712. 将数组分成三个子数组的方案数 | 难度：中等 | 标签：数组、双指针、二分查找、前缀和
    /// 我们称一个分割整数数组的方案是 好的 ，当它满足：
    /// 
    /// 数组被分成三个 非空 连续子数组，从左至右分别命名为 left ， mid ， right 。
    /// left 中元素和小于等于 mid 中元素和，mid 中元素和小于等于 right 中元素和。
    /// 给你一个 非负 整数数组 nums ，请你返回 好的 分割 nums 方案数目。由于答案可能会很大，请你将结果对 109 + 7 取余后返回。
    /// 
    /// 示例 1：
    /// 输入：nums = [1,1,1]
    /// 输出：1
    /// 解释：唯一一种好的分割方案是将 nums 分成 [1] [1] [1] 。
    /// 
    /// 示例 2：
    /// 输入：nums = [1,2,2,2,5,0]
    /// 输出：3
    /// 解释：nums 总共有 3 种好的分割方案：
    /// [1] [2] [2,2,5,0]
    /// [1] [2,2] [2,5,0]
    /// [1,2] [2,2] [5,0]
    /// 
    /// 示例 3：
    /// 输入：nums = [3,2,1]
    /// 输出：0
    /// 解释：没有好的分割方案。
    /// 
    /// 提示：
    /// 3 <= nums.length <= 105
    /// 0 <= nums[i] <= 104
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/ways-to-split-array-into-three-subarrays
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1712
    {
        /// <summary>
        /// 执行用时：216 ms, 在所有 C# 提交中击败了 87.50% 的用户
        /// 内存消耗：57.2 MB, 在所有 C# 提交中击败了 50.00% 的用户
        /// 通过测试用例：87 / 87
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int WaysToSplit(int[] nums)
        {
            var preSum = new int[nums.Length + 1];
            var sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                preSum[i + 1] = sum;
            }

            var first = 1;
            var count = 0;
            while (first <= nums.Length - 2)
            {
                if (preSum[first] > (sum + 2) / 3) break;
                var l = first + 1;
                var r = nums.Length - 1;
                var secondMin = -1;
                while (l <= r)
                {
                    var mid = (l + r) / 2;
                    if (preSum[mid] - preSum[first] >= preSum[first]
                        && sum - preSum[mid] >= preSum[mid] - preSum[first])
                    {
                        secondMin = mid;
                        r = mid - 1;
                    }
                    // 绝对不能写成 preSum[mid] < 2 * preSum[first]，会溢出
                    else if (preSum[mid] - preSum[first] < preSum[first]) l = mid + 1;
                    else r = mid - 1;
                }

                // 不能 break，会出现这次没找到，下个 first 找到了 second 的情况
                // 测试用例：
                // [8892,2631,7212,1188,6580,1690,5950,7425,8787,4361,9849,4063,9496,9140,9986,
                // 1058,2734,6961,8855,2567,7683,4770,40,850,72,2285,9328,6794,8632,9163,3928,6962,6545,
                // 6920,926,8885,1570,4454,6876,7447,8264,3123,2980,7276,470,8736,3153,3924,3129,7136,
                // 1739,1354,661,1309,6231,9890,58,4623,3555,3100,3437]
                if (secondMin == -1)
                {
                    first++;
                    continue;
                }

                l = secondMin + 1;
                r = nums.Length - 1;
                var secondMax = secondMin;
                while (l <= r)
                {
                    var mid = (l + r) / 2;
                    if (preSum[mid] - preSum[first] >= preSum[first]
                        && sum - preSum[mid] >= preSum[mid] - preSum[first])
                    {
                        secondMax = mid;
                        l = mid + 1;
                    }
                    else if (preSum[mid] - preSum[first] < preSum[first]) l = mid + 1;
                    else r = mid - 1;
                }

                count = (1 + secondMax - secondMin + count) % 1000000007;
                first++;
            }

            return count;
        }
    }
}