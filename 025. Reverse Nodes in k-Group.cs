/*
25. Reverse Nodes in k-Group

Total Accepted: 91982
Total Submissions: 302691
Difficulty: Hard
Contributor: LeetCode
Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.

k is a positive integer and is less than or equal to the length of the linked list. If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.

You may not alter the values in the nodes, only nodes itself may be changed.

Only constant memory is allowed.

For example,
Given this linked list: 1->2->3->4->5

For k = 2, you should return: 2->1->4->3->5

For k = 3, you should return: 3->2->1->4->5

Hide Company Tags Microsoft Facebook
Hide Tags Linked List
Hide Similar Problems (M) Swap Nodes in Pairs
*/

//Author: new2500

public ListNode ReverNodeInKGroup(ListNode head, int k)
{
	//Find the length of linkedlist
	int Length = 0;
	for(ListNode i = head; i!= null; Length++, i = i.next);
	
	ListNode dummy = new ListNode(0);
	dummy.next = head;
	
	for(var prev = dummy, curr = head; Length >= k; Length = Length - k)
	{
           /*say k = 3,  1->2->3->4->5   ---> prev = 0, first = 1, tail = 1,  

                0 -> 1 -> 2 -> 3 -> 4 -> 5
                |    |    |    |   
               pre  curr next  tmp
                  
                0 -> 2 -> 1 -> 3 -> 4 -> 5
                |         |    |    |        
               pre       curr next tmp
                  
                0 -> 3 -> 2 -> 1 -> 4 -> 5
                |              |    |    | 
               pre           cur  nex  tmp
                  
          More verbose logical part. 
                var next = curr.next;
                for (int i = 1; i < k; i++)     
                {
                    var temp = next.next;
                    next.next = prev.next;
                    prev.next = next;
                    curr.next = temp;
                    next = temp;
                }*/
		for(int i = 1; i < k; i++)   
		{
			var next = curr.next.next;     
			curr.next.next = prev.next;
			prev.next = curr.next;
			curr.next = next;
		}
		
		prev = curr;
		curr = curr.next;
	}
	retur dummy.next;
}
