/*
62. Unique Paths
 
Total Accepted: 136963 Total Submissions: 338231 Difficulty: Medium
Contributor: LeetCode
A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

How many possible unique paths are there?


Above is a 3 x 7 grid. How many possible unique paths are there?

Note: m and n will be at most 100.

Hide Company Tags Bloomberg
Hide Tags Array Dynamic Programming
Hide Similar Problems (M) Unique Paths II (M) Minimum Path Sum (H) Dungeon Game

*/

//Author:new2500

#region DP Solution. O(N) time, O(N) space, Travel from target to source

	public int UniquePaths(int m, int n)
	{
		int[,] dp = new int[m, n];
		
		for(int i = m - 1; i >= 0; i--)
		{
			for(int j = n - 1; j >= 0; j--)
			{
				if(i == m - 1 || j == n - 1)//Only 1 way to end
					dp[i,j] = 1;
				else                        //Two ways to go
					dp[i,j] = dp[i+1, j] + dp[i, j+1];
			}
		}
		return dp[0, 0];
	}


#end