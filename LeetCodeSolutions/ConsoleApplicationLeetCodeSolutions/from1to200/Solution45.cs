namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 45. 跳跃游戏 II | 难度：中等 | 标签：贪心、数组、动态规划
    /// 给你一个非负整数数组 nums ，你最初位于数组的第一个位置。
    /// 
    /// 数组中的每个元素代表你在该位置可以跳跃的最大长度。
    /// 
    /// 你的目标是使用最少的跳跃次数到达数组的最后一个位置。
    /// 
    /// 假设你总是可以到达数组的最后一个位置。
    /// 
    /// 示例 1:
    /// 输入: nums = [2,3,1,1,4]
    /// 输出: 2
    /// 解释: 跳到最后一个位置的最小跳跃数是 2。
    /// 从下标为 0 跳到下标为 1 的位置，跳 1 步，然后跳 3 步到达数组的最后一个位置。
    /// 
    /// 示例 2:
    /// 输入: nums = [2,3,0,1,4]
    /// 输出: 2
    /// 
    /// 提示:
    /// 1 <= nums.length <= 104
    /// 0 <= nums[i] <= 1000
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/jump-game-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution45
    {
        /// <summary>
        /// 执行用时：92 ms, 在所有 C# 提交中击败了 75.41% 的用户
        /// 内存消耗：41.7 MB, 在所有 C# 提交中击败了 20.00% 的用户
        /// 通过测试用例：109 / 109
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Jump(int[] nums)
        {
            var max = nums[0];
            var next = max;
            var jump = 0;
            var i = 1;
            while (i < nums.Length)
            {
                while (i < nums.Length && i <= max)
                {
                    if (nums[i] + i > next) next = nums[i] + i;
                    i++;
                }

                jump++;
                max = next;
            }

            return jump;
        }
    }
}