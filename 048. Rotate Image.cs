/*
48. Rotate Image by 90 degree clockwise
 
Total Accepted: 111604
Total Submissions: 292827
Difficulty: Medium
Contributor: LeetCode
You are given an n x n 2D matrix representing an image.

Rotate the image by 90 degrees (clockwise).

Follow up:
Could you do this in-place?

Hide Company Tags Amazon Microsoft Apple
Hide Tags Array
*/

#region In-Place "Ring by Ring" Algorithm

	public void Rotate(int[,] matrix)
	{
		if(matrix == null || matrix.Length == 0)  //check null&empty
			return;
		
	    int n = matrix.GetLength(0) - 1;
		
		//i: the layer of matrix
		for(int i = 0; i <= n/2; i++)    //define layer
		{
			for(int j = i; j < n-i; j++) //For each layer
			{
				//For each layer, keep swaping the symmetry point
				/* 1 2 3     7 2 3     7 2 3     7 2 3      7 2 1
				   4 5 6  => 4 5 6  => 4 5 6  => 4 5 6   => 4 5 6
				   7 8 9     7 8 9     9 8 9     9 8 3      9 8 3
				   
				   Next is starting at 4 , we shou have the result
				*/ 
				int temp = matrix[i,j];            //save 1
				matrix[i,j] = matrix[n-j, i];      //7 to 1
				matrix[n-j,i] = matrix[n-i,n-j];  //9 to old7
				matrix[n-i,n-j] = matrix[j, n-i]; //3 to old9
				matrix[j, n-i] = temp;            //1 to old3
				
				/*
				Similar, if ask to anti-clockwise 90 degree:
				    We starting at 7.
					int temp = matrix[n - j, i];      //save 7
                    matrix[n - j, i] = matrix[i,j];   //1 to 7
                    matrix[i, j] = matrix[j, n - i];  //3 to old1
                    matrix[j, n - i] = matrix[n - i, n - j];   //9 to old3
                    matrix[n - i, n - j] = temp;        //7 to old 9		
				*/
			}
		}
	}

#endregion




#region Reverse top and bottom, then Swap the symmetry(If Reverse leftmost and rightmost, and swap, we can get anti-clockwise rotate)

	public void Rotate90Clock(int[,] matrix)
	{
		
	}
