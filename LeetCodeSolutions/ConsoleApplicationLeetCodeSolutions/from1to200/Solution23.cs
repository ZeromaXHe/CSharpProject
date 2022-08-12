using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 23. 合并K个升序链表 | 难度：困难 | 标签：链表、分治、堆（优先队列）、归并排序
    /// 给你一个链表数组，每个链表都已经按升序排列。
    /// 
    /// 请你将所有链表合并到一个升序链表中，返回合并后的链表。
    /// 
    /// 示例 1：
    /// 输入：lists = [[1,4,5],[1,3,4],[2,6]]
    /// 输出：[1,1,2,3,4,4,5,6]
    /// 解释：链表数组如下：
    /// [
    /// 1->4->5,
    /// 1->3->4,
    /// 2->6
    /// ]
    /// 将它们合并到一个有序链表中得到。
    /// 1->1->2->3->4->4->5->6
    /// 
    /// 示例 2：
    /// 输入：lists = []
    /// 输出：[]
    /// 
    /// 示例 3：
    /// 输入：lists = [[]]
    /// 输出：[]
    /// 
    /// 提示：
    /// k == lists.length
    /// 0 <= k <= 10^4
    /// 0 <= lists[i].length <= 500
    /// -10^4 <= lists[i][j] <= 10^4
    /// lists[i] 按 升序 排列
    /// lists[i].length 的总和不超过 10^4
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/merge-k-sorted-lists
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution23
    {
        public void Test()
        {
            Console.WriteLine(new ListNode(1).GetHashCode());
            Console.WriteLine(new ListNode(1).GetHashCode());
            Console.WriteLine(new ListNode().GetHashCode());
            Console.WriteLine(Equals(new ListNode(2), new ListNode(2)));
        }
    
        /// <summary>
        /// 执行用时：116 ms, 在所有 C# 提交中击败了 44.19% 的用户
        /// 内存消耗：47.2 MB, 在所有 C# 提交中击败了 5.32% 的用户
        /// 通过测试用例：133 / 133
        ///
        /// .NET 6.0（C# 10） 之前没有优先队列，只能用 SortedDictionary 代替了（内部实现为红黑树）。
        /// 看所有提交里面有用 PriorityQueue 的，难道力扣的 C# 版本这么高的吗？
        /// （国际站查了一下，还真是 C# 10 with .NET 6 runtime）
        /// 
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;
            // 力扣上总是判断 key 重复，吐了…… 鬼就知道这个相等是怎么判断的。只能使用自己的逻辑了
            // var sorted = new SortedDictionary<ListNode, int>(Comparer<ListNode>.Create((n1, n2) => n1.val - n2.val));
            var sorted = new SortedDictionary<double, int>();
            for (int i = 0; i < lists.Length; i++)
            {
                // if (lists[i] != null) sorted.Add(lists[i], i);
                if (lists[i] != null) sorted.Add(lists[i].val + i / 100000.0, i);
            }

            ListNode dummy = new ListNode();
            ListNode end = dummy;

            while (sorted.Count > 0)
            {
                var smallest = sorted.Keys.First();
                int idx;
                sorted.TryGetValue(smallest, out idx);
                sorted.Remove(smallest);
                end.next = lists[idx];
                end = end.next;
                lists[idx] = lists[idx].next;
                end.next = null;
                if (lists[idx] != null)
                {
                    // sorted.Add(lists[idx], idx);
                    sorted.Add(lists[idx].val + idx / 100000.0, idx);
                }
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