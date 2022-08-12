namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 206. 反转链表 | 难度：简单 | 标签：递归、链表
    /// 给你单链表的头节点 head ，请你反转链表，并返回反转后的链表。
    /// 
    /// 示例 1：
    /// 输入：head = [1,2,3,4,5]
    /// 输出：[5,4,3,2,1]
    /// 
    /// 示例 2：
    /// 输入：head = [1,2]
    /// 输出：[2,1]
    /// 
    /// 示例 3：
    /// 输入：head = []
    /// 输出：[]
    /// 
    /// 提示：
    /// 链表中节点的数目范围是 [0, 5000]
    /// -5000 <= Node.val <= 5000
    /// 
    /// 进阶：链表可以选用迭代或递归方式完成反转。你能否用两种方法解决这道题？
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/reverse-linked-list
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution206
    {
        /// <summary>
        /// 执行用时：72 ms, 在所有 C# 提交中击败了 97.14% 的用户
        /// 内存消耗：38 MB, 在所有 C# 提交中击败了 64.30% 的用户
        /// 通过测试用例：28 / 28
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            ListNode dummy = new ListNode();
            ListNode ptr = head;
            while (ptr != null)
            {
                ListNode next = ptr.next;
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
         *     public ListNode(int val=0, ListNode next=null) {
         *         this.val = val;
         *         this.next = next;
         *     }
         * }
         */
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}