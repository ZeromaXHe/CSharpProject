namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 24. 两两交换链表中的节点 | 难度：中等 | 标签：递归、链表
    /// 给你一个链表，两两交换其中相邻的节点，并返回交换后链表的头节点。你必须在不修改节点内部的值的情况下完成本题（即，只能进行节点交换）。
    /// 
    /// 示例 1：
    /// 输入：head = [1,2,3,4]
    /// 输出：[2,1,4,3]
    /// 
    /// 示例 2：
    /// 输入：head = []
    /// 输出：[]
    /// 
    /// 示例 3：
    /// 输入：head = [1]
    /// 输出：[1]
    /// 
    /// 提示：
    /// 链表中节点的数目在范围 [0, 100] 内
    /// 0 <= Node.val <= 100
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/swap-nodes-in-pairs
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution24
    {
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
        /// <summary>
        /// 执行用时：80 ms, 在所有 C# 提交中击败了 65.19% 的用户
        /// 内存消耗：37.3 MB, 在所有 C# 提交中击败了 44.62% 的用户
        /// 通过测试用例：55 / 55
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null) return null;
            var dummy = new ListNode(-1, head);
            var end = dummy;
            var ptr = head;
            while (ptr.next != null)
            {
                var tmp = ptr.next.next;
                end.next = ptr.next;
                ptr.next.next = ptr;
                ptr.next = null;
                end = ptr;
                ptr = tmp;
                if (ptr == null) break;
            }

            end.next = ptr;
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