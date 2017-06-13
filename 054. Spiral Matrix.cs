/*
54. Spiral Matrix
 
Total Accepted: 98480
Total Submissions: 385836
Difficulty: Medium
Contributor: LeetCode
Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.

For example,
Given the following matrix:

[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]
You should return [1,2,3,6,9,8,7,4,5].

Hide Company Tags Microsoft Google Uber
Hide Tags Array
Hide Similar Problems (M) Spiral Matrix II
*/


//Author:new2500


#region In-Palce
// 1. Top Scan from left to right
// 2. Rightmost scan from up to down
// 3. Bottom scan from right to left.
// 4. Leftmost scan from down to up

	public List<int> SpiralOrder(int[,] ,matrix)
	{
		List<int> res = new List<int>();
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		
		int left = 0;
		int right = cols - 1;
		int top = 0;
		int bottom = rows - 1;
		int direction = 0;
		
		
		while(left <= right && top <= bottom)
		{
			if(direction == 0)         //->  Horizontal  - left to right
			{
				for(int i = left; i <= right; i++)
				{
					res.Add(matrix[top,i]);
					top++;
				}
			}
			else if(direction == 1) 			//|V Vertical - top to bottom
			{
				for(int i = top; i <= bottom; i++)
				{
					res.Add(matrix[i,right);
					right--;
				}
			}
			else if(direction == 2) // <- Horizontal - right to left
			{
				for(int i = right; i >= left; i--)
				{
					res.Add(matrix[bottom, i]);
					bottom--;
				}
			}
		    else if(direction == 3)
			{
				for(int i = bottom; i >= top; i--)
				{
					res.Add(matrix[i,left]);
					left++;
				}
			}
			direction = (direction + 1) % 4;
		}
		return res;
	}

#end 

