/*
60. Permutation Sequence
 
Total Accepted: 81456
Total Submissions: 290561
Difficulty: Medium
Contributor: LeetCode
The set [1,2,3,…,n] contains a total of n! unique permutations.

By listing and labeling all of the permutations in order,
We get the following sequence (ie, for n = 3):

"123"
"132"
"213"
"231"
"312"
"321"
Given n and k, return the kth permutation sequence.

Note: Given n will be between 1 and 9 inclusive.

Hide Company Tags Twitter
Hide Tags Backtracking Math
Hide Similar Problems (M) Next Permutation (M) Permutations
*/


//Author: new2500




#region Backtracking O(N) time

/*

Say n = 4, you have {1, 2, 3, 4}

List of all Permutation:

1 + (Permutation of 2,3,4) => 6 possible 3!
2 + (Permutation of 1,3,4) => 6 possible 3!
3 + (Permutation of 1,2,4) => 6 possible 3!
4 + (Permutation of 1,2,3) => 6 possible 3!


...Continue Jump into the case where k point at, then jump into again.



*/



#end


#region DP  O(N + N) time,  Space O(N + N)

	public string GetPermutation(int n, int k)
	{
		if(n <= 0)
			return string.Empty;
		
		int[] dp = new int[n];
		FillDp(dp);
		
		StringBuilder res = new StringBuilder();
		List<int> candidates = Enumerable.Range(1, n).ToList();
		
		for(int i = 1; i <= n; i++)
		{
			int index = (k - 1)/dp[n - i];
			k = k - (index * dp[n - 1]);
			res.Append(candidates[index]);
			candidates.RemoveAt(index);
		}
		return res.ToString();
	}
	
	private void FillDP(int[] dp)
	{
		dp[0] = 1;
		/*
		   dp[1] = 1 * dp[0]
		   dp[2] = 2 * dp[1]
		   dp[n] = n * dp[n-1] 
		*/
		for(int i = 1; i < dp.Length; i++)
		{
			dp[i] = i * dp[i - 1];  
		}
	}

#end