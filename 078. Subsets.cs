/*
78. Subsets
 
Total Accepted: 160958
Total Submissions: 408920
Difficulty: Medium
Contributor: LeetCode
Given a set of distinct integers, nums, return all possible subsets.

Note: The solution set must not contain duplicate subsets.

For example,
If nums = [1,2,3], a solution is:

[
  [3],
  [1],
  [2],
  [1,2,3],
  [1,3],
  [2,3],
  [1,2],
  []
]
Hide Company Tags Amazon Uber Facebook
Hide Tags Array Backtracking Bit Manipulation
Hide Similar Problems (M) Generalized Abbreviation
*/


//Author: new2500

#region Backtracking

	public List<List<int>> Subsets(int[] nums)
	{
		List<List<int>> res = new List<List<int>>();
		//Array.Sort(nums).  No need to sort since it's a distinct
		helper(res, nums, 0, new List<int>());
		return res;
	}
	
	private void helper(List<List<int>> res, int[] nums, int start, List<int> path)
	{
		res.Add(new List<int>(path));
		
		for(int i = start; i < nums.Length; i++)
		{
			path.Add(nums[i]);
			helper(res, nums, i+1, path);
			path.RemoveAt(path.Count - 1);
		}
	}

#end