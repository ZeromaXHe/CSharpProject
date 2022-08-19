namespace ConsoleApplicationLeetCodeSolutions.from601to800
{
    /// <summary>
    /// 707. 设计链表 | 难度：中等 | 标签：设计、链表
    /// 设计链表的实现。您可以选择使用单链表或双链表。单链表中的节点应该具有两个属性：val 和 next。val 是当前节点的值，next 是指向下一个节点的指针/引用。如果要使用双向链表，则还需要一个属性 prev 以指示链表中的上一个节点。假设链表中的所有节点都是 0-index 的。
    /// 
    /// 在链表类中实现这些功能：
    /// 
    /// get(index)：获取链表中第 index 个节点的值。如果索引无效，则返回-1。
    /// addAtHead(val)：在链表的第一个元素之前添加一个值为 val 的节点。插入后，新节点将成为链表的第一个节点。
    /// addAtTail(val)：将值为 val 的节点追加到链表的最后一个元素。
    /// addAtIndex(index,val)：在链表中的第 index 个节点之前添加值为 val  的节点。如果 index 等于链表的长度，则该节点将附加到链表的末尾。如果 index 大于链表长度，则不会插入节点。如果index小于0，则在头部插入节点。
    /// deleteAtIndex(index)：如果索引 index 有效，则删除链表中的第 index 个节点。
    /// 
    /// 示例：
    /// MyLinkedList linkedList = new MyLinkedList();
    /// linkedList.addAtHead(1);
    /// linkedList.addAtTail(3);
    /// linkedList.addAtIndex(1,2);   //链表变为1-> 2-> 3
    /// linkedList.get(1);            //返回2
    /// linkedList.deleteAtIndex(1);  //现在链表是1-> 3
    /// linkedList.get(1);            //返回3
    /// 
    /// 提示：
    /// 所有val值都在 [1, 1000] 之内。
    /// 操作次数将在  [1, 1000] 之内。
    /// 请不要使用内置的 LinkedList 库。
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/design-linked-list
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution707
    {
        /// <summary>
        /// 执行用时：124 ms, 在所有 C# 提交中击败了 86.52% 的用户
        /// 内存消耗：60.8 MB, 在所有 C# 提交中击败了 7.80% 的用户
        /// 通过测试用例：64 / 64
        /// </summary>
        public class MyLinkedList
        {
            private Node head = new Node(-1);
            private Node tail = new Node(-1);
            private int count = 0;

            private class Node
            {
                public Node next;
                public Node prev;
                public int val;

                public Node(int val = 0, Node prev = null, Node next = null)
                {
                    this.next = next;
                    this.prev = prev;
                    this.val = val;
                }
            }

            public MyLinkedList()
            {
                head.next = tail;
                tail.prev = head;
            }

            private Node GetNode(int index)
            {
                if (index >= count) return null;
                if (index <= count / 2)
                {
                    var ptr = head.next;
                    while (index > 0)
                    {
                        ptr = ptr.next;
                        index--;
                    }

                    return ptr;
                }
                else
                {
                    index = count - 1 - index;
                    var ptr = tail.prev;
                    while (index > 0)
                    {
                        ptr = ptr.prev;
                        index--;
                    }

                    return ptr;
                }
            }

            public int Get(int index)
            {
                if (index >= count) return -1;
                return GetNode(index).val;
            }

            public void AddAtHead(int val)
            {
                var node = new Node(val, head, head.next);
                head.next.prev = node;
                head.next = node;
                count++;
            }

            public void AddAtTail(int val)
            {
                var node = new Node(val, tail.prev, tail);
                tail.prev.next = node;
                tail.prev = node;
                count++;
            }

            public void AddAtIndex(int index, int val)
            {
                if (index < count)
                {
                    var next = GetNode(index);
                    var node = new Node(val, next.prev, next);
                    next.prev.next = node;
                    next.prev = node;
                    count++;
                }
                else if (index == count) AddAtTail(val);
            }

            public void DeleteAtIndex(int index)
            {
                if (index < count)
                {
                    var del = GetNode(index);
                    del.prev.next = del.next;
                    del.next.prev = del.prev;
                    count--;
                }
            }
        }

        /**
         * Your MyLinkedList object will be instantiated and called as such:
         * MyLinkedList obj = new MyLinkedList();
         * int param_1 = obj.Get(index);
         * obj.AddAtHead(val);
         * obj.AddAtTail(val);
         * obj.AddAtIndex(index,val);
         * obj.DeleteAtIndex(index);
         */
    }
}