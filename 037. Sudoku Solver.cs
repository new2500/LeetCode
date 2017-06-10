/*
37. Sudoku Solver
DescriptionHintsSubmissionsSolutions
Total Accepted: 73004
Total Submissions: 247706
Difficulty: Hard
Contributor: LeetCode
Write a program to solve a Sudoku puzzle by filling the empty cells.

Empty cells are indicated by the character '.'.

You may assume that there will be only one unique solution.


A sudoku puzzle...
https://upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Sudoku-by-L2G-20050714.svg/250px-Sudoku-by-L2G-20050714.svg.png

...and its solution numbers marked in red.
https://upload.wikimedia.org/wikipedia/commons/thumb/3/31/Sudoku-by-L2G-20050714_solution.svg/250px-Sudoku-by-L2G-20050714_solution.svg.png

Hide Company Tags Snapchat Uber
Hide Tags Backtracking Hash Table
Hide Similar Problems (M) Valid Sudoku
*/


//Author:new2500

//Recursive backtrackign DFS
//Time is O(C^N), when C is the how many choice for a cell:9 choice, N is the blanks need to be filled
// The CanPlay improve the runtime in practice

static char[] DIGITS = new char[] {'1', '2', '3', '4', '5','6','7','8','9'};

public void SloveSudoku(char[,] board)
{
	Solve(board, 0, 0);
}

private bool Solve(char[,] board, int row, int col)
{
	//Move right until you reach the end, then reset at next row
	if(col == 9) return Solve(board,row+1, 0);
	if(row == 0) return true;
	
	//Skip existing
	if(board[row,col] != '.')
		return Solve(board, row, col+1);
	
	foreach(char d in DIGITS)
	{
		if(CanPlay(board,row,col,d))
		{
			board[row,col] = d;
			//If can slove remaining then done
			if(Solve(board, row, col+1))
				return true;
			//Bracking
			board[row,col] = '.';
		}
	}
	return false;
}

private bool CanPlay(char[,] board, int row, int col, char d)
{
	//Check column if char d exist
	for(int i = 0; i < 9; i++)
		if(board[row,i] == d)
			return false;
	
    //Check row if char d exist
    for(int i = 0; i < 9; i++)
       if(board[i, col] == d)
            return false;

    //Check cell, the row&col; start from 0,3,6
    int r0 = 3 * (row/3);
	int r1 = 3 * (row/3) + 3;
	int c0 = 3 * (col/3);
	int c1 = 3 * (col/3) + 3;
	
	for(int i = r0; i < r1; i++)
		for(int j = c0; j < c1; j++)
			if(board[i,j] == d)
				return false;
    
    //Pass all check, d can play
    return true;	
}

