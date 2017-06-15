/*
72. Edit Distance
 
Total Accepted: 86624
Total Submissions: 276414
Difficulty: Hard
Contributor: LeetCode
Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2. (each operation is counted as 1 step.)

You have the following 3 operations permitted on a word:

a) Insert a character
b) Delete a character
c) Replace a character
Hide Tags Dynamic Programming String
Hide Similar Problems (M) One Edit Distance (M) Delete Operation for Two Strings
*/


//Author: new2500


#region O(N+M+N*M) time, O(N*M)space: N and M is the length of word1 and word2
//Assume we know number before dp[i,j].
//1. If word1[i] == word2[j] , just get dp[i-1,j-1]
//2. If word1[i] != words[j], then
//   a. based dp[i-1,j - 1], just change word1[i] to word2[j]
//   b. based dp[i, j - 1], just add a char at word2[j]
//   c. base  dp[i-1, j], just delete a chat at word1[i]
//3. For the Beginning, dp[0,0] = 0, dp[i,0] == dp[0,i] = i, base case



	public int MinDistance(string word1, string word2)
	{
		int len1 = word1.Length;
		int len2 = word2.Length;
		int[,] dp = new int[len1 + 1, len2 + 1];
		dp[0,0] = 0;
		
		//initialize word1 & word2 
		for(int i = 0; i < len1; i++)
		{
			dp[i+1, 0] = i + 1;
		}
		for(int j = 0; j < len2; j++)
		{
			dp[0, j+1] = j + 1;
		}
		
		//Calcluate the min distance between word1 & word2
		for(int i = 0; i < len1; i++)
		{
			for(int j= 0; j < len2; j++)
			{
				if(word1[i] == word2[j])  //No need to increment
				{
					dp[i+1, j+1] = dp[i,j];
				}
				else
				{
					dp[i+1, j+1] = 1 + Math.Min(Math.Min(dp[i, j+1, dp[i+1,j])
					                            , dp[i, j]);
					               
				}
			}
		}
		return dp[len1, len2];
	}