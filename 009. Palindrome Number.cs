/*9. Palindrome Number

Determine whether an integer is a palindrome. Do this without extra space.

Tags: Math
Similar Problem: Palindrome LinkedList EqualityComparer
*/


//Author: new2500

//say N is length of x, then this is a O(logN) algo.

public bool IsPalindrome(int x)
{
	//1. Negative number  2.XX0 cases
	if(x < 0 || (x != 0 && x%10 == 0))
		return false;
	int rev = 0;
	while(x > rev)
	{
		rev = rev * 10 + x % 10;
		x = x/10;
	}
	// x==rev: even case;  x == rev/10 case:
	return (x == rev || x == rev/10);
}
