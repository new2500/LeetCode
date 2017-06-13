/*
56. Merge Intervals
 
Total Accepted: 124084
Total Submissions: 420905
Difficulty: Medium
Contributor: LeetCode
Given a collection of intervals, merge all overlapping intervals.

For example,
Given [1,3],[2,6],[8,10],[15,18],
return [1,6],[8,10],[15,18].

Hide Company Tags LinkedIn Google Facebook Twitter Microsoft Bloomberg Yelp
Hide Tags Array Sort
Hide Similar Problems (H) Insert Interval (E) Meeting Rooms (M) Meeting Rooms II (M) Teemo Attacking (M) Add Bold Tag in String
*/


//Author: new2500
/** 
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */

 
 
	public List<Interval> Merge(List<Interval> intervals)
	{
		List<Interval> res = new List<Interval>();
		
		foreach(Interval curr in intervals.OrderBy(x=>x.start))
		{
			//Curr.start > last item.end & Empty case
			if(res.Count == 0 || res[res.Count - 1].end < curr.start)
				res.Add(new Interval(curr.start, curr.end));
			//Curr.start < last item.end. Should consider merge
			else
			{
				res[res.Count - 1].end = Math.Max(res[res.Count - 1].end, curr.end);
			}
		}
		return res;
	}