using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from601to800
{
    /// <summary>
    /// 752. 打开转盘锁 | 难度：中等 | 标签：广度优先搜索、数组、哈希表、字符串
    /// 你有一个带有四个圆形拨轮的转盘锁。每个拨轮都有10个数字： '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' 。每个拨轮可以自由旋转：例如把 '9' 变为 '0'，'0' 变为 '9' 。每次旋转都只能旋转一个拨轮的一位数字。
    /// 
    /// 锁的初始数字为 '0000' ，一个代表四个拨轮的数字的字符串。
    /// 
    /// 列表 deadends 包含了一组死亡数字，一旦拨轮的数字和列表里的任何一个元素相同，这个锁将会被永久锁定，无法再被旋转。
    /// 
    /// 字符串 target 代表可以解锁的数字，你需要给出解锁需要的最小旋转次数，如果无论如何不能解锁，返回 -1 。
    /// 
    /// 示例 1:
    /// 输入：deadends = ["0201","0101","0102","1212","2002"], target = "0202"
    /// 输出：6
    /// 解释：
    /// 可能的移动序列为 "0000" -> "1000" -> "1100" -> "1200" -> "1201" -> "1202" -> "0202"。
    /// 注意 "0000" -> "0001" -> "0002" -> "0102" -> "0202" 这样的序列是不能解锁的，
    /// 因为当拨动到 "0102" 时这个锁就会被锁定。
    /// 
    /// 示例 2:
    /// 输入: deadends = ["8888"], target = "0009"
    /// 输出：1
    /// 解释：把最后一位反向旋转一次即可 "0000" -> "0009"。
    /// 
    /// 示例 3:
    /// 输入: deadends = ["8887","8889","8878","8898","8788","8988","7888","9888"], target = "8888"
    /// 输出：-1
    /// 解释：无法旋转到目标数字且不被锁定。
    /// 
    /// 提示：
    /// 1 <= deadends.length <= 500
    /// deadends[i].length == 4
    /// target.length == 4
    /// target 不在 deadends 之中
    /// target 和 deadends[i] 仅由若干位数字组成
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/open-the-lock
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution752
    {
        /// <summary>
        /// 执行用时：104 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗：40 MB, 在所有 C# 提交中击败了 100.00% 的用户
        /// 通过测试用例：48 / 48
        ///
        /// 题解里面换成 A* 算法启发式搜索的思路还是有点牛
        /// </summary>
        /// <param name="deadends"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int OpenLock(string[] deadends, string target)
        {
            var dead = new bool[10000];
            foreach (var deadend in deadends)
            {
                dead[int.Parse(deadend)] = true;
            }

            var targetI = int.Parse(target);
            var queue = new Queue<int>();
            var visit = new bool[10000];
            queue.Enqueue(0);
            visit[0] = true;
            var dist = 0;
            while (queue.Count > 0)
            {
                var c = queue.Count;
                while (c > 0)
                {
                    var deq = queue.Dequeue();
                    if (deq == targetI) return dist;
                    if (!dead[deq])
                    {
                        var d = deq % 10;
                        EnqueueNext(visit, deq - d + (d + 1) % 10, queue);
                        EnqueueNext(visit, deq - d + (d + 9) % 10, queue);
                        d = deq % 100 / 10 * 10;
                        EnqueueNext(visit, deq - d + (d + 10) % 100, queue);
                        EnqueueNext(visit, deq - d + (d + 90) % 100, queue);
                        d = deq % 1000 / 100 * 100;
                        EnqueueNext(visit, deq - d + (d + 100) % 1000, queue);
                        EnqueueNext(visit, deq - d + (d + 900) % 1000, queue);
                        d = deq % 10000 / 1000 * 1000;
                        EnqueueNext(visit, deq - d + (d + 1000) % 10000, queue);
                        EnqueueNext(visit, deq - d + (d + 9000) % 10000, queue);
                    }

                    c--;
                }

                dist++;
            }

            return -1;
        }

        private static void EnqueueNext(bool[] visit, int next, Queue<int> queue)
        {
            if (!visit[next])
            {
                queue.Enqueue(next);
                visit[next] = true;
            }
        }
    }
}