/*10. Regular Expression Matching

Implement regular expression matching with support for '.' and '*'.

'.' Matches any single character.
'*' Matches zero or more of the preceding element.

The matching should cover the entire input string (not partial).

The function prototype should be:
bool isMatch(const char *s, const char *p)

Some examples:
isMatch("aa","a") → false
isMatch("aa","aa") → true
isMatch("aaa","aa") → false
isMatch("aa", "a*") → true
isMatch("aa", ".*") → true
isMatch("ab", ".*") → true
isMatch("aab", "c*a*b") → true

Company tags: Google, Uber, Airbnb, Facebook, Twitter
Tag:DP, Backtracking, String
Similar: Wildcard Matching H
*/


//Author: new2500

//Naive Recursion
public bool isMatch(string s, string p)
{
	if(p.Length == 0) return s.Length == 0;
	if(p.Length = =1) return (s.Length == 1 && (p[0] == '.' || p[0] == s[0]);
	
	//p longer than 1
	if(p[1] == '*')
	{
		if(isMatch(s, p.Substring(2))) return true;
		
		return s.Length > 0 && (p[0] == '.' || s[0] == p[0])
		                    && isMatch(s.Substring(1), p);
	}
    else
	{
		return s.Length > 0 && (p[0] == '.' || s[0] == p[0])
		                    && isMatch(s.Substring(1), p.Substring(1));
	}
}




//DP
public bool IsMatch(string s, string p)
{
	bool[,] dp = new bool[s.Length+1, p.Length+1];
	dp[0,0] = true;      //empty s VS empty params
  // dp[i, j] = true: string s before index i and string p before index j are match.
	
	//Deals with p like a*, a*b*c and empty s
	for(int j = 1; j <= p.Length; j++)
	{
		if(p[j-1] == '*')
			dp[0,j] = dp[0,j-2];
	}
	/*	
	Rules:
	1. dp[i,j] = dp[i-1, j-1]  if p[j] = '.' || p[j-1]=s[i-1]
	2. When p[j-1] =='*;, dp[i,j]:
	  if:
	    1. match zero element, dp[i,j-2]
		2. match at least 1 element, dp[i-1,j] && (s[i-1] == p[j-2] or p[j-2] == .)
	3. dp[i,j] = false 	
	*/
	for(int i = 1; i <= s.Length; i++)
	{
		for(int j = 1; j <= p.Lenght; j++)
		{
			if(s[i-1] == p[j-1] || p[j-1] == '.')
				dp[i,j] = dp[i-1.j-1];
			else if(p[j-1] == '*')
			{
				dp[i,j] = dp[i,j-2] ||      //Rule2 case 1.
				         (dp[i-1,j] && (p[j-2] == s[i-1] || p[j-2] == '.'));      ////Rule2 case 2.
			}
			else
				dp[i,j] = false;
		}
	}
	return dp[s.Length, p.Length];
}