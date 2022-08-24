using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 202. 快乐数 | 难度：简单 | 标签：
    /// 编写一个算法来判断一个数 n 是不是快乐数。
    /// 
    /// 「快乐数」 定义为：
    /// 
    /// 对于一个正整数，每一次将该数替换为它每个位置上的数字的平方和。
    /// 然后重复这个过程直到这个数变为 1，也可能是 无限循环 但始终变不到 1。
    /// 如果这个过程 结果为 1，那么这个数就是快乐数。
    /// 如果 n 是 快乐数 就返回 true ；不是，则返回 false 。
    /// 
    /// 示例 1：
    /// 输入：n = 19
    /// 输出：true
    /// 解释：
    /// 12 + 92 = 82
    /// 82 + 22 = 68
    /// 62 + 82 = 100
    /// 12 + 02 + 02 = 1
    /// 
    /// 示例 2：
    /// 输入：n = 2
    /// 输出：false
    /// 
    /// 提示：
    /// 1 <= n <= 231 - 1
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/happy-number
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution202
    {
        HashSet<int> Set = new HashSet<int> {4, 16, 37, 58, 89, 145, 42, 20};

        /// <summary>
        /// 执行用时：36 ms, 在所有 C# 提交中击败了 28.62% 的用户
        /// 内存消耗：28.4 MB, 在所有 C# 提交中击败了 41.23% 的用户
        /// 通过测试用例：404 / 404
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsHappy(int n)
        {
            while (n != 1 && !Set.Contains(n))
            {
                var sum = 0;
                while (n > 0)
                {
                    sum += n % 10 * (n % 10);
                    n /= 10;
                }

                n = sum;
            }

            return n == 1;
        }
    }
}