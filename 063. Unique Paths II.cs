/*
63. Unique Paths II
 
Total Accepted: 101443
Total Submissions: 322593
Difficulty: Medium
Contributor: LeetCode
Follow up for "Unique Paths":

Now consider if some obstacles are added to the grids. How many unique paths would there be?

An obstacle and empty space is marked as 1 and 0 respectively in the grid.

For example,
There is one obstacle in the middle of a 3x3 grid as illustrated below.

[
  [0,0,0],
  [0,1,0],
  [0,0,0]
]
The total number of unique paths is 2.

Note: m and n will be at most 100.

Hide Company Tags Bloomberg
Hide Tags Array Dynamic Programming
Hide Similar Problems (M) Unique Paths
*/

//Author:new2500	

	public int UniquePathWithObstacles(int[,] obstacleGrid)
	{
		if(obstacleGrid == null)
			return 0;
		
		int rows = obstacleGrid.GetLength(0);
		int cols = obstacleGrid.GetLength(1);
		int[,] dp = new int[rows, cols];
		
		for(int i = 0; i < rows; i++)
		{
			for(int j = 0; j < cols; j++)
			{
				if(obstacleGrid[i,j] == 1) //Meet obstacle
				{
					dp[i,j] = 0;
					continue;
				}
				if(i == 0 && j == 0) //Set start point value
					dp[i,j] = 1;
				else
				{
					dp[i,j] = (i > 0 ? dp[i-1, j] : 0)
					         +(j > 0 ? dp[i, j-1] : 0);
				}
			}
		}
		return dp[rows-1, cols-1];
	}