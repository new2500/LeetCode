/*
79. Word Search
 
Total Accepted: 123549 Total Submissions: 470140 Difficulty: Medium
Contributor: LeetCode
Given a 2D board and a word, find if the word exists in the grid.

The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once.

For example,
Given board =

[
  ['A','B','C','E'],
  ['S','F','C','S'],
  ['A','D','E','E']
]
word = "ABCCED", -> returns true,
word = "SEE", -> returns true,
word = "ABCB", -> returns false.
Hide Company Tags Microsoft Bloomberg Facebook
Hide Tags Array Backtracking
Hide Similar Problems (H) Word Search II
*/


//Author:new2500




#region DFS O((mn)^2) time, O(4mn+mn) space
/*
//Space is O(4mn+mn), if the recursive call stack is taken into account; If not, it takes O(mn). 
//for each cell, we recursively call its 4 neighbour and there're mn cell in totoal + bool used take extra m*n space
//For time, we have O(mn) for each FORLOOP, then we search the whole elements again, which is O(mn), so totoal is O(m^2n^2)

For general purpose, we used a bool[,] for mask; If for simplicity(All are ASCII) and allowed modify the input, we could just use "board[row, col] ^= 256" for marking it visited.
*/

	public bool Exist(char[,] board, string word)
	{
		int maxRow = board.GetLength(0);
		int maxCol = board.GetLength(1);
		bool[,] used = new bool[maxRow, maxCol];
		
		for(int i = 0; i < maxRow; i++)
		{
			for(int j = 0; j < maxCol; j++)
			{
				if(board[i,j] == word[0])
				{
					if(isExist(board, i, j, word, 0, used);
						return true;
				}
			}
		}
		return false;
	}

	private bool isExist(char[,] baord, int row, int j, string word, int index, bool[,] used)
	{
		//Exist
		if(index == word.Length)
			return true;
		//Invalid cases
		if(row < 0 || row >= board.GetLength(0) ||
		   col < 0 || col >= baord.GetLength(1) ||
		   used[row, col])
		   return false;
		   
		if(baord[row, col] == word[index])
	    {
			used[row, col] = true;
			//Search in 4 Directions - Vertically & Horizontally
			bool res = isExist(board, row + 1, col, word, index + 1, used) ||
			           isExist(board, row - 1, col, word, index + 1, used) ||
					   isExist(board, row, col + 1, word, index + 1, used) ||
					   isExist(board, row, col + 1, word, index + 1, used);
			used[row, col] = false; //Unmask
			return res;
		}
		//Default return
		return false;
	}
#end