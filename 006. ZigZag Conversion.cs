/*6. ZigZag Conversion

The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"
Write the code that will take a string and make this conversion given a number of rows:

string convert(string text, int nRows);
convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR".

Tags: StringBuilder
*/

//Author: new2500
//Since We only scan once, so time is O(n); And We use extra space: the list of StringBuilder, so Space is O(n)   
public string Convert(string s, int numRows) 
{
	if(s == null || s.Length < 2 || numsRows < 2)
		return s;
	
	List<StringBuilder> list = new List<StringBuilder>();
	bool isGoingDown = true;
	int index = 0;
	
	for(int i = 0; i < numsRows; i++)    //Initialize List
	{
		list.Add(new StringBuilder());
	}
	
	
	for(int i = 0; i < s.Length; i++)
	{
		char curr = s[i];              //Point to curr char
		list[index].Append(curr);
		 
		if(isGoingDown == true)       //GoingDown
		{
			if(index == numRows -1)  //reach last rows
			{
				index = numRows - 2;
				isGoingDown = false;
			}
			else
				index++;
		}
		else
		{
			if(index == 0)         //reach top row
			{
				index++;
				isGoingDown = true;
			}
			else
				index--;
		}
	}
	
	StringBuilder res = new StringBuilder();
	foreach(var sb in list)
	{
		res.Append(sb.ToString());
	}
	return res.ToString();
}