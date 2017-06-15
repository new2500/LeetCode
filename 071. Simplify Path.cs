/*
71. Simplify Path
 
Total Accepted: 85015
Total Submissions: 341631
Difficulty: Medium
Contributor: LeetCode
Given an absolute path for a file (Unix-style), simplify it.

For example,
path = "/home/", => "/home"
path = "/a/./b/../../c/", => "/c"
click to show corner cases.

Corner Cases:
	Did you consider the case where path = "/../"?
In this case, you should return "/".
	Another corner case is the path might contain multiple slashes '/' together, such as "/home//foo/".
In this case, you should ignore redundant slashes and return "/home/foo".

Hide Company Tags Microsoft Facebook
Hide Tags Stack String
*/

//Author:new2500


#region
//If Equals to '.', do nothing
//If Equals to '..', Pop item from stack
//Otherwise push item into stack
//Put a conditional operator on Return statement, Avoiding the double "//" case	

	public string SimplifyPath(string path)
	{
		Stack<string> stack = new Stack<string>();
		
		string[] tokens = path.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
		
		foreach(string token in tokens)
		{
			if(token.Equals(".")
				continue;
			//Corner case: token == ".."
			if(token.Equals("..")
			{
				if(stack.Count > 0)
					stack.Pop();
			}
			else
			{
				stack.Push(token);
			}
		}
		
		return stack.Any() ? "/" + stack.Aggregate((current, str) => str + "/" + curr) 
		                   : "/";
	}