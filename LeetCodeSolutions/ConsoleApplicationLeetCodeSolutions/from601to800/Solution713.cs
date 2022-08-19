namespace ConsoleApplicationLeetCodeSolutions.from601to800
{
    /// <summary>
    /// 713. 乘积小于 K 的子数组 | 难度：中等 | 标签：数组、滑动窗口
    /// 给你一个整数数组 nums 和一个整数 k ，请你返回子数组内所有元素的乘积严格小于 k 的连续子数组的数目。
    /// 
    /// 示例 1：
    /// 输入：nums = [10,5,2,6], k = 100
    /// 输出：8
    /// 解释：8 个乘积小于 100 的子数组分别为：[10]、[5]、[2],、[6]、[10,5]、[5,2]、[2,6]、[5,2,6]。
    /// 需要注意的是 [10,5,2] 并不是乘积小于 100 的子数组。
    /// 
    /// 示例 2：
    /// 输入：nums = [1,2,3], k = 0
    /// 输出：0
    /// 
    /// 提示: 
    /// 1 <= nums.length <= 3 * 104
    /// 1 <= nums[i] <= 1000
    /// 0 <= k <= 106
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/subarray-product-less-than-k
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution713
    {
        /// <summary>
        /// 执行用时：156 ms, 在所有 C# 提交中击败了 89.66% 的用户
        /// 内存消耗：64.2 MB, 在所有 C# 提交中击败了 18.97% 的用户
        /// 通过测试用例：97 / 97
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k == 0) return 0;
            var prod = 1;
            var l = 0;
            var r = 0;
            var count = 0;
            while (l < nums.Length)
            {
                while (r < nums.Length && prod * nums[r] < k)
                {
                    prod *= nums[r];
                    r++;
                }

                count += r - l;
                if (r > l) prod /= nums[l];
                else r++;
                l++;
            }

            return count;
        }
    }
}