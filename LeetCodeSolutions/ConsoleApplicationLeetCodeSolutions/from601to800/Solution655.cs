using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from601to800
{
    /// <summary>
    /// 655. 输出二叉树 | 难度：中等 | 标签：树、深度优先搜索、广度优先搜索、二叉树
    /// 给你一棵二叉树的根节点 root ，请你构造一个下标从 0 开始、大小为 m x n 的字符串矩阵 res ，用以表示树的 格式化布局 。构造此格式化布局矩阵需要遵循以下规则：
    /// 
    /// 树的 高度 为 height ，矩阵的行数 m 应该等于 height + 1 。
    /// 矩阵的列数 n 应该等于 2height+1 - 1 。
    /// 根节点 需要放置在 顶行 的 正中间 ，对应位置为 res[0][(n-1)/2] 。
    /// 对于放置在矩阵中的每个节点，设对应位置为 res[r][c] ，将其左子节点放置在 res[r+1][c-2height-r-1] ，右子节点放置在 res[r+1][c+2height-r-1] 。
    /// 继续这一过程，直到树中的所有节点都妥善放置。
    /// 任意空单元格都应该包含空字符串 "" 。
    /// 返回构造得到的矩阵 res 。
    /// 
    /// 示例 1：
    /// 输入：root = [1,2]
    /// 输出：
    /// [["","1",""],
    /// ["2","",""]]
    /// 
    /// 示例 2：
    /// 输入：root = [1,2,3,null,4]
    /// 输出：
    /// [["","","","1","","",""],
    /// ["","2","","","","3",""],
    /// ["","","4","","","",""]]
    /// 
    /// 提示：
    /// 树中节点数在范围 [1, 210] 内
    /// -99 <= Node.val <= 99
    /// 树的深度在范围 [1, 10] 内
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/print-binary-tree
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution655
    {
        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         *         this.val = val;
         *         this.left = left;
         *         this.right = right;
         *     }
         * }
         */
        /// <summary>
        /// 执行用时：156 ms, 在所有 C# 提交中击败了 44.44% 的用户
        /// 内存消耗：46.8 MB, 在所有 C# 提交中击败了 27.78% 的用户
        /// 通过测试用例：73 / 73
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<string>> PrintTree(TreeNode root)
        {
            // 题目里的 height 会比我们代码里的小一
            var height = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var c = queue.Count;
                while (c > 0)
                {
                    var deq = queue.Dequeue();
                    if (deq.left != null) queue.Enqueue(deq.left);
                    if (deq.right != null) queue.Enqueue(deq.right);
                    c--;
                }

                height++;
            }

            var res = new List<IList<string>>();
            var m = height;
            var n = (1 << height) - 1;
            for (int i = 0; i < m; i++)
            {
                var row = new List<string>();
                for (int j = 0; j < n; j++)
                {
                    row.Add("");
                }

                res.Add(row);
            }

            Queue<Tuple<TreeNode, int, int>> queue2 = new Queue<Tuple<TreeNode, int, int>>();
            queue2.Enqueue(new Tuple<TreeNode, int, int>(root, 0, (n - 1) / 2));
            while (queue2.Count > 0)
            {
                Tuple<TreeNode, int, int> t = queue2.Dequeue();
                TreeNode node = t.Item1;
                int r = t.Item2, c = t.Item3;
                res[r][c] = node.val.ToString();
                if (node.left != null)
                {
                    queue2.Enqueue(new Tuple<TreeNode, int, int>(node.left, r + 1, c - (1 << (height - r - 2))));
                }

                if (node.right != null)
                {
                    queue2.Enqueue(new Tuple<TreeNode, int, int>(node.right, r + 1, c + (1 << (height - r - 2))));
                }
            }

            return res;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}