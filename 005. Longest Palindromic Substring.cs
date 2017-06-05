/*5. Longest Palindromic Substring
Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

Example:

Input: "babad"

Output: "bab"

Note: "aba" is also a valid answer.
Example:

Input: "cbbd"

Output: "bb"


Company: AmZ, M$, BB
Tag: String
Similar: Shortest Palindrome H, Palindrome Permutation E, Palindrome Pairs H, Longest Palindromic Subsequence M

*/

//Author: new2500

//O(N^2) time O(1) space. Since expanding a palindrome around its center could take O(n) time, the overall complexity is O(n^2).
  public string LongestPalindrome(string s) {
	  if(string.IsNullOrEmpty(s))
		  return s;
	  
	  string res = s.Substring(0,1);  //Handle when the s is 1 char
	  int max = 1;
	  
	  for(int i = 0; i < s.Length; i++)
	  {
		  int half = 0;
		  //Even-length PSubstring case:  s[i]==s[i+1]
		  while(i - half >= 0 && i + half +1 <= s.Length && s[i-half] == s[i+half+1])
				{
					if(2*half + 2 > max)
					{
						max = 2*half+2;  //Track the Max Length 
						res = s.Substring(i-half, max);
					}
					half++;
				}
		  //Reset half for Odd case
          half = 0;
		  //Odd case:     s[i-1]  s[i] s[i+1]
          while(i - half -1 >= 0 && i + half + 1 <= s.Length && s[i-half - 1] == s[i+half])
		  {
			  if(2*half + 3 > max)
			  {
				  max = 2*half + 3;
				  res = s.Substring(i-half-1, max);
			  }
			  half++;
		  }			  
				
	  }
	  return res;
  }
  
  
  //O(N^2) time, O(N^2) space DP
  
      public string LongestPalindrome(string s) {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return s;

             bool[,] dp = new bool[s.Length,s.Length];
            int maxLen = 1;

            int head = 0;
            for (int j = 0; j < s.Length; j++)
            {
                for (int i = 0; i <= j; i++)
                {
                    dp[i, j] = (s[i] == s[j] && 
					           (j - i <= 2 || dp[i + 1, j - 1]));
                    if (dp[i, j] == true)
                    {
                        if (j - i + 1 > maxLen)
                        {
                            maxLen = j - i + 1;
                            head = i;
                        }
                    }
                }

            }
            return s.Substring(head, maxLen);
    } 