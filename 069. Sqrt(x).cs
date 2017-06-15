/*
69. Sqrt(x)
 
Total Accepted: 153625
Total Submissions: 556907
Difficulty: Easy
Contributor: LeetCode
Implement int sqrt(int x).

Compute and return the square root of x.

Hide Company Tags Bloomberg Apple Facebook
Hide Tags Binary Search Math
Hide Similar Problems (M) Pow(x, n) (E) Valid Perfect Square
*/



//Author: new2500

	public int MySqrt(int x)
	{
		int res = 0;
		int low = 1;
		int high = x;
		
		while(low <= high)
		{
			int mid = low + (high - slow)/2;
			
			//Happen to be perfect square
			if(mid == x / mid)
			{
				res = mid;
				break;
			}
			else if(mid < x / mid)
			{
				res = mid;
				low = mid + ;
			}
			else
			{
				high = mid - 1;
			}
		}
		return res;
	}
