/*
85. Maximal Rectangle
 
Total Accepted: 64462 Total Submissions: 236071 Difficulty: Hard
Contributor: LeetCode
Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.

For example, given the following matrix:

1 0  1  0  0
1 0 `1 `1 `1
1 1 `1 `1 `1
1 0  0  1  0
Return 6.
Hide Company Tags Facebook
Hide Tags Array Hash Table Stack Dynamic Programming
Hide Similar Problems (H) Largest Rectangle in Histogram (M) Maximal Square
*/




//Author: new2500


#region DP O(m*n) time, O(3*n) space

//dp start from first row
//use formula area : (right(i,j) - left(i,j)) * height(i,j))
//left(i,j) = Max(left(i-1, j) , currLeft), currLeft can be determined from current row,
//right(i,j) = Min(right(i-1.j), currRight), currRight can be determined from current row
//height(i,j) = height(i-1, j) + 1 ,if matrix[i,j] = '1'
//            = 0, if matrix[i,j] = '0'


	public int MaximalRectangle(char[,] matrix)
	{
		int m = matrix.GetLength(0);
		int n = matrix.GetLength(1);
		int maxArea = 0;
		
		// left: [n,0]; right:[n,1]; height: [n,2]
		int[,] dp = new int[n,3];
		//Set right.
		for(int i= 0; i < n; i++)
			dp[i,1] = n;
		
		
		for(int i = 0; i < m; i++)
		{
			int currLeft = 0, currRight = n;
			
			for(int j = 0; j < n; j++)
			{
				// Height:Add or reset ; Left, trak Max or Reset
				if(matrix[i,j] == '1')
				{
					dp[j,2]++;
					dp[j,0] = Math.Max(dp[j,o], currLeft);
				}	
				else
				{
					dp[j,2] = 0;
					dp[j,0] = 0; currLeft = j + 1;
				}	
			}
			
			//Right ( From right to left)
			for(int j = n - 1; j >= 0; j--)
			{
				if(matrix[i,j] == '1')
					dp[j,1] = Math.Min(dp[j,1], currRight);
				else
				{
					dp[j,1] = n;
					currRight = j;
				}
			}
			//Area of rectangle
			for(int j = 0; j < n; j++)
			{
				//(Right - Left) * Height
				maxArea = Math.Max(maxArea, (dp[j,1] - dp[j,0]) * dp[j,2] )
			}	
		}
		return maxArea;
	}

#end





#region