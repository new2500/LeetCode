/*
86. Partition List
 
Total Accepted: 97686 Total Submissions: 302650 Difficulty: Medium
Contributor: LeetCode
Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.

You should preserve the original relative order of the nodes in each of the two partitions.

For example,
Given 1->4->3->2->5->2 and x = 3,
return 1->2->2->4->3->5.

Hide Tags Linked List Two Pointers
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

	public ListNode Partition(ListNode head, int v)
	{
		//Null check
		if(head == null)
			return null;
		
		ListNode leftDummy = new ListNode(0);
		ListNode rightDummy = new ListNode(0);
		ListNode left = leftDummy, right = rightDummy;
		
		while(head != null)
		{
			if(head.val < x) //If we want to include the x in left, we should replace with "<=" here
			{
				left.next = head;
				left = head;
			}
			else
			{
				right.next = head;
				right = head;
			}
			head = head.next;
		}
		
		right.next = null;
		left.next = rightDummy.next;
		
		return leftDummy.next;
	}