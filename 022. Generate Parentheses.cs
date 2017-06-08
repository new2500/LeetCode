/*
22. Generate Parentheses

Total Accepted: 143987
Total Submissions: 328331
Difficulty: Medium
Contributor: LeetCode
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

For example, given n = 3, a solution set is:

[
  "((()))",
  "(()())",
  "(())()",
  "()(())",
  "()()()"
]
Hide Company Tags Google Uber Zenefits
Hide Tags Backtracking String
Hide Similar Problems (M) Letter Combinations of a Phone Number (E) Valid Parentheses
*/


//Author: new2500

//DFS + Backtracking
public List<string> GenerateParentheses(int n)
{
	var res = new List<string>();
	
	DFS(n, 1, 0, new StringBuilder("("), res);   //Manually push a '('
	return res;
}

private void DFS(int n, int left, int right, StringBuilder path, List<string> res)
{
	//exit 
	if(left > n)
		return;
	if(left == n && right == n)
	{
		res.Add(path.ToString());
		return;
	}
	
	path.Append('(');
	DFS(n, left+1, right, path, res);
	path.RemoveAt(path.Length-1, 1);  //Backtracking For Left
	
	if(left > right)
	{
		path.Append(')');
		DFS(n, left, right+1, path, res);
		path.RemoveAt(path.Length-1, 1);  //Backtracking For Right
	}
	
	
}



//Iterative DP Method
/*
Say result is F(n), and it's from previous result F(0)...F(n-1)

F(n) will be put an extra "()" pair to F(n-1).
1. Let put '(' always at the first position, to product a valid result: => We can ONLY put a ')' in a way that there will be i pairs() inside the extra "()" and n-1-i pairs"()" outside the extra pair.

2. Example:   + : String concatenation operator

f(0): ""
f(1): '('+ f(0) +')'
f(2): '('+ f(0) +')' +f(1),    '('+ f(1) +')'
f(3): '('+ f(0) +')' +f(2),    '('+ f(1) +')'+f(1),    '('+ f(2) +')'
.......
f(n): '('+ f(0) +')' +f(n-1),  '('+ f(1) +')' +f(n-2), '('+ f(2) +')'+f(n-3),.............'('+ f(i) +')' +f(n-1-i), '('+ f(n-1) +')' 

*/
//Space/Time costing and too many string concatenation, not recommend.
        public IList<string> DP(int n)
        {
            List<List<string>> resList = new List<List<string>>();
            resList.Add(new List<string>() {""});   //1st 

            for (int i = 1; i <= n; i++)
            {
                List<string> path = new List<string>();

                for (int j = 0; j < i; j++)
                {
                    foreach (string first in resList[j])
                    {
                        foreach(string second in resList[i-j-1])
                            path.Add("("+first+")"+second);
                    }
                }
                resList.Add(path);
            }
            return resList[resList.Count - 1];
        }

		
//Improve from DP solution, Using 1 Queue to tracking string, 1 Queue to tracking the # of elements, O(N^2) time,	
   public IList<string> Gen(int n)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("(");

            //0 means # of Left Brackets; 1 means # of Right Brackets
            Queue<List<int>> CountList = new Queue<List<int>>();
            CountList.Enqueue(new List<int>() {1, 0});
            

            for (int i = 1; i <= 2 * n - 1; i++) //Total 2N elements
            {
                while (queue.Peek().Length == i)
                {
                    string curr = queue.Dequeue();
                    List<int> BrackNum = CountList.Dequeue();  //Get the current # of left&right

                    if (BrackNum[0] < n) //left
                    {
                        queue.Enqueue(curr + "(");
                        CountList.Enqueue(new List<int>() {BrackNum[0]+1, BrackNum[1]});
                    }
                    if (BrackNum[0] > BrackNum[1] && BrackNum[1] < n) //right
                    {
                        queue.Enqueue(curr + ")");
                        CountList.Enqueue(new List<int>() { BrackNum[0], BrackNum[1]+1});
                    }
                }
            }
            return queue.ToList();
        }	