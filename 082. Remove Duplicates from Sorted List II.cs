/*
82. Remove Duplicates from Sorted List II
 
Total Accepted: 107212 Total Submissions: 367022 Difficulty: Medium
Contributor: LeetCode
Given a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list.

For example,
Given 1->2->3->3->4->4->5, return 1->2->5.
Given 1->1->1->2->3, return 2->3.

Hide Tags Linked List
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
 
 //Author:new2500
 
 /*
	fakeHead and prev is essential, especially prev.
 */
 
	public ListNode DeleteAllDuplicates(ListNode head)
	{
		if(head == null)
			return null;
		
		ListNode fakeHead = new ListNode(0 == head.val ? 1 : 0);
		fakeHead.next = head;
		
		ListNode prev = fakeHead;
		ListNode curr = head;
		
		while(curr != null)
		{
			//If meet duplcate, move curr forward
			while(curr.next != null && curr.val == curr.next.val)
			{
				curr = curr.next;
			}
			//Move the pre
			if(pre.next == curr)
			{
				pre = pre.next
			}
			else
			{
				pre.next = curr.next;
			}
			
			curr = curr.next;
		}
		
		return fakeHead.next;
	}
