namespace ConsoleApplicationLeetCodeSolutions.offer
{
    /// <summary>
    /// 剑指 Offer 24. 反转链表 | 难度：简单 | 标签：递归，链表
    /// 定义一个函数，输入一个链表的头节点，反转该链表并输出反转后链表的头节点。
    /// 
    /// 示例:
    /// 输入: 1->2->3->4->5->NULL
    /// 输出: 5->4->3->2->1->NULL
    /// 
    /// 限制：
    /// 0 <= 节点个数 <= 5000
    /// 
    /// 注意：本题与主站 206 题相同：https://leetcode-cn.com/problems/reverse-linked-list/
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/fan-zhuan-lian-biao-lcof
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class SolutionOffer24
    {
        /// <summary>
        /// 执行用时：80 ms, 在所有 C# 提交中击败了 66.89% 的用户
        /// 内存消耗：37.9 MB, 在所有 C# 提交中击败了 82.12% 的用户
        /// 通过测试用例：27 / 27
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            ListNode dummy = new ListNode(-1);
            ListNode ptr = head;
            ListNode next;
            while (ptr != null)
            {
                next = ptr.next;
                ptr.next = dummy.next;
                dummy.next = ptr;
                ptr = next;
            }

            return dummy.next;
        }

        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
            }
        }
    }
}