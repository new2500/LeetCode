/*
43. Multiply Strings
 
Total Accepted: 100369
Total Submissions: 375805
Difficulty: Medium
Contributor: LeetCode
Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2.

Note:

The length of both num1 and num2 is < 110.
Both num1 and num2 contains only digits 0-9.
Both num1 and num2 does not contain any leading zero.
You must not use any built-in BigInteger library or convert the inputs to integer directly.
Hide Company Tags Facebook Twitter
Hide Tags Math String
Hide Similar Problems (M) Add Two Numbers (E) Plus One (E) Add Binary (E) Add Strings
*/


//Author:new2500

//Straightforward High School Math way O(N*M), N and M is length of nums1 and nums2
	public string Multiply(string nums1, string nums2)
	{
		//if(Convert.ToInt(nums1) == 0 || ConvertToInt(nums2) == 0)
		//	return "0";   Cound be omitted.
		
		int[] res = new int[nums1.Length + nums2.Length];
		
		for(int i = nums1.Length - 1; i >= 0; i--)
		{
			for(int j = nums2.Length - 1; j >= 0; j--)
			{
				int mul = (nums1[i] - '0') * (nums2[j] - '0');
				int p1 = i + j;
				int p2 = i + j + 1;
				int sum = mul + res[p2];
				
				res[p1] = res[p1] + sum/10;
				res[p2] = sum % 10;
			}
		}
		//Convert array to string
		StringBuilder sb = new StringBuilder();
		for(int i = 0; i < res.Length; i++)
		{
			if(sb.Length == 0 && res[i] == 0)   //Skip the leading 0
				continue;
			sb.Append(res[i]);	
		}
		return sb.Length == 0 ? "0" : sb.ToString();
	}
	
