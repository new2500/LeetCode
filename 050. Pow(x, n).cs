/*
50. Pow(x, n)
 
Total Accepted: 149755
Total Submissions: 564399
Difficulty: Medium
Contributor: LeetCode
Implement pow(x, n).

Hide Company Tags LinkedIn Google Bloomberg Facebook
Hide Tags Binary Search Math
Hide Similar Problems (E) Sqrt(x) (M) Super Pow
*/


//Author:new2500


    //Double x way
	public double MyPow(double x, int n)
	{
		if(n == 0)
			return 1;
		if(n == 1)
			return x;
		if(n == -1)
			return 1/x;
		
		var res = MyPow(x, n/2);
		
		return res * res * MyPow(x, n%2);
	}
	#region Aother Version
	public double Pow(double x, int n)
	{
		if(n == 0)
			return 1;
		if(n < 0)
		{
			n = -n;
			x = 1/x;
		}
		
		return (n % 2 == 0) ? Pow(x*x, n/2) : x*Pow(x*x, n/2);
	}
	#endregion
	
	
	//Iterative Way O(logN) time
	/*
	   Idea is decompose the exponent into power of 2, so that can keep dividing the problem in half.
	   
	   Say n = 9, Could convert to 2^3 + 2^0 = 1001, Then:
	   
	   x^9 = x^(2^3) * x^(2^0)
	   
	   Every time we encount a 1 in binary representation of N, we need to multiply the answer with x^(2^i), where i is the ith bit of the exponent. 
	
	*/
	public double MyPow(double x, int n)
	{
		double res = 1;
		long absN = Math.Abs((long)n);  //Use long to avoid overflow
		while(absN > 0)
		{
			if((absN&1) == 1)
				res = res * x;
			
			absN = absN/2;   //Or use absN = absN >> 1; Bit
			x = x * x;
		}
		return n < 0 ? 1/ans : ans;
	}