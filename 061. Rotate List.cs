/*
61. Rotate List
 
Total Accepted: 106627 Total Submissions: 439043 Difficulty: Medium
Contributor: LeetCode
Given a list, rotate the list to the right by k places, where k is non-negative.

For example:
Given 1->2->3->4->5->NULL and k = 2,
return 4->5->1->2->3->NULL.

Hide Tags Linked List Two Pointers
Hide Similar Problems (E) Rotate Array
*/

//Author:new2500

	public ListNode RotateRight(ListNode head, int k)
	{
		if(head == null)
			return null;
		ListNode start = head;
		int length = 1;
		
		while(start != null && start.next != null)
		{
			start = start.next;
			length++;
		}
		
		start.next = head;
		
		length = length - (k % length);
		while(length > 0)
		{
			start = start.next;
			length--;
		}
		
		head = start.next;
		start.next = null;
		
		return head;
	}
