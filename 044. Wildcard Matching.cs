/*
44. Wildcard Matching
 
Total Accepted: 91629
Total Submissions: 464901
Difficulty: Hard
Contributor: LeetCode
Implement wildcard pattern matching with support for '?' and '*'.

'?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).

The matching should cover the entire input string (not partial).

The function prototype should be:
bool isMatch(const char *s, const char *p)

Some examples:
isMatch("aa","a") → false
isMatch("aa","aa") → true
isMatch("aaa","aa") → false
isMatch("aa", "*") → true
isMatch("aa", "a*") → true
isMatch("ab", "?*") → true
isMatch("aab", "c*a*b") → false
Hide Company Tags Google Snapchat Two Sigma Facebook Twitter
Hide Tags Dynamic Programming Backtracking Greedy String
Hide Similar Problems (H) Regular Expression Matching

*/



//Author: new2500


//dp version. Use [,] to store all the result
// dp[i,j] = dp[i-1,j-1] if(s[i] == p[i]||p[j] == "?")
// dp[i,j] = dp[i-1,j] || dp[i,j-1] if(p[j] == '*')
//(where dp[i,j-1] means * meatch non-zero sequence,p = 0; d[i-1,j] mean * match zero sequence, p = something)
//dp[i,j] = false -> not match


	public bool IsMatch(string s, string p)
	{
		bool[,] dp = new bool[s.Length + 1, p.Length + 1];
		dp[0,0] = true;
		
		//Special case: p is '*'.
		for(int j = 0; j < p.Length; j++)
		{
			if(p[j] == '*')
				dp[0,j + 1] = dp[0, j];
		}
		
		//Normal case
		for(int i = 0; i < s.Length; i++)
		{
			for(int j = 0; j < p.Length; j++)
			{
				if(s[i] == p[j])
				{
					dp[i + 1, j + 1] = dp[i,j];
				}
				else
				{
					if(p[j] == '?')
					{
						dp[i + 1, j + 1] = dp[i,j];
					}
					else if(p[j] == '*')
					{
						dp[i+1, j+1] = (dp[i,j+1] || dp[i+1, j])
					}
					else   //Else false
					{
						dp[i+1,j+1] = false;
					}
				}
			}
		}
		return dp[s.Length, p.Length];
	}
	
	
	
	
	
	
	
	