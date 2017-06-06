/*12. Integer to Roman

Given an integer, convert it to a roman numeral.

Input is guaranteed to be within the range from 1 to 3999.

Company: Twitter
Tag: String, Math
Similar: Roman to Integer E, Integer to English Word H
*/

//Author: new2500

public string IntToRoman(int num)
{
	string[] Millions = {"", "M", "MM","MMM"};
	string[] Hundreds = {"", "C", "CC","CCC","CD","D","DC", "DCC", "DCCC", "CM"};
	string[] Tens = {"", "X","XX","XXX","XL","L","LX","LXX","LXXX","XC"};
	string[] Ones = {"", "I","II","III","IV","V","VI","VII","VIII","IX"};
	
	return Millions[num/1000] + Hundreds[(num%1000)/100] + Tens[(num%100)/10] + Ones[num%10];
}