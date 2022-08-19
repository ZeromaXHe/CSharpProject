using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplicationLeetCodeSolutions.from1601to1800
{
    /// <summary>
    /// 1654. 到家的最少跳跃次数 | 难度：中等 | 标签：广度优先搜索、数组、动态规划
    /// 有一只跳蚤的家在数轴上的位置 x 处。请你帮助它从位置 0 出发，到达它的家。
    /// 
    /// 跳蚤跳跃的规则如下：
    /// 
    /// 它可以 往前 跳恰好 a 个位置（即往右跳）。
    /// 它可以 往后 跳恰好 b 个位置（即往左跳）。
    /// 它不能 连续 往后跳 2 次。
    /// 它不能跳到任何 forbidden 数组中的位置。
    /// 跳蚤可以往前跳 超过 它的家的位置，但是它 不能跳到负整数 的位置。
    /// 
    /// 给你一个整数数组 forbidden ，其中 forbidden[i] 是跳蚤不能跳到的位置，同时给你整数 a， b 和 x ，请你返回跳蚤到家的最少跳跃次数。如果没有恰好到达 x 的可行方案，请你返回 -1 。
    /// 
    /// 示例 1：
    /// 输入：forbidden = [14,4,18,1,15], a = 3, b = 15, x = 9
    /// 输出：3
    /// 解释：往前跳 3 次（0 -> 3 -> 6 -> 9），跳蚤就到家了。
    /// 
    /// 示例 2：
    /// 输入：forbidden = [8,3,16,6,12,20], a = 15, b = 13, x = 11
    /// 输出：-1
    /// 
    /// 示例 3：
    /// 输入：forbidden = [1,6,2,14,5,17,4], a = 16, b = 9, x = 7
    /// 输出：2
    /// 解释：往前跳一次（0 -> 16），然后往回跳一次（16 -> 7），跳蚤就到家了。
    /// 
    /// 提示：
    /// 1 <= forbidden.length <= 1000
    /// 1 <= a, b, forbidden[i] <= 2000
    /// 0 <= x <= 2000
    /// forbidden 中所有位置互不相同。
    /// 位置 x 不在 forbidden 中。
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/minimum-jumps-to-reach-home
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1654
    {
        public void Test()
        {
            Console.WriteLine(MinimumJumps(new[] {1, 6, 2, 14, 5, 17, 4}, 16, 9, 7));
        }

        /// <summary>
        /// 执行用时：92 ms, 在所有 C# 提交中击败了 50.00% 的用户
        /// 内存消耗：39.9 MB, 在所有 C# 提交中击败了 100.00% 的用户
        /// 通过测试用例：95 / 95
        ///
        /// max 的跳出条件的推理还是比较有意思，参考题解才做出来。
        /// https://leetcode.cn/problems/minimum-jumps-to-reach-home/solution/dao-jia-de-zui-shao-tiao-yue-ci-shu-zui-duan-lu-zh/
        /// </summary>
        /// <param name="forbidden"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MinimumJumps(int[] forbidden, int a, int b, int x)
        {
            if (x == 0) return 0;
            var max = a < b ? Math.Max(x + b, forbidden.Max() + a + b) : x + b;
            // 第二维 0 对应向右访问到，1 对应向左访问到
            var visit = new bool[max + 1, 2];
            foreach (var f in forbidden)
            {
                if (f <= max)
                {
                    visit[f, 0] = true;
                    visit[f, 1] = true;
                }
            }

            var queue = new Queue<int>();
            queue.Enqueue(0);
            visit[0, 0] = true;
            visit[0, 1] = true;
            var count = 0;
            while (queue.Count > 0)
            {
                var c = queue.Count;
                while (c > 0)
                {
                    var deq = queue.Dequeue();
                    if (Math.Abs(deq) == x) return count;
                    if (deq <= 0)
                    {
                        if (a - deq <= max && !visit[a - deq, 0])
                        {
                            queue.Enqueue(a - deq);
                            visit[a - deq, 0] = true;
                            visit[a - deq, 1] = true;
                        }
                    }
                    else
                    {
                        if (a + deq <= max && !visit[a + deq, 0])
                        {
                            queue.Enqueue(a + deq);
                            visit[a + deq, 0] = true;
                            visit[a + deq, 1] = true;
                        }

                        if (deq - b > 0 && !visit[deq - b, 1])
                        {
                            queue.Enqueue(b - deq);
                            visit[deq - b, 1] = true;
                        }
                    }

                    c--;
                }

                count++;
            }

            return -1;
        }
    }
}