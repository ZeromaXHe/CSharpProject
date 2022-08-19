namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 413. 等差数列划分 | 难度：中等 | 标签：数组、动态规划
    /// 如果一个数列 至少有三个元素 ，并且任意两个相邻元素之差相同，则称该数列为等差数列。
    /// 
    /// 例如，[1,3,5,7,9]、[7,7,7,7] 和 [3,-1,-5,-9] 都是等差数列。
    /// 给你一个整数数组 nums ，返回数组 nums 中所有为等差数组的 子数组 个数。
    /// 
    /// 子数组 是数组中的一个连续序列。
    /// 
    /// 示例 1：
    /// 输入：nums = [1,2,3,4]
    /// 输出：3
    /// 解释：nums 中有三个子等差数组：[1, 2, 3]、[2, 3, 4] 和 [1,2,3,4] 自身。
    /// 
    /// 示例 2：
    /// 输入：nums = [1]
    /// 输出：0
    /// 
    /// 提示：
    /// 1 <= nums.length <= 5000
    /// -1000 <= nums[i] <= 1000
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/arithmetic-slices
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution413
    {
        /// <summary>
        /// 执行用时：92 ms, 在所有 C# 提交中击败了 12.12% 的用户
        /// 内存消耗：37.3 MB, 在所有 C# 提交中击败了 57.58% 的用户
        /// 通过测试用例：15 / 15
        ///
        /// 参考题解做的，然后才发现子数组是必须连续的，我还以为是那种可以随便选的子序列…… 那这道题其实不难
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumberOfArithmeticSlices(int[] nums)
        {
            int n = nums.Length;
            if (n <= 2)
            {
                return 0;
            }

            int d = nums[0] - nums[1], t = 0;
            int res = 0;
            // 因为等差数列的长度至少为 3，所以可以从 i=2 开始枚举
            for (int i = 2; i < n; ++i)
            {
                if (nums[i - 1] - nums[i] == d)
                {
                    ++t;
                }
                else
                {
                    d = nums[i - 1] - nums[i];
                    t = 0;
                }

                res += t;
            }

            return res;
        }
    }
}