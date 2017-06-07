/*
21. Merge Two Sorted Lists

Total Accepted: 220790
Total Submissions: 569432
Difficulty: Easy
Contributor: LeetCode
Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.

Company Tags Amazon LinkedIn Apple Microsoft
Tags Linked List
Similar Problems (H) Merge k Sorted Lists (E) Merge Sorted Array (M) Sort List (M) Shortest Word Distance II
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
 //O(N) time, Straightforward way
 public ListNode MergeTwoSortedList(ListNode l1, ListNode l2)
 {
	 ListNode head = new ListNode(0);
	 ListNode start = head;
	 
	 while(l1 != null && l2 != null)
	 {
		 if(l1.val < l2.val)
		 {
			 start.next = l1;
			 l1 = l1.next;
		 }
		 else
		 {
			 start.next = l2;
			 l2 = l2.next;
		 }
	 }
	 
	 if(l1 != null)  start.next = l1;
	 if(l2 != null)  start.next = l2;
	 
	 return head.next;
 }
