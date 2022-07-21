using System.Linq;

namespace ConsoleApplicationLeetCodeSolutions.lcp
{
    /// <summary>
    /// LCP 06. 拿硬币 | 难度：简单 | 标签：
    /// 桌上有 n 堆力扣币，每堆的数量保存在数组 coins 中。我们每次可以选择任意一堆，拿走其中的一枚或者两枚，求拿完所有力扣币的最少次数。
    /// 
    /// 示例 1：
    /// 输入：[4,2,1]
    /// 输出：4
    /// 解释：第一堆力扣币最少需要拿 2 次，第二堆最少需要拿 1 次，第三堆最少需要拿 1 次，总共 4 次即可拿完。
    /// 
    /// 示例 2：
    /// 输入：[2,3,10]
    /// 输出：8
    /// 
    /// 限制：
    /// 1 <= n <= 4
    /// 1 <= coins[i] <= 10
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/na-ying-bi
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class SolutionLcp06
    {
        /// <summary>
        /// 执行用时：76 ms, 在所有 C# 提交中击败了 82.22% 的用户
        /// 内存消耗：37.3 MB, 在所有 C# 提交中击败了 11.11% 的用户
        /// 通过测试用例：102 / 102
        /// </summary>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int MinCount(int[] coins)
        {
            /*
             * 执行用时：116 ms, 在所有 C# 提交中击败了 6.67% 的用户
             * 内存消耗：37.4 MB, 在所有 C# 提交中击败了 6.67% 的用户
             * 通过测试用例：102 / 102
             */
            // return coins.Select(coin => (coin % 2 == 0 ? 0 : 1) + coin / 2).Sum();
            return coins.Sum(c => (c + 1) / 2);
        }
    }
}