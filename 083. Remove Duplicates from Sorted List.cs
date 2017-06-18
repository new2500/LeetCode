/*
83. Remove Duplicates from Sorted List
 
Total Accepted: 180498
Total Submissions: 455904
Difficulty: Easy
Contributor: LeetCode
Given a sorted linked list, delete all duplicates such that each element appear only once.

For example,
Given 1->1->2, return 1->2.
Given 1->1->2->3->3, return 1->2->3.

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


	public ListNode DeleteDuplicates(ListNode head)
	{
		if(head == null || haed.next == null)
			return haed;
		
		ListNode start = head;
		
		while(start.next != null)
		{
			if(start.val == start.next.val)
				start.next = start.next.next;
			else
				start = start.next;
		}
		return head;
	}