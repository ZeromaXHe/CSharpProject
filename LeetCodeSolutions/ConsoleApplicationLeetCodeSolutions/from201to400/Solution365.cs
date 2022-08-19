namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 365. 水壶问题 | 难度：中等 | 标签：深度优先搜索、广度优先搜索、数学
    /// 有两个水壶，容量分别为 jug1Capacity 和 jug2Capacity 升。水的供应是无限的。确定是否有可能使用这两个壶准确得到 targetCapacity 升。
    /// 
    /// 如果可以得到 targetCapacity 升水，最后请用以上水壶中的一或两个来盛放取得的 targetCapacity 升水。
    /// 
    /// 你可以：
    /// 
    /// 装满任意一个水壶
    /// 清空任意一个水壶
    /// 从一个水壶向另外一个水壶倒水，直到装满或者倒空
    /// 
    /// 示例 1: 
    /// 输入: jug1Capacity = 3, jug2Capacity = 5, targetCapacity = 4
    /// 输出: true
    /// 解释：来自著名的 "Die Hard"
    /// 
    /// 示例 2:
    /// 输入: jug1Capacity = 2, jug2Capacity = 6, targetCapacity = 5
    /// 输出: false
    /// 
    /// 示例 3:
    /// 输入: jug1Capacity = 1, jug2Capacity = 2, targetCapacity = 3
    /// 输出: true
    /// 
    /// 提示:
    /// 1 <= jug1Capacity, jug2Capacity, targetCapacity <= 106
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/water-and-jug-problem
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution365
    {
        /// <summary>
        /// 执行用时：28 ms, 在所有 C# 提交中击败了 95.65% 的用户 
        /// 内存消耗：27.8 MB, 在所有 C# 提交中击败了 47.83% 的用户
        /// 通过测试用例：28 / 28
        /// </summary>
        /// <param name="jug1Capacity"></param>
        /// <param name="jug2Capacity"></param>
        /// <param name="targetCapacity"></param>
        /// <returns></returns>
        public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
        {
            if (jug1Capacity + jug2Capacity < targetCapacity) return false;
            if (jug1Capacity == targetCapacity || jug2Capacity == targetCapacity) return true;
            if (jug1Capacity == 0 || jug2Capacity == 0) return false;
            return targetCapacity % Gcd(jug1Capacity, jug2Capacity) == 0;
        }

        private int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
    }
}