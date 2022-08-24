using System;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 384. 打乱数组 | 难度：中等 | 标签：
    /// 给你一个整数数组 nums ，设计算法来打乱一个没有重复元素的数组。打乱后，数组的所有排列应该是 等可能 的。
    /// 
    /// 实现 Solution class:
    /// 
    /// Solution(int[] nums) 使用整数数组 nums 初始化对象
    /// int[] reset() 重设数组到它的初始状态并返回
    /// int[] shuffle() 返回数组随机打乱后的结果
    /// 
    /// 示例 1：
    /// 输入
    /// ["Solution", "shuffle", "reset", "shuffle"]
    /// [[[1, 2, 3]], [], [], []]
    /// 输出
    /// [null, [3, 1, 2], [1, 2, 3], [1, 3, 2]]
    /// 
    /// 解释
    /// Solution solution = new Solution([1, 2, 3]);
    /// solution.shuffle();    // 打乱数组 [1,2,3] 并返回结果。任何 [1,2,3]的排列返回的概率应该相同。例如，返回 [3, 1, 2]
    /// solution.reset();      // 重设数组到它的初始状态 [1, 2, 3] 。返回 [1, 2, 3]
    /// solution.shuffle();    // 随机返回数组 [1, 2, 3] 打乱后的结果。例如，返回 [1, 3, 2]
    /// 
    /// 提示：
    /// 1 <= nums.length <= 50
    /// -106 <= nums[i] <= 106
    /// nums 中的所有元素都是 唯一的
    /// 最多可以调用 104 次 reset 和 shuffle
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/shuffle-an-array
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution384
    {
        /// <summary>
        /// 执行用时：196 ms, 在所有 C# 提交中击败了 25.20% 的用户
        /// 内存消耗：62 MB, 在所有 C# 提交中击败了 89.76% 的用户
        /// 通过测试用例：8 / 8
        /// </summary>
        public class Solution
        {
            private int[] backup;
            private int[] shuffle;
            private Random rand;

            public Solution(int[] nums)
            {
                backup = nums;
                shuffle = new int[nums.Length];
                Array.Copy(nums, shuffle, nums.Length);
                rand = new Random();
            }

            public int[] Reset()
            {
                return backup;
            }

            public int[] Shuffle()
            {
                for (int i = shuffle.Length; i >= 2; i--)
                {
                    var r = rand.Next(i);
                    if (r != i - 1)
                    {
                        var tmp = shuffle[i - 1];
                        shuffle[i - 1] = shuffle[r];
                        shuffle[r] = tmp;
                    }
                }

                return shuffle;
            }
        }

        /**
         * Your Solution object will be instantiated and called as such:
         * Solution obj = new Solution(nums);
         * int[] param_1 = obj.Reset();
         * int[] param_2 = obj.Shuffle();
         */
    }
}