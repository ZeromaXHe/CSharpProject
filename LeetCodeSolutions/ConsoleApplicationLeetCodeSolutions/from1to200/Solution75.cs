﻿namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 75. 颜色分类 | 难度：中等 | 标签：数组、双指针、排序
    /// 给定一个包含红色、白色和蓝色、共 n 个元素的数组 nums ，原地对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。
    /// 
    /// 我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。
    /// 
    /// 必须在不使用库的sort函数的情况下解决这个问题。
    /// 
    /// 示例 1：
    /// 输入：nums = [2,0,2,1,1,0]
    /// 输出：[0,0,1,1,2,2]
    /// 
    /// 示例 2：
    /// 输入：nums = [2,0,1]
    /// 输出：[0,1,2]
    /// 
    /// 提示：
    /// n == nums.length
    /// 1 <= n <= 300
    /// nums[i] 为 0、1 或 2
    /// 
    /// 进阶：
    /// 你可以不使用代码库中的排序函数来解决这道题吗？
    /// 你能想出一个仅使用常数空间的一趟扫描算法吗？
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/sort-colors
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution75
    {
        /// <summary>
        /// 执行用时：120 ms, 在所有 C# 提交中击败了 93.91% 的用户
        /// 内存消耗：41.2 MB, 在所有 C# 提交中击败了 60.67% 的用户
        /// 通过测试用例：87 / 87
        /// </summary>
        /// <param name="nums"></param>
        public void SortColors(int[] nums)
        {
            var l = 0;
            var r = nums.Length - 1;
            var p = 0;
            while (p <= r)
            {
                while (p >= l && p <= r && nums[p] != 1)
                {
                    if (nums[p] == 0)
                    {
                        var temp = nums[l];
                        nums[l] = nums[p];
                        nums[p] = temp;
                        l++;
                    }
                    else
                    {
                        var temp = nums[r];
                        nums[r] = nums[p];
                        nums[p] = temp;
                        r--;
                    }
                }

                p++;
            }
        }
    }
}