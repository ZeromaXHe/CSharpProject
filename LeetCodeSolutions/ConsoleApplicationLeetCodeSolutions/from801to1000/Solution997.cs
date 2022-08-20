namespace ConsoleApplicationLeetCodeSolutions.from801to1000
{
    /// <summary>
    /// 997. 找到小镇的法官 | 难度：简单 | 标签：图、数组、哈希表
    /// 小镇里有 n 个人，按从 1 到 n 的顺序编号。传言称，这些人中有一个暗地里是小镇法官。
    /// 
    /// 如果小镇法官真的存在，那么：
    /// 
    /// 小镇法官不会信任任何人。
    /// 每个人（除了小镇法官）都信任这位小镇法官。
    /// 只有一个人同时满足属性 1 和属性 2 。
    /// 给你一个数组 trust ，其中 trust[i] = [ai, bi] 表示编号为 ai 的人信任编号为 bi 的人。
    /// 
    /// 如果小镇法官存在并且可以确定他的身份，请返回该法官的编号；否则，返回 -1 。
    /// 
    /// 示例 1：
    /// 输入：n = 2, trust = [[1,2]]
    /// 输出：2
    /// 
    /// 示例 2：
    /// 输入：n = 3, trust = [[1,3],[2,3]]
    /// 输出：3
    /// 
    /// 示例 3：
    /// 输入：n = 3, trust = [[1,3],[2,3],[3,1]]
    /// 输出：-1
    /// 
    /// 提示：
    /// 1 <= n <= 1000
    /// 0 <= trust.length <= 104
    /// trust[i].length == 2
    /// trust 中的所有trust[i] = [ai, bi] 互不相同
    /// ai != bi
    /// 1 <= ai, bi <= n
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/find-the-town-judge
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution997
    {
        /// <summary>
        /// 执行用时：244 ms, 在所有 C# 提交中击败了 25.49% 的用户
        /// 内存消耗：64.5 MB, 在所有 C# 提交中击败了 52.94% 的用户
        /// 通过测试用例：92 / 92
        /// </summary>
        /// <param name="n"></param>
        /// <param name="trust"></param>
        /// <returns></returns>
        public int FindJudge(int n, int[][] trust)
        {
            var count = new int[n, 2];
            foreach (var t in trust)
            {
                count[t[0] - 1, 0]++;
                count[t[1] - 1, 1]++;
            }

            for (int i = 0; i < n; i++)
            {
                if (count[i, 0] == 0 && count[i, 1] == n - 1) return i + 1;
            }

            return -1;
        }
    }
}