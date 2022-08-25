using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1401to1600
{
    /// <summary>
    /// 1562. 查找大小为 M 的最新分组 | 难度：中等 | 标签：数组、二分查找、模拟
    /// 给你一个数组 arr ，该数组表示一个从 1 到 n 的数字排列。有一个长度为 n 的二进制字符串，该字符串上的所有位最初都设置为 0 。
    /// 
    /// 在从 1 到 n 的每个步骤 i 中（假设二进制字符串和 arr 都是从 1 开始索引的情况下），二进制字符串上位于位置 arr[i] 的位将会设为 1 。
    /// 
    /// 给你一个整数 m ，请你找出二进制字符串上存在长度为 m 的一组 1 的最后步骤。一组 1 是一个连续的、由 1 组成的子串，且左右两边不再有可以延伸的 1 。
    /// 
    /// 返回存在长度 恰好 为 m 的 一组 1  的最后步骤。如果不存在这样的步骤，请返回 -1 。
    /// 
    /// 示例 1：
    /// 输入：arr = [3,5,1,2,4], m = 1
    /// 输出：4
    /// 解释：
    /// 步骤 1："00100"，由 1 构成的组：["1"]
    /// 步骤 2："00101"，由 1 构成的组：["1", "1"]
    /// 步骤 3："10101"，由 1 构成的组：["1", "1", "1"]
    /// 步骤 4："11101"，由 1 构成的组：["111", "1"]
    /// 步骤 5："11111"，由 1 构成的组：["11111"]
    /// 存在长度为 1 的一组 1 的最后步骤是步骤 4 。
    /// 
    /// 示例 2：
    /// 输入：arr = [3,1,5,4,2], m = 2
    /// 输出：-1
    /// 解释：
    /// 步骤 1："00100"，由 1 构成的组：["1"]
    /// 步骤 2："10100"，由 1 构成的组：["1", "1"]
    /// 步骤 3："10101"，由 1 构成的组：["1", "1", "1"]
    /// 步骤 4："10111"，由 1 构成的组：["1", "111"]
    /// 步骤 5："11111"，由 1 构成的组：["11111"]
    /// 不管是哪一步骤都无法形成长度为 2 的一组 1 。
    /// 
    /// 示例 3：
    /// 输入：arr = [1], m = 1
    /// 输出：1
    /// 
    /// 示例 4：
    /// 输入：arr = [2,1], m = 2
    /// 输出：2
    /// 
    /// 提示：
    /// n == arr.length
    /// 1 <= n <= 10^5
    /// 1 <= arr[i] <= n
    /// arr 中的所有整数 互不相同
    /// 1 <= m <= arr.length
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/find-latest-group-of-size-m
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1562
    {
        /// <summary>
        /// 执行用时：220 ms, 在所有 C# 提交中击败了 75.00% 的用户
        /// 内存消耗：54.3 MB, 在所有 C# 提交中击败了 50.00% 的用户
        /// 通过测试用例：114 / 114
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int FindLatestStep(int[] arr, int m)
        {
            // t 数组存储对应索引的 1 的插入时间
            var t = new int[arr.Length + 2];
            t[0] = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                t[arr[i]] = i;
            }

            t[arr.Length + 1] = int.MaxValue;
            var stack = new Stack<int>();
            var ans = -1;
            for (int i = 0; i < t.Length; i++)
            {
                if (stack.Count > 0)
                {
                    // 代表前面栈顶对应的 1 的插入时间比现在第 i 个位置上的 1 插入时间早
                    while (t[stack.Peek()] < t[i])
                    {
                        stack.Pop();
                        // 直接弹出，使用下一个栈顶的位置（对应之前连续 1 的左端）来计算连续的 1 长度
                        if (i - stack.Peek() - 1 == m)
                        {
                            if (stack.Peek() == 0 && i == arr.Length + 1) return arr.Length;
                            var min = Math.Min(t[stack.Peek()], t[i]);
                            if (min != int.MaxValue && min > ans) ans = min;
                        }
                    }
                }

                stack.Push(i);
            }

            return ans;
        }
    }
}