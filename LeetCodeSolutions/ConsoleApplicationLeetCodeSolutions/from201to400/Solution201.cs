namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 201. 数字范围按位与 | 难度：中等 | 标签：位运算
    /// 给你两个整数 left 和 right ，表示区间 [left, right] ，返回此区间内所有数字 按位与 的结果（包含 left 、right 端点）。
    /// 
    /// 示例 1：
    /// 输入：left = 5, right = 7
    /// 输出：4
    /// 
    /// 示例 2：
    /// 输入：left = 0, right = 0
    /// 输出：0
    /// 
    /// 示例 3：
    /// 输入：left = 1, right = 2147483647
    /// 输出：0
    /// 
    /// 提示：
    /// 0 <= left <= right <= 231 - 1
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/bitwise-and-of-numbers-range
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution201
    {
        /// <summary>
        /// 执行用时：32 ms, 在所有 C# 提交中击败了 60.98% 的用户
        /// 内存消耗：26.8 MB, 在所有 C# 提交中击败了 36.59% 的用户
        /// 通过测试用例：8268 / 8268
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int RangeBitwiseAnd(int left, int right)
        {
            if (left == right) return left;
            var mult = 30;
            if (left < 1 << 30 && right < 1 << 30)
            {
                mult = 0;
                while (1 << mult <= left || 1 << mult <= right) mult++;
                mult--;
            }

            var result = 0;
            while (mult >= 0 && (left & (1 << mult)) == (right & (1 << mult)))
            {
                result += left & (1 << mult--);
            }

            return result;
        }

        /// <summary>
        /// 执行用时：36 ms, 在所有 C# 提交中击败了 43.90% 的用户
        /// 内存消耗：26.6 MB, 在所有 C# 提交中击败了 63.42% 的用户
        /// 通过测试用例：8268 / 8268
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int RangeBitwiseAnd_BitCalc(int left, int right)
        {
            // 抹去 right 最右边的 1，直到 right <= left
            while (left < right) right = right & (right - 1);
            return right;
        }
    }
}