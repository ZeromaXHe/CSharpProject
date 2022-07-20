using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 1. 两数之和 | 难度：简单 | 标签：数组、哈希表
    /// 给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 target  的那 两个 整数，并返回它们的数组下标。
    /// 
    /// 你可以假设每种输入只会对应一个答案。但是，数组中同一个元素在答案里不能重复出现。
    /// 
    /// 你可以按任意顺序返回答案。
    /// 
    /// 示例 1：
    /// 
    /// 输入：nums = [2,7,11,15], target = 9
    /// 输出：[0,1]
    /// 解释：因为 nums[0] + nums[1] == 9 ，返回 [0, 1] 。
    /// 示例 2：
    /// 
    /// 输入：nums = [3,2,4], target = 6
    /// 输出：[1,2]
    /// 示例 3：
    /// 
    /// 输入：nums = [3,3], target = 6
    /// 输出：[0,1]
    /// 
    /// 提示：
    /// 2 <= nums.length <= 104
    /// -109 <= nums[i] <= 109
    /// -109 <= target <= 109
    /// 只会存在一个有效答案
    /// 进阶：你可以想出一个时间复杂度小于 O(n2) 的算法吗？
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/two-sum
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1
    {
        /// <summary>
        /// 执行用时：136 ms, 在所有 C# 提交中击败了 82.20% 的用户
        /// 内存消耗：43.8 MB, 在所有 C# 提交中击败了 13.32% 的用户
        /// 通过测试用例：57 / 57
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i])) return new[] {dict[target - nums[i]], i};
                // if (!dict.ContainsKey(nums[i])) dict.Add(nums[i], i);
                dict[nums[i]] = i;
            }

            return new[] {-1, -1};
        }
    }
}