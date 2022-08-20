using System;

namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 528. 按权重随机选择 | 难度：中等 | 标签：数学、二分查找、前缀和、随机化
    /// 给你一个 下标从 0 开始 的正整数数组 w ，其中 w[i] 代表第 i 个下标的权重。
    /// 
    /// 请你实现一个函数 pickIndex ，它可以 随机地 从范围 [0, w.length - 1] 内（含 0 和 w.length - 1）选出并返回一个下标。选取下标 i 的 概率 为 w[i] / sum(w) 。
    /// 
    /// 例如，对于 w = [1, 3]，挑选下标 0 的概率为 1 / (1 + 3) = 0.25 （即，25%），而选取下标 1 的概率为 3 / (1 + 3) = 0.75（即，75%）。
    /// 
    /// 示例 1：
    /// 输入：
    /// ["Solution","pickIndex"]
    /// [[[1]],[]]
    /// 输出：
    /// [null,0]
    /// 解释：
    /// Solution solution = new Solution([1]);
    /// solution.pickIndex(); // 返回 0，因为数组中只有一个元素，所以唯一的选择是返回下标 0。
    /// 
    /// 示例 2：
    /// 输入：
    /// ["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
    /// [[[1,3]],[],[],[],[],[]]
    /// 输出：
    /// [null,1,1,1,1,0]
    /// 解释：
    /// Solution solution = new Solution([1, 3]);
    /// solution.pickIndex(); // 返回 1，返回下标 1，返回该下标概率为 3/4 。
    /// solution.pickIndex(); // 返回 1
    /// solution.pickIndex(); // 返回 1
    /// solution.pickIndex(); // 返回 1
    /// solution.pickIndex(); // 返回 0，返回下标 0，返回该下标概率为 1/4 。
    /// 
    /// 由于这是一个随机问题，允许多个答案，因此下列输出都可以被认为是正确的:
    /// [null,1,1,1,1,0]
    /// [null,1,1,1,1,1]
    /// [null,1,1,1,0,0]
    /// [null,1,1,1,0,1]
    /// [null,1,0,1,0,0]
    /// ......
    /// 诸若此类。
    /// 
    /// 提示：
    /// 1 <= w.length <= 104
    /// 1 <= w[i] <= 105
    /// pickIndex 将被调用不超过 104 次
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/random-pick-with-weight
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution528
    {
        /// <summary>
        /// 执行用时：168 ms, 在所有 C# 提交中击败了 63.64% 的用户
        /// 内存消耗：65 MB, 在所有 C# 提交中击败了 40.91% 的用户
        /// 通过测试用例：57 / 57
        /// </summary>
        public class Solution
        {
            private int[] preSum;
            private Random rand = new Random();

            public Solution(int[] w)
            {
                preSum = new int[w.Length];
                var sum = 0;
                for (int i = 0; i < w.Length; i++)
                {
                    sum += w[i];
                    preSum[i] = sum;
                }
            }

            public int PickIndex()
            {
                var r = rand.Next(preSum[preSum.Length - 1]);
                var idx = Array.BinarySearch(preSum, r);
                // Console.WriteLine($"r: {r}, idx: {idx}, preSum: [{String.Join(",", preSum)}]");
                return idx >= 0 ? idx + 1 : -idx - 1;
            }
        }

        /**
         * Your Solution object will be instantiated and called as such:
         * Solution obj = new Solution(w);
         * int param_1 = obj.PickIndex();
         */
    }
}