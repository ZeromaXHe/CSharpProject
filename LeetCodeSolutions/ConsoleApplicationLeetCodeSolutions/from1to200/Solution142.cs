namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 142. 环形链表 II | 难度：中等 | 标签：哈希表、链表、双指针
    /// 给定一个链表的头节点  head ，返回链表开始入环的第一个节点。 如果链表无环，则返回 null。
    /// 
    /// 如果链表中有某个节点，可以通过连续跟踪 next 指针再次到达，则链表中存在环。 为了表示给定链表中的环，评测系统内部使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。如果 pos 是 -1，则在该链表中没有环。注意：pos 不作为参数进行传递，仅仅是为了标识链表的实际情况。
    /// 
    /// 不允许修改 链表。
    /// 
    /// 示例 1：
    /// 输入：head = [3,2,0,-4], pos = 1
    /// 输出：返回索引为 1 的链表节点
    /// 解释：链表中有一个环，其尾部连接到第二个节点。
    /// 
    /// 示例 2：
    /// 输入：head = [1,2], pos = 0
    /// 输出：返回索引为 0 的链表节点
    /// 解释：链表中有一个环，其尾部连接到第一个节点。
    /// 
    /// 示例 3：
    /// 输入：head = [1], pos = -1
    /// 输出：返回 null
    /// 解释：链表中没有环。
    /// 
    /// 提示：
    /// 链表中节点的数目范围在范围 [0, 104] 内
    /// -105 <= Node.val <= 105
    /// pos 的值为 -1 或者链表中的一个有效索引
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/linked-list-cycle-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution142
    {
        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) {
         *         val = x;
         *         next = null;
         *     }
         * }
         */
        /// <summary>
        /// 执行用时：80 ms, 在所有 C# 提交中击败了 87.46% 的用户
        /// 内存消耗：39.6 MB, 在所有 C# 提交中击败了 51.19% 的用户
        /// 通过测试用例：16 / 16
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            var p1 = head?.next;
            var p2 = head.next?.next;
            while (p1 != null && p2 != null && p1 != p2)
            {
                p1 = p1.next;
                p2 = p2.next?.next;
            }

            if (p2 == null) return null;
            p2 = head;
            while (p2 != p1)
            {
                p1 = p1.next;
                p2 = p2.next;
            }

            return p2;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }
    }
}