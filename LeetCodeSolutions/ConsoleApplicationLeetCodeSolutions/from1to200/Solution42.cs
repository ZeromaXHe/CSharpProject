using System;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 42. 接雨水 | 难度：困难 | 标签：栈、数组、双指针、动态规划、单调栈
    /// 给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。
    /// 
    /// 示例 1：
    /// 输入：height = [0,1,0,2,1,0,1,3,2,1,2,1]
    /// 输出：6
    /// 解释：上面是由数组 [0,1,0,2,1,0,1,3,2,1,2,1] 表示的高度图，在这种情况下，可以接 6 个单位的雨水（蓝色部分表示雨水）。 
    /// 
    /// 示例 2：
    /// 输入：height = [4,2,0,3,2,5]
    /// 输出：9
    /// 
    /// 提示：
    /// n == height.length
    /// 1 <= n <= 2 * 104
    /// 0 <= height[i] <= 105
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/trapping-rain-water
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution42
    {
        /// <summary>
        /// 执行用时：100 ms, 在所有 C# 提交中击败了 30.26% 的用户
        /// 内存消耗：41.2 MB, 在所有 C# 提交中击败了 91.12% 的用户
        /// 通过测试用例：322 / 322
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            var l = 0;
            var lmax = 0;
            var r = height.Length - 1;
            var rmax = height.Length - 1;
            var result = 0;
            while (l <= r)
            {
                if (height[lmax] > height[rmax])
                {
                    if (height[r] > height[rmax]) rmax = r;
                    else result += height[rmax] - height[r];
                    r--;
                }
                else
                {
                    if (height[l] > height[lmax]) lmax = l;
                    else result += height[lmax] - height[l];
                    l++;
                }
            }

            return result;
        }
    }
}