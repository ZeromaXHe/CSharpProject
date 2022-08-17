namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 268. 丢失的数字 | 难度：简单 | 标签：位运算、数组、哈希表、数学、二分查找、排序
    /// 给定一个包含 [0, n] 中 n 个数的数组 nums ，找出 [0, n] 这个范围内没有出现在数组中的那个数。
    /// 
    /// 示例 1：
    /// 输入：nums = [3,0,1]
    /// 输出：2
    /// 解释：n = 3，因为有 3 个数字，所以所有的数字都在范围 [0,3] 内。2 是丢失的数字，因为它没有出现在 nums 中。
    /// 
    /// 示例 2：
    /// 输入：nums = [0,1]
    /// 输出：2
    /// 解释：n = 2，因为有 2 个数字，所以所有的数字都在范围 [0,2] 内。2 是丢失的数字，因为它没有出现在 nums 中。
    /// 
    /// 示例 3：
    /// 输入：nums = [9,6,4,2,3,5,7,0,1]
    /// 输出：8
    /// 解释：n = 9，因为有 9 个数字，所以所有的数字都在范围 [0,9] 内。8 是丢失的数字，因为它没有出现在 nums 中。
    /// 
    /// 示例 4：
    /// 输入：nums = [0]
    /// 输出：1
    /// 解释：n = 1，因为有 1 个数字，所以所有的数字都在范围 [0,1] 内。1 是丢失的数字，因为它没有出现在 nums 中。
    /// 
    /// 提示：
    /// n == nums.length
    /// 1 <= n <= 104
    /// 0 <= nums[i] <= n
    /// nums 中的所有数字都 独一无二
    /// 
    /// 进阶：你能否实现线性时间复杂度、仅使用额外常数空间的算法解决此问题?
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/missing-number
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution268
    {
        /// <summary>
        /// 执行用时：80 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗：43 MB, 在所有 C# 提交中击败了 30.77% 的用户
        /// 通过测试用例：122 / 122
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingNumber(int[] nums)
        {
            var existN = false;
            var n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == n || nums[i] == 2 * n + 1)
                {
                    existN = true;
                }
                else
                {
                    nums[nums[i] % (n + 1)] += n + 1;
                }
            }

            if (!existN) return n;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] < n + 1) return i;
            }

            return n;
        }
    }
}