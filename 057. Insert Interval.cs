/*
57. Insert Interval
 
Total Accepted: 92819
Total Submissions: 341222
Difficulty: Hard
Contributor: LeetCode
Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

You may assume that the intervals were initially sorted according to their start times.

Example 1:
Given intervals [1,3],[6,9], insert and merge [2,5] in as [1,5],[6,9].

Example 2:
Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16].

This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].

Hide Company Tags LinkedIn Google Facebook
Hide Tags Array Sort
Hide Similar Problems (M) Merge Intervals
*/

//Author:new2500
/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
 
 
	public List<Interval> Insert(List<Interval> intervals, Interval newIntervals)
	{
		List<Interval> res = new List<Interval>();
		
		intervals = intervals.OrderBy(x=>x.start).ToList();
		
		bool isAdd = false;
		
		for(int i = 0; i < intervals.Count; i++)
		{
			if(isAdd)
			{
				res.Add(intervals[i]);
			}
			//Not add
			else if (intervals[i].start > newIntervals.end)//Not Overlap
			{          //[9,10]               [1,3]
				res.Add(newIntervals);
				res.Add(intervals[i]);
				isAdd = true;
			}
			else if(intervals[i].end < newIntervals.start) //Not overlap
			{         //[1,3]            [4,10]
				res.Add(intervals[i]);
			}
			else   //old.start < new.end but old.end > new.start, like [9,11] & [2,15]
			{
				newIntervals.start = Math.Min(intervals[i].start, newIntervals.start);
				newIntervals.end = Math.Max(intervals[i].end, newIntervals.end);
			}
		}
		
		if(!isAdd)
		{
			res.Add(newIntervals);
		}
		return res;
	}


