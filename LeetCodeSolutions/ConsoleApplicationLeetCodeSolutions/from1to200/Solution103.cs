using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 103. 二叉树的锯齿形层序遍历 | 难度：中等 | 标签：树、广度优先搜索、二叉树
    /// 给你二叉树的根节点 root ，返回其节点值的 锯齿形层序遍历 。（即先从左往右，再从右往左进行下一层遍历，以此类推，层与层之间交替进行）。
    /// 
    /// 示例 1：
    /// 输入：root = [3,9,20,null,null,15,7]
    /// 输出：[[3],[20,9],[15,7]]
    /// 
    /// 示例 2：
    /// 输入：root = [1]
    /// 输出：[[1]]
    /// 
    /// 示例 3：
    /// 输入：root = []
    /// 输出：[]
    /// 
    /// 提示：
    /// 树中节点数目在范围 [0, 2000] 内
    /// -100 <= Node.val <= 100
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/binary-tree-zigzag-level-order-traversal
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution103
    {
        /// <summary>
        /// 执行用时：168 ms, 在所有 C# 提交中击败了 7.50% 的用户
        /// 内存消耗：41.8 MB, 在所有 C# 提交中击败了 45.00% 的用户
        /// 通过测试用例：33 / 33
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;
            var queue = new Queue<TreeNode>();
            var stack = new Stack<TreeNode>();
            queue.Enqueue(root);
            var reverse = false;
            while (queue.Count > 0)
            {
                var c = queue.Count;
                var list = new List<int>();
                while (c > 0)
                {
                    var deq = queue.Dequeue();
                    c--;
                    stack.Push(deq);
                }

                while (stack.Count > 0)
                {
                    var pop = stack.Pop();
                    list.Add(pop.val);
                    if (reverse)
                    {
                        if (pop.right != null) queue.Enqueue(pop.right);
                        if (pop.left != null) queue.Enqueue(pop.left);
                    }
                    else
                    {
                        if (pop.left != null) queue.Enqueue(pop.left);
                        if (pop.right != null) queue.Enqueue(pop.right);
                    }
                }

                reverse = !reverse;
                result.Add(list);
            }

            return result;
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