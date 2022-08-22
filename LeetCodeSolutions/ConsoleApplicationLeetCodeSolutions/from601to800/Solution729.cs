using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from601to800
{
    /// <summary>
    /// 729. 我的日程安排表 I | 难度：中等 | 标签：设计、线段树、二分查找、有序集合
    /// 实现一个 MyCalendar 类来存放你的日程安排。如果要添加的日程安排不会造成 重复预订 ，则可以存储这个新的日程安排。
    /// 
    /// 当两个日程安排有一些时间上的交叉时（例如两个日程安排都在同一时间内），就会产生 重复预订 。
    /// 
    /// 日程可以用一对整数 start 和 end 表示，这里的时间是半开区间，即 [start, end), 实数 x 的范围为，  start <= x < end 。
    /// 
    /// 实现 MyCalendar 类：
    /// 
    /// MyCalendar() 初始化日历对象。
    /// boolean book(int start, int end) 如果可以将日程安排成功添加到日历中而不会导致重复预订，返回 true 。否则，返回 false 并且不要将该日程安排添加到日历中。
    /// 
    /// 示例：
    /// 输入：
    /// ["MyCalendar", "book", "book", "book"]
    /// [[], [10, 20], [15, 25], [20, 30]]
    /// 输出：
    /// [null, true, false, true]
    /// 
    /// 解释：
    /// MyCalendar myCalendar = new MyCalendar();
    /// myCalendar.book(10, 20); // return True
    /// myCalendar.book(15, 25); // return False ，这个日程安排不能添加到日历中，因为时间 15 已经被另一个日程安排预订了。
    /// myCalendar.book(20, 30); // return True ，这个日程安排可以添加到日历中，因为第一个日程安排预订的每个时间都小于 20 ，且不包含时间 20 。
    /// 
    /// 提示：
    /// 0 <= start < end <= 109
    /// 每个测试用例，调用 book 方法的次数最多不超过 1000 次。
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/my-calendar-i
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution729
    {
        /// <summary>
        /// 执行用时：184 ms, 在所有 C# 提交中击败了 97.07% 的用户
        /// 内存消耗：64 MB, 在所有 C# 提交中击败了 55.31% 的用户
        /// 通过测试用例：107 / 107
        ///
        /// 实在不想写了，C# 的集合库是真的垃圾，找不到类似 TreeMap 的。
        /// 参考这篇题解写的：https://leetcode.cn/problems/my-calendar-i/solution/by-khwang-chai-kh-azxg/
        /// </summary>
        public class MyCalendar
        {
            private List<int[]> _list;

            public MyCalendar()
            {
                _list = new List<int[]>();
            }

            public bool Book(int start, int end)
            {
                int n = _list.Count;
                if (n == 0)
                {
                    // list中无数据时，直接插入
                    _list.Add(new[] {start, end});
                    return true;
                }

                int l = 0, r = n - 1;
                while (l < r)
                {
                    // 二分查找第一个大于 start 的左端点
                    int mid = (l + r) / 2;
                    if (_list[mid][0] == start) return false;
                    if (_list[mid][0] < start) l = mid + 1;
                    else r = mid;
                }

                if (start >= _list[l][1])
                {
                    // 若start大于所有左端点，直接在最后插入
                    _list.Add(new[] {start, end});
                    return true;
                }

                if ((l - 1 >= 0 && _list[l - 1][1] > start) || _list[l][0] < end)
                    // 若上一组区间的右端点大于start或者下一组区间左端点小于end，发生重复预定，返回false
                    return false;

                // 满足日程安排条件，插入区间
                _list.Insert(l, new[] {start, end});
                return true;
            }
        }

        /**
         * Your MyCalendar object will be instantiated and called as such:
         * MyCalendar obj = new MyCalendar();
         * bool param_1 = obj.Book(start,end);
         */
    }
}