/*
70. Climbing Stairs
 
Total Accepted: 172822
Total Submissions: 436699
Difficulty: Easy
Contributor: LeetCode
You are climbing a stair case. It takes n steps to reach to the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Note: Given n will be a positive integer.

Hide Company Tags Adobe Apple
Hide Tags Dynamic Programming
*/




#region Brutal Force Memorzation Recursive, using a Hash Table O(2^N) time, O(N) space

	private Dictionary<int, int> dict = new Dictionary<int, int>();
	
	public int ClimbingStairs(int n)
	{
		if(n <= 2)
			return n;
		if(dict.ContainsKey(n))
			return dict[n];
		
		int temp = ClimbingStairs(n - 1) + ClimbingStairs(n - 2);
		dict.Add(n, temp);
		return temp;
	}
#end


#region O(N) time, O(1) space DP
	public int ClimbingStairs(int n)
	{
		if(n == 0)
			return 0;
		
		int oneStep = 0, twoSteps = 1;
		
		for(int i = 2; i <= n; i++)
		{
			int curr = oneStep + twoSteps;
			oneStep = twoSteps;
			twoSteps = curr;
		}
		return oneStep + twoSteps;
	}
#end


