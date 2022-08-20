using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 120. 三角形最小路径和 | 难度：中等 | 标签：数组、动态规划
    /// 给定一个三角形 triangle ，找出自顶向下的最小路径和。
    /// 
    /// 每一步只能移动到下一行中相邻的结点上。相邻的结点 在这里指的是 下标 与 上一层结点下标 相同或者等于 上一层结点下标 + 1 的两个结点。也就是说，如果正位于当前行的下标 i ，那么下一步可以移动到下一行的下标 i 或 i + 1 。
    /// 
    /// 示例 1：
    /// 输入：triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
    /// 输出：11
    /// 解释：如下面简图所示：
    /// 2
    /// 3 4
    /// 6 5 7
    /// 4 1 8 3
    /// 自顶向下的最小路径和为 11（即，2 + 3 + 5 + 1 = 11）。
    /// 
    /// 示例 2：
    /// 输入：triangle = [[-10]]
    /// 输出：-10
    /// 
    /// 提示：
    /// 1 <= triangle.length <= 200
    /// triangle[0].length == 1
    /// triangle[i].length == triangle[i - 1].length + 1
    /// -104 <= triangle[i][j] <= 104
    /// 
    /// 进阶：
    /// 你可以只使用 O(n) 的额外空间（n 为三角形的总行数）来解决这个问题吗？
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/triangle
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution120
    {
        /// <summary>
        /// 执行用时：68 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗：39 MB, 在所有 C# 提交中击败了 21.43% 的用户
        /// 通过测试用例：44 / 44
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var dp = new int[triangle.Count];
            dp[0] = triangle[0][0];
            var i = -1;
            var j = 0;
            foreach (var line in triangle)
            {
                i++;
                if (i == 0) continue;
                j = 0;
                var pre = 100000000;
                foreach (var num in line)
                {
                    var tmp = dp[j];
                    dp[j] = Math.Min(pre, j < i ? dp[j] : 100000000) + num;
                    pre = tmp;
                    j++;
                }
            }

            return dp.Min();
        }
    }
}