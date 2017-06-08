/*
24. Swap Nodes in Pairs

Total Accepted: 160905
Total Submissions: 423915
Difficulty: Medium
Contributor: LeetCode


Given a linked list, swap every two adjacent nodes and return its head.

For example,
Given 1->2->3->4, you should return the list as 2->1->4->3.

Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.

Hide Company Tags Microsoft Bloomberg Uber
Hide Tags Linked List
Hide Similar Problems (H) Reverse Nodes in k-Group

*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
 
 //Author: ne2500
 //In-place Swap, 
 public ListNode SwapPair(ListNode head)
 {
	 var dummy = new ListNode(0);
	 dummy.next = head;
	 var curr = dummy;
	 
	 
	 //   curr - first - second - second.next
	 while(curr != null && curr.next.next != null)
	 {
		 var first = curr.next;
		 var second = curr.next.next;
		 
		 first.next = second.next;      //   curr -> first -> second.next <- second
		 curr.next = second;            //   curr -> second -> original second.next <-  first
		 curr.next.next = first;        //   curr -> second -> first -> original second.next
		 
		 curr = curr.next.next;   //Jump 2 node,  curr becomes original second.next
	 }
	 return dummy.next;
 }