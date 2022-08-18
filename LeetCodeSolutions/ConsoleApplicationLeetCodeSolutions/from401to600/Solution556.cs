using System;

namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 556. 下一个更大元素 III | 难度：中等 | 标签：数学、双指针、字符串
    /// 给你一个正整数 n ，请你找出符合条件的最小整数，其由重新排列 n 中存在的每位数字组成，并且其值大于 n 。如果不存在这样的正整数，则返回 -1 。
    /// 
    /// 注意 ，返回的整数应当是一个 32 位整数 ，如果存在满足题意的答案，但不是 32 位整数 ，同样返回 -1 。
    /// 
    /// 示例 1：
    /// 输入：n = 12
    /// 输出：21
    /// 
    /// 示例 2：
    /// 输入：n = 21
    /// 输出：-1
    /// 
    /// 提示：
    /// 1 <= n <= 231 - 1
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/next-greater-element-iii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution556
    {
        /// <summary>
        /// 执行用时：12 ms, 在所有 C# 提交中击败了 99.48% 的用户
        /// 内存消耗：26.3 MB, 在所有 C# 提交中击败了 32.46% 的用户
        /// 通过测试用例：39 / 39
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NextGreaterElement(int n)
        {
            var div = 10;
            var divPre = 1;
            while (n / div > 0)
            {
                var digit = n / div % 10;
                var digitPre = n / divPre % 10;
                if (digit < digitPre)
                {
                    var multi = 1;
                    while (n / multi % 10 <= digit)
                    {
                        multi *= 10;
                    }

                    var result = n + digit * (multi - (long) div) + n / multi % 10 * ((long) div - multi);
                    var sort = Convert.ToString(result % div).ToCharArray();
                    Array.Sort(sort);
                    var sortLong = long.Parse(new string(sort));
                    result += sortLong - result % div;
                    if (result > int.MaxValue) return -1;
                    return (int) result;
                }

                divPre = div;
                div *= 10;
            }

            return -1;
        }
    }
}