/*
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8

*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
// Author: new2500 @ GitHub 
 //Dummy head node methods
 public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
 {
	 ListNode c1 = l1;
	 ListNode c2 = l2;
	 ListNode dummy = new ListNode(0);
	 ListNode d = dummy;
	 
	 int sum = 0;
	 while(c1 != null || c2 != null)
	 {
		 sum = sum/10; //move 1 digits forward
		 if(c1 != null)
		 {
			 sum = sum + c1.val;
			 c1 = c1.next;
		 }
		 if(c2 != null)
		 {
			 sum = sum + c2.val;
			 c2 = c2.next;
		 }
		 d.next = new ListNode(sum%10);
		 d = d.next;
	 }
	 if(sum/10 == 1)              //handling case if last node > 10
		 d.next = new ListNode(1);
	 
	 return dummy.next;

 }