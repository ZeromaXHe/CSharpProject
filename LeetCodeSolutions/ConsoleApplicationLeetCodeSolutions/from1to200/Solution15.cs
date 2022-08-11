using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 15. 三数之和 | 难度：中等 | 标签：数组、双指针、排序
    /// 给你一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？请你找出所有和为 0 且不重复的三元组。
    /// 
    /// 注意：答案中不可以包含重复的三元组。
    /// 
    /// 示例 1：
    /// 输入：nums = [-1,0,1,2,-1,-4]
    /// 输出：[[-1,-1,2],[-1,0,1]]
    /// 
    /// 示例 2：
    /// 输入：nums = []
    /// 输出：[]
    /// 
    /// 示例 3：
    /// 输入：nums = [0]
    /// 输出：[]
    /// 
    /// 提示：
    /// 0 <= nums.length <= 3000
    /// -105 <= nums[i] <= 105
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/3sum
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution15
    {
        /// <summary>
        /// 执行用时：180 ms, 在所有 C# 提交中击败了 35.62% 的用户
        /// 内存消耗：58.3 MB, 在所有 C# 提交中击败了 36.29% 的用户
        /// 通过测试用例：311 / 311
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3) return new List<IList<int>>();
            Array.Sort(nums);
            if (nums[0] > 0 || nums[nums.Length - 1] < 0) return new List<IList<int>>();
            if (nums[0] == 0 || nums[nums.Length - 1] == 0)
            {
                if (nums.Count(num => num == 0) >= 3) return new List<IList<int>> {new List<int> {0, 0, 0}};
                return new List<IList<int>>();
            }

            var result = new List<IList<int>>();
            for (int i = 0; i <= nums.Length - 3; i++)
            {
                if (i > 0 && nums[i - 1] == nums[i]) continue;
                var j = i + 1;
                var k = nums.Length - 1;
                while (j < k)
                {
                    if (nums[j] + nums[k] > -nums[i])
                    {
                        while (k - 1 > j && nums[k - 1] == nums[k]) k--;
                        k--;
                    }
                    else if (nums[j] + nums[k] < -nums[i])
                    {
                        while (j + 1 < k && nums[j + 1] == nums[j]) j++;
                        j++;
                    }
                    else
                    {
                        result.Add(new List<int> {nums[i], nums[j], nums[k]});
                        while (k - 1 > j && nums[k - 1] == nums[k]) k--;
                        k--;
                        while (j + 1 < k && nums[j + 1] == nums[j]) j++;
                        j++;
                    }
                }
            }

            return result;
        }
    }
}