/*
66. Plus One
 
Total Accepted: 167893
Total Submissions: 440040
Difficulty: Easy
Contributor: LeetCode
Given a non-negative integer represented as a non-empty array of digits, plus one to the integer.

You may assume the integer do not contain any leading zero, except the number 0 itself.

The digits are stored such that the most significant digit is at the head of the list.

Hide Company Tags Google
Hide Tags Array Math
Hide Similar Problems (M) Multiply Strings (E) Add Binary (M) Plus One Linked List
*/



//Author:new2500


	public int[] PlusOne(int[] digits)
	{
		for(int i = digits.Length - 1; i >= 0; i--)
		{
			if(digits[i] < 9) //No need to consider overflow
			{
				digits[i]++;
				return digits;   //Exit, so just affect the last non-9 digit
			}
			//Since digits[i] == 9, set current to 0
			digits[i] == 0;
		}
		//If reach here, mean the digits is 99 or 999 like cases...
		int[] res = new int[digits.Length + 1];
		res[0] = 1; 
		return res;
	}
	
	
/*If asked to do it in a reverse way,
Examples: 
Given: 1,2,3, Return 2,2,3
Given: 8,4,9  Return 9,4,9
Given: 9,9,9  Return 1,0,0,0	
*/	
#region 

	public int[] PlusOneFromHead(int[] digits)
	{
		for(int i = 0; i < digits.Length; i++)
		{
			if(digits[i] < 9)
			{
				digits[i]++;
				return digits;
			}
			digits[i] == 0;
		}
		
		int[] res = new int[digits.Length + 1];
		res[res.Length - 1] = 1;
		return res;
	}




#end