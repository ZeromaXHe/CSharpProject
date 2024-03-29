﻿using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 429. N 叉树的层序遍历 | 难度：中等 | 标签：树、广度优先搜索
    /// 给定一个 N 叉树，返回其节点值的层序遍历。（即从左到右，逐层遍历）。
    /// 
    /// 树的序列化输入是用层序遍历，每组子节点都由 null 值分隔（参见示例）。
    /// 
    /// 示例 1：
    /// 输入：root = [1,null,3,2,4,null,5,6]
    /// 输出：[[1],[3,2,4],[5,6]]
    /// 
    /// 示例 2：
    /// 输入：root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
    /// 输出：[[1],[2,3,4,5],[6,7,8,9,10],[11,12,13],[14]]
    /// 
    /// 提示：
    /// 树的高度不会超过 1000
    /// 树的节点总数在 [0, 10^4] 之间
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/n-ary-tree-level-order-traversal
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution429
    {
        /*
        // Definition for a Node.
        public class Node {
            public int val;
            public IList<Node> children;
        
            public Node() {}
        
            public Node(int _val) {
                val = _val;
            }
        
            public Node(int _val, IList<Node> _children) {
                val = _val;
                children = _children;
            }
        }
        */
        /// <summary>
        /// 执行用时：156 ms, 在所有 C# 提交中击败了 96.36% 的用户
        /// 内存消耗：48.8 MB, 在所有 C# 提交中击败了 50.91% 的用户
        /// 通过测试用例：38 / 38
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(Node root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var c = queue.Count;
                var list = new List<int>();
                while (c > 0)
                {
                    var deq = queue.Dequeue();
                    if (deq.children?.Count > 0)
                    {
                        foreach (var child in deq.children)
                        {
                            queue.Enqueue(child);
                        }
                    }

                    list.Add(deq.val);
                    c--;
                }

                result.Add(list);
            }

            return result;
        }

        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node()
            {
            }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
    }
}