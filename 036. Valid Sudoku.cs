/*
36. Valid Sudoku

Total Accepted: 116980
Total Submissions: 333220
Difficulty: Medium
Contributor: LeetCode
Determine if a Sudoku is valid, according to: Sudoku Puzzles - The Rules.

The Sudoku board could be partially filled, where empty cells are filled with the character '.'.

Sudoku board Link: https://upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Sudoku-by-L2G-20050714.svg/250px-Sudoku-by-L2G-20050714.svg.png

A partially filled sudoku which is valid.

Note:
A valid Sudoku board (partially filled) is not necessarily solvable. Only the filled cells need to be validated.

Hide Company Tags Snapchat Uber Apple
Hide Tags Hash Table
Hide Similar Problems (H) Sudoku Solver
*/


//Author: new2500

/* Idea:
* 1. Use % hor horizontal traversal, because % increament by 1 for each j : 0%3 = 0, 1%3 = 1, 2%3 = 2, and reset back. So this covers horizontal for each block by 3 steps.
* 2. Use / for vertical traversal, Because / increment by 1 after every 3 j: 0/3 =0,1/3=0,2/3=0,3/3=1. 
* 3. So far, for a given block, you can traverse the whole block using just j.

  But because j is just 0 to 9, it will stay only first block. But to increment block, use i. To move horizontally to next block, use % again : ColIndex = 3 * i%3 (Multiply by 3 so that the next block is after 3 columns. Ie 0,0 is start of first block, second block is 0,3 (not 0,1);

*/


public bool isValidSudoku(char[,] board)
{
	for(int i = 0; i < 9; i++)
	{
		var rows = new HashSet<char>();
		var clos = new HashSet<char>();
		var cube = new HashSet<char>();
		
		
		for(int j = 0; j < 9; j++)
		{
			if(board[i,j] != '.' && !rows.Add(board[i,j])) //Found duplicate
				return false;
			if(board[i,j] != '.' && !cols.Add(board[i,j]) ) //Found duplicate
				return false
			
            int cubeRow = (i/3)*3 + j/3;
            int cubeCol = (i%3)*3 + j%3;
            if(board[cubeRow, cubeCol] != '.'
			  && !cube.Add(board[cubeRow, cubeCol]))
                return false;			  
		}
	}
	return true;
}