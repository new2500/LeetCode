/*
87. Scramble String
 
Total Accepted: 62662 Total Submissions: 217427 Difficulty: Hard
Contributor: LeetCode
Given a string s1, we may represent it as a binary tree by partitioning it to two non-empty substrings recursively.

Below is one possible representation of s1 = "great":

    great
   /    \
  gr    eat
 / \    /  \
g   r  e   at
           / \
          a   t
To scramble the string, we may choose any non-leaf node and swap its two children.

For example, if we choose the node "gr" and swap its two children, it produces a scrambled string "rgeat".

    rgeat
   /    \
  rg    eat
 / \    /  \
r   g  e   at
           / \
          a   t
We say that "rgeat" is a scrambled string of "great".

Similarly, if we continue to swap the children of nodes "eat" and "at", it produces a scrambled string "rgtae".

    rgtae
   /    \
  rg    tae
 / \    /  \
r   g  ta  e
       / \
      t   a
We say that "rgtae" is a scrambled string of "great".

Given two strings s1 and s2 of the same length, determine if s2 is a scrambled string of s1.

Hide Tags Dynamic Programming String
*/


#region Divide and Conqure algorithm, divide into 4 sub-peoblems, so it's O(4^n) time


	public bool IsScramble(string s1, string s2)
	{
		//Check is same
		if(s1.Equals(s2))
			return true;
		//Dict 
		int[] letters = new int[26];
		for(int i = 0; i < s1.Length; i++)
		{
			letters[s1[i] - 'a']++;
			letters[s2[i] - 'a']--;
		}
		//Return false if exist different elements
		for(int i = 0; i < 26; i++)
		{
			if(letters[i] != 0)
				return false;
		}
		
		//Check if Scramble
		for(int i = 1; i < s1.Length; i++)
		{
			//Check If left of s1 VS left of s2 && right of s1 VS right of s2
			if(IsScramble(s1.Substring(0, i), s2.Substring(0, i))
			   &&IsScramble(s1.Substring(i), s2.Substring(i)))
				return true;
				
			//Check If left of s1 vs right of s2 && right of s1 VS left of s2
			//Be aware of the Length
			if(IsScramble(s1.Substring(0, i), s2.Substring(s1.Length - i))
			   &&IsScramble(s1.Substring(i), s2.Substring(0, s1.Length - i)))
				return true;			
		}
		return false;
	}
#end


#region Bottom-up DP O(4^N) time, O(3N) space

        public bool IsScamble(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1))
                return true;
            //dp[i,j,l] means if s2.Substring(j,l) is a scrambled string of s1.Substring(i,l)
            bool[,,] dp = new bool[s1.Length,s2.Length,s1.Length+1];
 		 
		    * S1 [   x1    |         x2         ]
			*    i         i + n                i + l
			* 
			* here we have two possibilities:
			*      
			* S2 [   y1    |         y2         ]
			*    j         j + n                j + l
			*    
			* or 
			* 
			* S2 [       y1        |     y2     ]
			*    j                 j + l - n    j + l
		 * 
            for (int i = s1.Length - 1; i >= 0; i--)
            {
                for (int j = s2.Length - 1; j >= 0; j--)
                {
                    dp[i, j, 1] = (s1[i] == s2[j]);

                    for (int l = 2; i + l <= s1.Length && j + l <= s2.Length; l++)
                    {
                        for (int n = 1; n < l; n++)
                        {
                            dp[i, j, l] |= dp[i, j, n] && dp[i + n, j + n, l - n];
                            dp[i, j, l] |= dp[i, j + l - n, n] && dp[i + n, j, l - n];
                        }
                    }
                }
            }
            return dp[0, 0, s1.Length];
        }
#end