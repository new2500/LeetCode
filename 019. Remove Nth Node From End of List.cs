/*
19. Remove Nth Node From End of List

Total Accepted: 174940
Total Submissions: 530137
Difficulty: Medium
Contributor: LeetCode
Given a linked list, remove the nth node from the end of list and return its head.

For example,

   Given linked list: 1->2->3->4->5, and n = 2.

   After removing the second node from the end, the linked list becomes 1->2->3->5.
Note:
Given n will always be valid.
Try to do this in one pass.
*/

//Author: new2500


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
 
 //Runner-Walker Method O(N) time
 public ListNode RemoveNthFromEnd(ListNode head, int n)
 {
	 ListNode start = head;    //Dummy node before head
	 start.next = head;
	 ListNode slow = start;
	 ListNode fast = start;
	 
	 //Runner move n+1 step first
	 for(int i = 0; i <= n; i++)    //Could consider a while-loop to including fast != null for invalid cases
		 fast = fast.next;
	
    while(fast != null)
	{
		slow = slow.next;
		fast = fast.next;
	}
	
	//Skip the desired ndoe, Now slow is at the node before deleted node
	slow.next = slow.next.next;

    return start.next;	
 }