/*
29. Divide Two Integers
 
Total Accepted: 100618
Total Submissions: 630034
Difficulty: Medium
Contributor: LeetCode


Divide two integers without using multiplication, division and mod operator.

If it is overflow, return MAX_INT.

Hide Tags Math Binary Search
*/


//Author: new2500

//Personally I am not a big fan of bit in interview. So I used a more verbose but clear logic way

public int Divide(int divident, int divisor)
{
	//Make number positive to easier
	//Use long to avoid int overflow
	
	int sign = 1;
	if(dividend > 0 && divisor < 0 || dividend < 0 && divisor > 0)
		sign = -1;
	
	long m = Math.Abs((long)dividend);    //Convert long within Abs is improtant!
	long n = Math.Abs((long)divisor);
	
	//Edge cases
	if(n == 0) return int.MaxValue;
	if(m == 0 || m < n) return 0;
	
	long lAns = lDivide(m, n);
	
	int ans = 0;
	
	if(lAns > int.MaxValue)
		ans = (sign == 1) ? int.MaxValue : int.MinValue;
    else
		ans = (int)(sign*lAns);
	
	return ans;
}

private long lDivide(long m, long n)
{
	//Exit case
	if(m < n)
		return 0;
	
	long sum = n;
	long count = 1;
	
	while(sum + sum <= m)
	{
		sum = sum+sum;
		count = count+count;
	}
	
	return count + lDivide(m-sum, n);
}



#regionBit
    //Bit version
    public int Divide(int dividend, int divisor) {
    if (divisor == 0) 
		return int.MaxValue;
    int sign = dividend > 0 ^ divisor > 0 ? -1 : 1;
	
    long m = Math.Abs((long)dividend); 
	long n = Math.Abs((long)divisor), 
	long count = 0;
    for (m -= n; m >= 0; m -= n){
        count++;
        if (m == 0) break;
        for (int subCount = 1; m - (n << subCount) >= 0; subCount++){
            m -= n << subCount;
            count += (int)Math.Pow(2, subCount);
        }
    }
    return count*sign > int.MaxValue ? int.MaxValue : (int)count*sign;
    }



#endregion
