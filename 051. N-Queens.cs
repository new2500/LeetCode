/*
51. N-Queens

Total Accepted: 77739
Total Submissions: 256754
Difficulty: Hard
Contributor: LeetCode
The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.



Given an integer n, return all distinct solutions to the n-queens puzzle.

Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space respectively.

For example,
There exist two distinct solutions to the 4-queens puzzle:

[
 [".Q..",  // Solution 1
  "...Q",
  "Q...",
  "..Q."],

 ["..Q.",  // Solution 2
  "Q...",
  "...Q",
  ".Q.."]
]
Hide Tags Backtracking
Hide Similar Problems (H) N-Queens II
*/




//Author: new2500



#region Backtracking

	public List<List<string>> SolveNQueen(int n)
	{
		var res = new List<List<string>>();
		//We have N Queens
		Tuple<int,int>[] positions = new Tuple<int,int>[n];
		helper(0, positions, res, n);
		return res;
	}

	private void helper(int curr,
	                   Tuple<int,int>[] positions,
					   List<List<string>> res,
					   int n)
	{
		if(curr == n)//Found N queens
		{
			StringBuilder buff = new StringBuilder();
			List<string> oneRes = new List<string>();
			foreach(var p in positions)
			{
				for(int i = 0; i < n; i++)
				{
					if(p.Item2 == i)
						buff.Append("Q");
					else
						buff.Append(".");
				}
				oneRes.Add(buff.ToString());
				buff = new StringBuilder();   //Reset for next solution
			}
			res.Add(oneRes);
			return;
		}
		else //DFS
		{
			for(int j = 0; j < n; j++)
			{
				bool foudSafe = true;
				for(int i = 0; i < curr; i++)
				{
					if(positions[i].Item2 == j ||       //Same Col
					   positions[i].Item2 - positions[i].Item1 == j - curr ||    //Anti-Diag
					   positions[i].Item1 + positions[i].Item2 == j + curr)      //Diag
						foudSafe = false;
					break;  
				}
				if(foudSafe)
				{
					positions[curr] = new Tuple<int,int>(curr, j);
					helper(curr + 1, positions, res, n);
				}
			}
		}
	}				   


#endregion