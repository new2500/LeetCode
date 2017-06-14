/*
65. Valid Number
 
Total Accepted: 66880
Total Submissions: 526437
Difficulty: Hard
Contributor: LeetCode
Validate if a given string is numeric.

Some examples:
"0" => true
" 0.1 " => true
"abc" => false
"1 a" => false
"2e10" => true
Note: It is intended for the problem statement to be ambiguous. You should gather all requirements up front before implementing one.

Update (2015-02-10):
The signature of the C++ function had been updated. If you still see your function signature accepts a const char * argument, please click the reload button  to reset your code definition.

Hide Company Tags LinkedIn
Hide Tags Math String
Hide Similar Problems (M) String to Integer (atoi)
*/


//Author: new2500


#region Staightforward solution. Most reasonable solution when in interview
/*Flags Rules:
 1. if we see [0-9], we reset the number flag
 2. can only see '.'' if we didn't see e or more .
 3. can only see 'e' if we didn't more 'e' and '.'' if we see a number, reset numberAfterE flag
 4. can only see + and - in the beginning and after an 'e'.
 5. any other char break the validation
 Basilly is the regualr experssion:
 [-+]? (([0-9] + (.[0-9]*)?)|.[0-9]+)(e[-+]?[0-9]+)?
*/
	public bool ValidNumber(string s)
	{
		s = s.Trim();
		
		bool floatSeen = false;
		bool eSeen = false;
		bool numberSeen = false;
		bool numberAfterE = true;
		
		for(int i = 0; i < s.Length; i++)
		{
			if('0' <= s[i] && s[i] <= 9) //Meet numeric value, set flags
			{
				numberSeen = true;
				numberAfterE = true;
			}
			else if(s[i] == '.')
			{
				if(eSeen || floatSeen)  //Return false since meet E and floating before
				{
					return false;
				}
				
				floatSeen = true;
			}
			else if(s[i] == 'e')
			{
				if(eSeen || !numberSeen)
				{
					return false;
				}
				numberAfterE = false;
				eSeen = true;
			}
			else if(s[i] == '-' || s[i] == '+')
			{
				if(i != 0 && s[i-1] != 'e')
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
		return numberSeen && numberAfterE;
	}
	#end