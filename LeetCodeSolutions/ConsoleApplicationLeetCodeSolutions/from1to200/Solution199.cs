using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 199. 二叉树的右视图 | 标签：树、深度优先搜索、广度优先搜索、二叉树
    /// 给定一个二叉树的 根节点 root，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。
    /// 
    /// 示例 1:
    /// 输入: [1,2,3,null,5,null,4]
    /// 输出: [1,3,4]
    /// 
    /// 示例 2:
    /// 输入: [1,null,3]
    /// 输出: [1,3]
    /// 
    /// 示例 3:
    /// 输入: []
    /// 输出: []
    /// 
    /// 提示:
    /// 二叉树的节点个数的范围是 [0,100]
    /// -100 <= Node.val <= 100 
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/binary-tree-right-side-view
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution199
    {
        /// <summary>
        /// 执行用时：124 ms, 在所有 C# 提交中击败了 97.52% 的用户
        /// 内存消耗：42.1 MB, 在所有 C# 提交中击败了 10.75% 的用户
        /// 通过测试用例：216 / 216
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var c = queue.Count;
                TreeNode last = null;
                while (c > 0)
                {
                    last = queue.Dequeue();
                    if (last.left != null) queue.Enqueue(last.left);
                    if (last.right != null) queue.Enqueue(last.right);
                    c--;
                }

                result.Add(last.val);
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