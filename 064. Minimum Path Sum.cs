/*
64. Minimum Path Sum
 
Total Accepted: 110331
Total Submissions: 289836
Difficulty: Medium
Contributor: LeetCode
Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.

Hide Tags Array Dynamic Programming
Hide Similar Problems (M) Unique Paths (H) Dungeon Game
*/


#region Dynamic Programming

	public int MinPathSum(int[,] grid)
	{
		int rows = grid.GetLength(0);
		int cols = grid.GetLength(1);
		int[,] dp = new int[rows, cols];
		
		dp[0,0] = grid[0,0];   //Set starting value
		
		//Rows boarder set
		for(int i = 1; i < rows; i++)
			dp[i, 0] = dp[i-1, 0] + grid[i,0];
		
		//Cols boarder set
		for(int j = 1; j < cols; j++)
			dp[0,j] = dp[0, j-1] + grid[0, j];
		
		//Calculate inner cells
		for(int i = 1; i < rows; i++)
		{
			for(int j = 1; j < cols; j++)
			{
				dp[i, j] = Math.Min(dp[i-1, j] + grid[i,j],
				                    dp[i, j-1] + grid[i,j]);
			}
		}
		return dp[rows-1, cols-1];
	}

#end