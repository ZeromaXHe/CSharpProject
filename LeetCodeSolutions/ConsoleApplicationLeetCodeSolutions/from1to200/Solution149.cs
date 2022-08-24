namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 149. 直线上最多的点数 | 难度：困难 | 标签：几何、数组、哈希表、数学
    /// 给你一个数组 points ，其中 points[i] = [xi, yi] 表示 X-Y 平面上的一个点。求最多有多少个点在同一条直线上。
    /// 
    /// 示例 1：
    /// 输入：points = [[1,1],[2,2],[3,3]]
    /// 输出：3
    /// 
    /// 示例 2：
    /// 输入：points = [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
    /// 输出：4
    /// 
    /// 提示：
    /// 1 <= points.length <= 300
    /// points[i].length == 2
    /// -104 <= xi, yi <= 104
    /// points 中的所有点 互不相同
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/max-points-on-a-line
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution149
    {
        /// <summary>
        /// 执行用时：124 ms, 在所有 C# 提交中击败了 17.39% 的用户
        /// 内存消耗：37.4 MB, 在所有 C# 提交中击败了 73.91% 的用户
        /// 通过测试用例：35 / 35
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MaxPoints(int[][] points)
        {
            var max = 1;
            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    var c = 2;
                    for (int k = 0; k < points.Length; k++)
                    {
                        if (k != i && k != j &&
                            ((long) points[k][0] - points[j][0]) * (points[k][1] - points[i][1]) ==
                            ((long) points[k][0] - points[i][0]) * (points[k][1] - points[j][1])) c++;
                    }

                    if (c > max) max = c;
                }
            }

            return max;
        }
    }
}