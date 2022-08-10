namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 70. 爬楼梯 | 难度：简单 | 标签：记忆化搜索、数学、动态规划
    /// 假设你正在爬楼梯。需要 n 阶你才能到达楼顶。
    /// 
    /// 每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？
    /// 
    /// 示例 1：
    /// 输入：n = 2
    /// 输出：2
    /// 解释：有两种方法可以爬到楼顶。
    /// 1. 1 阶 + 1 阶
    /// 2. 2 阶
    /// 
    /// 示例 2：
    /// 输入：n = 3
    /// 输出：3
    /// 解释：有三种方法可以爬到楼顶。
    /// 1. 1 阶 + 1 阶 + 1 阶
    /// 2. 1 阶 + 2 阶
    /// 3. 2 阶 + 1 阶
    /// 
    /// 提示：
    /// 1 <= n <= 45
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/climbing-stairs
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution70
    {
        /// <summary>
        /// 执行用时：20 ms, 在所有 C# 提交中击败了 80.82% 的用户
        /// 内存消耗：26 MB, 在所有 C# 提交中击败了 47.44% 的用户
        /// 通过测试用例：45 / 45
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            if (n == 1) return 1;
            int[] fib = {1, 1};
            for (int i = 2; i <= n; i++)
            {
                fib[i & 1] = fib[0] + fib[1];
            }

            return fib[n & 1];
        }
    }
}