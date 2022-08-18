using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 46. 全排列 | 难度：中等 | 标签：数组、回溯
    /// 给定一个不含重复数字的数组 nums ，返回其 所有可能的全排列 。你可以 按任意顺序 返回答案。
    /// 
    /// 示例 1：
    /// 输入：nums = [1,2,3]
    /// 输出：[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
    /// 
    /// 示例 2：
    /// 输入：nums = [0,1]
    /// 输出：[[0,1],[1,0]]
    /// 
    /// 示例 3：
    /// 输入：nums = [1]
    /// 输出：[[1]]
    /// 
    /// 提示：
    /// 1 <= nums.length <= 6
    /// -10 <= nums[i] <= 10
    /// nums 中的所有整数 互不相同
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/permutations
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution46
    {
        /// <summary>
        /// 执行用时：152 ms, 在所有 C# 提交中击败了 14.56% 的用户
        /// 内存消耗：42.3 MB, 在所有 C# 提交中击败了 56.34% 的用户
        /// 通过测试用例：26 / 26
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            var list = new List<IList<int>>();
            Backtrack(nums, list, 0);
            return list;
        }

        private void Backtrack(int[] nums, List<IList<int>> list, int i)
        {
            if (i == nums.Length)
            {
                var perm = new List<int>();
                foreach (var num in nums)
                {
                    perm.Add(num);
                }

                list.Add(perm);
                return;
            }

            Backtrack(nums, list, i + 1);
            for (int j = i + 1; j < nums.Length; j++)
            {
                var tmp = nums[i];
                nums[i] = nums[j];
                nums[j] = tmp;
                Backtrack(nums, list, i + 1);
                nums[j] = nums[i];
                nums[i] = tmp;
            }
        }
    }
}