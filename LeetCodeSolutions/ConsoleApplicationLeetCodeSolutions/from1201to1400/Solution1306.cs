using System;

namespace ConsoleApplicationLeetCodeSolutions.from1201to1400
{
    /// <summary>
    /// 1306. 跳跃游戏 III | 难度：中等 | 标签：深度优先搜索、广度优先搜索、数组
    /// 这里有一个非负整数数组 arr，你最开始位于该数组的起始下标 start 处。当你位于下标 i 处时，你可以跳到 i + arr[i] 或者 i - arr[i]。
    /// 
    /// 请你判断自己是否能够跳到对应元素值为 0 的 任一 下标处。
    /// 
    /// 注意，不管是什么情况下，你都无法跳到数组之外。
    /// 
    /// 示例 1：
    /// 输入：arr = [4,2,3,0,3,1,2], start = 5
    /// 输出：true
    /// 解释：
    /// 到达值为 0 的下标 3 有以下可能方案： 
    /// 下标 5 -> 下标 4 -> 下标 1 -> 下标 3 
    /// 下标 5 -> 下标 6 -> 下标 4 -> 下标 1 -> 下标 3 
    /// 
    /// 示例 2：
    /// 输入：arr = [4,2,3,0,3,1,2], start = 0
    /// 输出：true 
    /// 解释：
    /// 到达值为 0 的下标 3 有以下可能方案： 
    /// 下标 0 -> 下标 4 -> 下标 1 -> 下标 3
    /// 
    /// 示例 3：
    /// 输入：arr = [3,0,2,1,2], start = 2
    /// 输出：false
    /// 解释：无法到达值为 0 的下标 1 处。 
    /// 
    /// 提示：
    /// 1 <= arr.length <= 5 * 10^4
    /// 0 <= arr[i] < arr.length
    /// 0 <= start < arr.length
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/jump-game-iii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution1306
    {
        public void Test()
        {
            Console.WriteLine(CanReach(new[] {4, 2, 3, 0, 3, 1, 2}, 5));
        }

        /// <summary>
        /// 执行用时：124 ms, 在所有 C# 提交中击败了 76.92% 的用户
        /// 内存消耗：50.3 MB, 在所有 C# 提交中击败了 30.77% 的用户
        /// 通过测试用例：56 / 56
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public bool CanReach(int[] arr, int start)
        {
            var visit = new bool[arr.Length];
            return Dfs(arr, visit, start);
        }

        private bool Dfs(int[] arr, bool[] visit, int start)
        {
            if (visit[start]) return false;
            visit[start] = true;
            if (arr[start] == 0) return true;
            if (start + arr[start] < arr.Length && Dfs(arr, visit, start + arr[start])) return true;
            if (start - arr[start] >= 0 && Dfs(arr, visit, start - arr[start])) return true;
            return false;
        }
    }
}