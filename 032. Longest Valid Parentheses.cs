/*
32. Longest Valid Parentheses

Total Accepted: 93848
Total Submissions: 408027
Difficulty: Hard
Contributor: LeetCode
Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

For "(()", the longest valid parentheses substring is "()", which has length = 2.

Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.

Hide Tags Dynamic Programming String
Hide Similar Problems (E) Valid Parentheses
*/

//Author:new2500
#region O(N) time, O(N) space Using a Stack
public int LongestValidParentheses(string s)
{
	int res = 0;
	var stack = new Stack<int>();
	
	for(int i = 0; i < s.Length; i++)
	{
		if(s[i] == '(')
			stack.Push(i);
		else  //s[i] != (
		{
			if(stack.Any() && s[stack.Peek()] == '(')
			{
				stack.Pop();
				res = Math.Max(res, i - (stack.Any() ? stack.Peek() : -1);
			}
			else
				stack.Push(i);
		}
	}
	return res;
}
#endregion


#region O(N) time, O(N) space, Using Dynamic Programming
//We use a dp array where ith element of dp: the length of longest valid substring ending at ith index.
//Obviously valid substring end at ')'. So '(' is 0 and update dp when we met ')'

//1. if s[i] = ')' and s[i-1] = '(' string lke".....()': dp[i] = dp[i-2] + 2;
//2. if s[i] = ')' and s[i-1] = ')' string like"....))' : if s[i-dp[i-1]-1] = '(' => dp[i] = dp[i-1] + dp[i-dp[i-1]-2] + 2.

// Exp: If the 2nd last ')' was a part of valid substring(say subS), for the last ')' to be part of a largest substring, there must be a corresponding string '(' at front(subS string index -1) : We update the dp[i] as subS's length +2, which is dp[i-1]+2. To this, we also add the length of valid substring just before the term '(', subS,')', dp[i-dp[i-1-2]]

//Example:
//index   0  1  2  3  4  5  6  7
//        (  )  )  (  (  (  )  )
//dp[]    0  2  0  0  0  0  2  4
//                  this 2 from dp[4]+2  
//                            this 4 from dp[6] + 2(from dp[3])


public int DP(string s)
{
	int res = 0;
	int[] dp = new int[s.Length];  //dp[0] always will be 0
	
	for(int i = 1; i < s.Lenght; i++)
	{
		if(s[i] == ')')
		{
			if(s[i-1] == '(')
				dp[i] = ( (i >= 2) ? dp[i-2] : 0)  + 2;
			
			else if(i- dp[i-1] > 0 && s[i-dp[i-1]-1] == '(' )
			{
				dp[i] = dp[i-1] 
				       +(i-dp[i-1]) >= 2 ? dp[i-dp[i-1]-2] : 0 
					   + 2;
			}
			res = Math.Max(res, dp[i]);
		}
	}
	return res;
}

#endregion




#regionBestSpace

O(2N) time, O(1) space
//We use Two pointers.

//1. Start from left to right: 
//     When meet '(', we left++; When meet ')', right++
//        a. Whenever left == right, we calculate the length of the current valid string and keep tracking of maximum length found so far.
//        b. If right > left, we reset left & right to 0.    
//2. Then we do the same thing, but now we start from right to left.


public int SaveSpace(string s)
{
	int left = 0, right = 0, res = 0;
	
	for(int i = 0; i < s.Length; i++)
	{
		if(s[i] == '(')
			left++;
		else if (s[i] == ')')
			right++;
		
		if(left == right)
			res = Math.Max(res, 2 * right)
		else if(right >= left)
			left = 0; right = 0;
	}
	
	left = 0; right = 0;
	for(int i = s.Length-1; i >= 0; i--)
	{
		if(s[i] == '(')
			left++;
		else if (s[i] == ')')
			right++;
		
		if(left == right)
			res = Math.Max(res, 2 * right)
		else if(left >= right)
			left = 0; right = 0;
	}
	
	return res;
}



#region

