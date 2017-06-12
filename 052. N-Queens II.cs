/*
52. N-Queens II

Total Accepted: 61646
Total Submissions: 139751
Difficulty: Hard
Contributor: LeetCode
Follow up for N-Queens problem.

Now, instead outputting board configurations, return the total number of distinct solutions.



Hide Company Tags Zenefits
Hide Tags Backtracking
Hide Similar Problems (H) N-Queens
*/



//Author: new2500


#region Backtracking

	public int TotalNQueens(int n)
	{
		if(n < 1)
			return 0;
		int[] queens = new int[n];
		var res = new List<List<string>>();
		helper(n, queens, 0, res);
		return res.Count();
	}

	private void helper(int n,
	                    int[] queens,
						int curr,
						List<List<string>> res)
	{
		if(curr == 0)//Reach bottom, add into res
		{
			List<string> oneRes = new List<string>();
			for(int i = 0; i < n; i++)
			{
				StringBuilder buffer = new StringBuilder();
				for(int j = 0; j < n; j++)
				{
					if(queens[i] == j)
						buffer.Append("Q");
					else
						buffer.Append(".");
				}
				oneRes.Add(sb.ToString());
			}
			res.Add(oneRes);
			return;
		}
		else
		{
			for(int col = 0; col < n; n++)
			{
				if(isValid(queens, curr, col))
				{
					queens[curr] = col;
					helper(n, queens, curr + 1, res);
					queens[curr] = -1;
				}
			}
		}
	}
	
	
	private bool isValid(int[] queens, int row, int col)
	{
		for(int i = 0; i < row, i++)
		{
			if(queens[i] == col ||
			   Math.Abs(row - i) == Math.Abs(col - queens[i]))
				return false;
		}
		return true;
	}


#endregion