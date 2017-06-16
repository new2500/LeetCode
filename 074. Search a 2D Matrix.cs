/*
74. Search a 2D Matrix
DescriptionHintsSubmissionsSolutions
Total Accepted: 122173
Total Submissions: 347175
Difficulty: Medium
Contributor: LeetCode
Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

Integers in each row are sorted from left to right.
The first integer of each row is greater than the last integer of the previous row.
For example,

Consider the following matrix:

[
  [1,   3,  5,  7],
  [10, 11, 16, 20],
  [23, 30, 34, 50]
]
Given target = 3, return true.

Hide Tags Array Binary Search
Hide Similar Problems (M) Search a 2D Matrix II
*/


//Author:new2500

#region Binary Search due to it's a sorted matrix O(log(N*M)) time, O(1) space
	public bool SearchMatrix(int[,] matrix, int target)
	{
		int rowLength = matrix.GetLength(0);
		
		int low = 0;
		int high = matrix.Length - 1;  //last element of matrix
		
		while(low <= high)
		{
			int mid = low + (high - low) / 2;
			int midCol = mid / rowLength;
			int midRow = mid % rowLength;
			
			if(matrix[midRow, midCol] == target)
				return true;
			else if(matrix[midRow,midCol] > target)
			{
				high = mid - 1;
			}
			else
			{
				low = mid + 1;
			}
		}
		return false;
	}
#end




#region Brutal Force for general matrix O(N*M) time

	public bool SearchMatrix(int[,] matrix, int target)
	{
		for(int i = 0; i < matrix.GetLength(0); i++)
		{
			for(int j = 0; j < matrix.GetLength(1); j++)
			{
				if(matrix[i,j] == target)
					return true;
			}
		}
		return false;
	}


#end