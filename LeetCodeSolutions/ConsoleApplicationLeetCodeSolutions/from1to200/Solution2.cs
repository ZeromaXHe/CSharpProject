namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 2. 两数相加 | 难度：中等 | 标签：递归、链表、数学
    /// 给你两个 非空 的链表，表示两个非负的整数。它们每位数字都是按照 逆序 的方式存储的，并且每个节点只能存储 一位 数字。
    /// 
    /// 请你将两个数相加，并以相同形式返回一个表示和的链表。
    /// 
    /// 你可以假设除了数字 0 之外，这两个数都不会以 0 开头。
    /// 
    /// 示例 1：
    /// 输入：l1 = [2,4,3], l2 = [5,6,4]
    /// 输出：[7,0,8]
    /// 解释：342 + 465 = 807.
    /// 
    /// 示例 2：
    /// 输入：l1 = [0], l2 = [0]
    /// 输出：[0]
    /// 
    /// 示例 3：
    /// 输入：l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
    /// 输出：[8,9,9,9,0,0,0,1]
    /// 
    /// 提示：
    /// 每个链表中的节点数在范围 [1, 100] 内
    /// 0 <= Node.val <= 9
    /// 题目数据保证列表表示的数字不含前导零
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/add-two-numbers
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution2
    {
        /**
         * Definition for singly-linked list.
         * | public class ListNode {
         * |     public int val;
         * |     public ListNode next;
         * |     public ListNode(int val=0, ListNode next=null) {
         * |         this.val = val;
         * |         this.next = next;
         * |     }
         * | }
         */
        /// <summary>
        /// 执行用时：88 ms, 在所有 C# 提交中击败了 70.24% 的用户
        /// 内存消耗：48.1 MB, 在所有 C# 提交中击败了 62.38% 的用户
        /// 通过测试用例：1568 / 1568
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode();
            ListNode p1 = l1;
            ListNode p2 = l2;
            ListNode p = dummy;
            int carry = 0;
            while (p1 != null && p2 != null)
            {
                int sum = p1.val + p2.val + carry;
                p.next = new ListNode(sum % 10);
                carry = sum / 10;
                p = p.next;
                p1 = p1.next;
                p2 = p2.next;
            }

            while (p1 != null)
            {
                if (carry == 0)
                {
                    p.next = p1;
                    return dummy.next;
                }

                int sum = p1.val + carry;
                p.next = new ListNode(sum % 10);
                carry = sum / 10;
                p = p.next;
                p1 = p1.next;
            }

            while (p2 != null)
            {
                if (carry == 0)
                {
                    p.next = p2;
                    return dummy.next;
                }

                int sum = p2.val + carry;
                p.next = new ListNode(sum % 10);
                carry = sum / 10;
                p = p.next;
                p2 = p2.next;
            }

            if (carry != 0)
            {
                p.next = new ListNode(carry);
            }

            return dummy.next;
        }

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