/*
73. Set Matrix Zeroes
 
Total Accepted: 101605
Total Submissions: 284835
Difficulty: Medium
Contributor: LeetCode
Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in place.

Hide Company Tags Microsoft Amazon
Hide Tags Array
Hide Similar Problems (M) Game of Life
*/

#region 



#end
/*
Follow up:
Did you use extra space?
A straight forward solution using O(mn) space is probably a bad idea.
A simple improvement uses O(m + n) space, but still not the best solution.
Could you devise a constant space solution?
*/


#region Constant Space  O(N^2) time
/*
1. Check if the 1st row and 1st col have 0s
2. Iterate the rest of matrix, set matrix[i,0] and matrix[0,j] to 0 whenever [i,j] == 0
3. Same like above, set matrix[0,j] to 0 if col has 0
4. Set 1st row and cols to 0 if necessary
*/

	public void SetZeros(int[,] matrix)
	{
		if(matrix == null)
			return;
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		
		bool hasZeroFirstRow = false, hasZeroFirstCol = false;
		
		for(int i = 0; i < rows; i++)
		{
			for(int j = 0; j < cols; j++)
			{
				if(matrix[i,j] == 0)
				{
					if(i == 0) hasZeroFirstRow = true;
					if(j == 0) hasZeroFirstCol = true;
					matrix[i,0] = 0;    //Set first col to 0
					matrix[0,j] = 0;    //Set first row to 0
				}
			}
		}	
		for(int i = 1; i < rows; i++)
		{
			for(int j = 1; j < cols; j++)
			{
				if(matrix[i,0] == 0 || matrix[0,j] == 0)
				{
					matrix[i,j] = 0;
				}
			}
		}
		
		if(hasZeroFirstRow)
		{
			for(int i = 0; i < rows; i++)
				matrix[i,0] = 0;
		}
		if(hasZeroFirstCol)
		{
			for(int j = 0; j < cols; j++)
				matrix[0,j] = 0;	
		}
	}


#end