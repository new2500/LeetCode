/*
77. Combinations
 
Total Accepted: 113974
Total Submissions: 291858
Difficulty: Medium
Contributor: LeetCode
Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.

For example,
If n = 4 and k = 2, a solution is:

[
  [2,4],
  [3,4],
  [2,3],
  [1,2],
  [1,3],
  [1,4],
]
Hide Tags Backtracking
Hide Similar Problems (M) Combination Sum (M) Permutations
*/


//Author:new2500

#region Backtracking
	public List<List<int>> Combine(int n, int k)
	{
		List<List<int>> res = new List<List<int>>();
		//Set n into an array
		int[] nums = new int[n];
		for(int i = 0; i < nums.Length; i++)
		{
			nums[i] = i + 1;1
		}
		helper(nums, 0, 0, k, res, new List<int>());
		return res;
	}
	
	private void helepr(int[] nums, int count, int start, int total, 
	                    List<List<int>> res, List<int> path)
	{
		//Exit
		if(count == total)
		{
			res.Add(new List<int>(path));
			return;
		}
		
		for(int i = start; i < nums.Length; i++)
		{
			path.Add(nums[i]);
			helper(nums, count + 1, i + 1, total, res, path);
			path.RemoveAt(path.Count - 1);
		}
	}					
	
#end	


#region Recursive using Math: C(n,k) = C(n-1,k-1) + C(n-1,k), Faster in Runtime

	public List<List<int>> Combines(int n, int k)
	{
		if(k == n || k == 0)//Only one result
		{
			List<int> path = new List<int>();
			for(int i = 1; i <= k; i++)
			{
				path.Add(i);
			}
			res.Add(path);
			return res;
		}
		
		//Rest cases:
		res = this.Combines(n - 1, k - 1);
		res.ForEach(a => a.Add(n));    //Add n for all elements in res
		res.AddRange(this.Combines(n - 1, k));
		return res;
	}


#end