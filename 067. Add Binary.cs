/*
67. Add Binary
 
Total Accepted: 141300
Total Submissions: 443968
Difficulty: Easy
Contributor: LeetCode
Given two binary strings, return their sum (also a binary string).

For example,
a = "11"
b = "1"
Return "100".

Hide Company Tags Facebook
Hide Tags Math String
Hide Similar Problems (M) Add Two Numbers (M) Multiply Strings (E) Plus One
*/



//Author:new2500



	public string AddBinary(string a, string b)
	{
		int carry = 0;
		StringBuilder sb = new StringBuilder();
		
		for(int startA = a.Length - 1, startB = b.Length - 1;
		    startA >= 0 || startB >= 0; startA--, startB--)
		{
			int currA = startA >= 0 ? a[startA] - '0' : 0;
			int currB = startB >= 0 ? b[startB] - '0' : 0;
			int sum = currA + currB + carry;
			
			if(sum > 1) //Need carry
			{
				sb.Insert(0, sum % 2); //Insert At front
				carry = 1;
			}
			else
			{
				sb.Insert(sum);
				carry = 0;
			}
		}
			
		if(carry == 1)
		{
			sb.Insert(0, '1');
		}
		return sb.ToString();	
	}