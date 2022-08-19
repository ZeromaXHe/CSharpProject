namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 82. 删除排序链表中的重复元素 II | 难度：中等 | 标签：
    /// 给定一个已排序的链表的头 head ， 删除原始链表中所有重复数字的节点，只留下不同的数字 。返回 已排序的链表 。
    /// 
    /// 示例 1：
    /// 输入：head = [1,2,3,3,4,4,5]
    /// 输出：[1,2,5]
    /// 
    /// 示例 2：
    /// 输入：head = [1,1,1,2,3]
    /// 输出：[2,3]
    /// 
    /// 提示：
    /// 链表中节点数目在范围 [0, 300] 内
    /// -100 <= Node.val <= 100
    /// 题目数据保证链表已经按升序 排列
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/remove-duplicates-from-sorted-list-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution82
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
        /// 执行用时：92 ms, 在所有 C# 提交中击败了 14.69% 的用户
        /// 内存消耗：39 MB, 在所有 C# 提交中击败了 20.98% 的用户
        /// 通过测试用例：166 / 166
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            var dummy = new ListNode();
            var ptr = head;
            var pre = dummy;
            while (ptr != null)
            {
                if (ptr.next != null && ptr.val == ptr.next.val)
                {
                    while (ptr.next != null && ptr.next.val == ptr.val) ptr = ptr.next;
                    ptr = ptr.next;
                }
                else
                {
                    pre.next = ptr;
                    pre = ptr;
                    ptr = ptr.next;
                    pre.next = null;
                }
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