/*
59. Spiral Matrix II
 
Total Accepted: 79420
Total Submissions: 203227
Difficulty: Medium
Contributor: LeetCode
Given an integer n, generate a square matrix filled with elements from 1 to n2 in spiral order.

For example,
Given n = 3,

You should return the following matrix:
[
 [ 1, 2, 3 ],
 [ 8, 9, 4 ],
 [ 7, 6, 5 ]
]
Hide Tags Array
Hide Similar Problems (M) Spiral Matrix
*/


//Author:new2500


	public int[,] GenerateMatrix(int n)
	{
		int[,] matrix = new int[n, n];
		int top = 0, bottom = n - 1;
		int left = 0, right = n - 1;
		
		int direction = 0;
		int num = 1; //Act as seed
		
		while(right >= left && bottom >= top)
		{
			if(direction == 0) //->
			{
				for(int i = left; i <= right; i++, num++)
				{
					matrix[top, i] = num;
					top++;
				}
			}
			else if(direction == 1) //|v
			{
				for(int i = top; i <= bottom; i++, num++)
				{
					matrix[right, i] = num;
					right--;
				}
			}
			else if(direction == 2) //<-
			{
				for(int i = right; i >= left; i++, num++)
				{
					matrix[bottom, i] = num;
					bottom--;
				}
			}
			else if(direction == 3) //|^
			{
				for(int i = bottom; i >= top; i++, num++)
				{
					matrix[left, i] = num;
					left++;
				}
			}
			direction = (direction + 1) % 4;
		}
		return matrix;
	}