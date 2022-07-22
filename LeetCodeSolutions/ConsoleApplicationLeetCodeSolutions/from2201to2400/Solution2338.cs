using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from2201to2400
{
    /// <summary>
    /// 2338. 统计理想数组的数目 | 难度：困难 | 标签：数学、动态规划、组合数学、数论
    /// 给你两个整数 n 和 maxValue ，用于描述一个 理想数组 。
    /// 
    /// 对于下标从 0 开始、长度为 n 的整数数组 arr ，如果满足以下条件，则认为该数组是一个 理想数组 ：
    /// 
    /// 每个 arr[i] 都是从 1 到 maxValue 范围内的一个值，其中 0 <= i < n 。
    /// 每个 arr[i] 都可以被 arr[i - 1] 整除，其中 0 < i < n 。
    /// 返回长度为 n 的 不同 理想数组的数目。由于答案可能很大，返回对 109 + 7 取余的结果。
    /// 
    /// 示例 1：
    /// 输入：n = 2, maxValue = 5
    /// 输出：10
    /// 解释：存在以下理想数组：
    /// - 以 1 开头的数组（5 个）：[1,1]、[1,2]、[1,3]、[1,4]、[1,5]
    /// - 以 2 开头的数组（2 个）：[2,2]、[2,4]
    /// - 以 3 开头的数组（1 个）：[3,3]
    /// - 以 4 开头的数组（1 个）：[4,4]
    /// - 以 5 开头的数组（1 个）：[5,5]
    /// 共计 5 + 2 + 1 + 1 + 1 = 10 个不同理想数组。
    /// 
    /// 示例 2：
    /// 输入：n = 5, maxValue = 3
    /// 输出：11
    /// 解释：存在以下理想数组：
    /// - 以 1 开头的数组（9 个）：
    /// - 不含其他不同值（1 个）：[1,1,1,1,1] 
    /// - 含一个不同值 2（4 个）：[1,1,1,1,2], [1,1,1,2,2], [1,1,2,2,2], [1,2,2,2,2]
    /// - 含一个不同值 3（4 个）：[1,1,1,1,3], [1,1,1,3,3], [1,1,3,3,3], [1,3,3,3,3]
    /// - 以 2 开头的数组（1 个）：[2,2,2,2,2]
    /// - 以 3 开头的数组（1 个）：[3,3,3,3,3]
    /// 共计 9 + 1 + 1 = 11 个不同理想数组。
    /// 
    /// 提示：
    /// 2 <= n <= 104
    /// 1 <= maxValue <= 104
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/count-the-number-of-ideal-arrays
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution2338
    {
        private static readonly int MOD = (int) 1e9 + 7, MAX = (int) 1e4 + 1, MAX_K = 13;
        private static List<int>[] primeFactorCounts = new List<int>[MAX];
        private static int[,] combination = new int[MAX + MAX_K, MAX_K + 1];

        static Solution2338()
        {
            // 对 1 到 MAX 的所有数字求质因数乘的次数，存入 primeFactorCounts
            for (var i = 1; i < MAX; i++)
            {
                primeFactorCounts[i] = new List<int>();
                var x = i;
                for (var prime = 2; prime * prime <= x; prime++)
                {
                    if (x % prime == 0)
                    {
                        // 计算质因数乘的次数
                        var count = 1;
                        for (x /= prime; x % prime == 0; x /= prime) count++;
                        primeFactorCounts[i].Add(count);
                    }
                }

                if (x > 1) primeFactorCounts[i].Add(1);
            }

            combination[0, 0] = 1;
            for (var i = 1; i < MAX + MAX_K; i++)
            {
                combination[i, 0] = 1;
                // 为什么组合数最多只要枚举到 13？因为 2 的 13 次方为 8192。如果次数再高，n 会超过 1e4,所以最多只要枚举到 13 就可以了
                for (var j = 1; j <= Math.Min(i, MAX_K); j++)
                {
                    // 杨辉三角公式
                    combination[i, j] = (combination[i - 1, j] + combination[i - 1, j - 1]) % MOD;
                }
            }
        }

        /// <summary>
        /// 执行用时：28 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗：27.9 MB, 在所有 C# 提交中击败了 100.00% 的用户
        /// 通过测试用例：47 / 47
        /// </summary>
        /// <param name="n"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public int IdealArrays(int n, int maxValue)
        {
            var ans = 0L;
            for (var x = 1; x <= maxValue; ++x)
            {
                var mul = 1L;
                foreach (var count in primeFactorCounts[x])
                {
                    mul = mul * combination[n + count - 1, count] % MOD;
                }

                ans += mul;
            }

            return (int) (ans % MOD);
        }
    }
}