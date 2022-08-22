using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 341. 扁平化嵌套列表迭代器 | 难度：中等 | 标签：栈、树、深度优先搜索、设计、队列、迭代器
    /// 给你一个嵌套的整数列表 nestedList 。每个元素要么是一个整数，要么是一个列表；该列表的元素也可能是整数或者是其他列表。请你实现一个迭代器将其扁平化，使之能够遍历这个列表中的所有整数。
    /// 
    /// 实现扁平迭代器类 NestedIterator ：
    /// 
    /// NestedIterator(List<NestedInteger> nestedList) 用嵌套列表 nestedList 初始化迭代器。
    /// int next() 返回嵌套列表的下一个整数。
    /// boolean hasNext() 如果仍然存在待迭代的整数，返回 true ；否则，返回 false 。
    /// 你的代码将会用下述伪代码检测：
    /// 
    /// initialize iterator with nestedList
    /// res = []
    /// while iterator.hasNext()
    /// append iterator.next() to the end of res
    /// return res
    /// 如果 res 与预期的扁平化列表匹配，那么你的代码将会被判为正确。
    /// 
    /// 示例 1：
    /// 输入：nestedList = [[1,1],2,[1,1]]
    /// 输出：[1,1,2,1,1]
    /// 解释：通过重复调用 next 直到 hasNext 返回 false，next 返回的元素的顺序应该是: [1,1,2,1,1]。
    /// 
    /// 示例 2：
    /// 输入：nestedList = [1,[4,[6]]]
    /// 输出：[1,4,6]
    /// 解释：通过重复调用 next 直到 hasNext 返回 false，next 返回的元素的顺序应该是: [1,4,6]。
    /// 
    /// 提示：
    /// 1 <= nestedList.length <= 500
    /// 嵌套列表中的整数值在范围 [-106, 106] 内
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/flatten-nested-list-iterator
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution341
    {
        /// <summary>
        /// 执行用时：124 ms, 在所有 C# 提交中击败了 56.00% 的用户
        /// 内存消耗：43.1 MB, 在所有 C# 提交中击败了 56.00% 的用户
        /// 通过测试用例：43 / 43
        /// </summary>
        public class NestedIterator
        {
            private Stack<IEnumerator<NestedInteger>> stack = new Stack<IEnumerator<NestedInteger>>();

            public NestedIterator(IList<NestedInteger> nestedList)
            {
                stack.Push(nestedList.GetEnumerator());
            }

            private void InitStackNextValue(IList<NestedInteger> nestedList)
            {
                if (nestedList == null) return;
                stack.Push(nestedList.GetEnumerator());
                InitStackNextValue(NextList());
            }

            private IList<NestedInteger> NextList()
            {
                while (stack.Count > 0 && !stack.Peek().MoveNext()) stack.Pop();
                if (stack.Count == 0) return null;
                var nestedInteger = stack.Peek().Current;
                if (nestedInteger != null && nestedInteger.IsInteger()) return null;
                return nestedInteger?.GetList();
            }

            public bool HasNext()
            {
                if (stack.Count == 0) return false;
                InitStackNextValue(NextList());
                return stack.Count > 0;
            }

            public int Next()
            {
                return stack.Peek().Current.GetInteger();
            }
        }

        /**
         * Your NestedIterator will be called like this:
         * NestedIterator i = new NestedIterator(nestedList);
         * while (i.HasNext()) v[f()] = i.Next();
         */
        public interface NestedInteger
        {
            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            bool IsInteger();

            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            int GetInteger();

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            IList<NestedInteger> GetList();
        }
    }
}