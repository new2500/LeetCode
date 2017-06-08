/*
23. Merge k Sorted Lists

Total Accepted: 146503
Total Submissions: 546540
Difficulty: Hard
Contributor: LeetCode

Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.

Hide Company Tags LinkedIn Google Uber Airbnb Facebook Twitter Amazon Microsoft
Hide Tags Divide and Conquer Linked List Heap
Hide Similar Problems (E) Merge Two Sorted Lists (M) Ugly Number II
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
 #region MinHeap
 //1. Using MinHeap, since C# doesn't have bulit-in PQ, got to implemented our own MinHeap class
 //Time: say total # of node is N, then it's a O(N*logK). Add take logK time.
 public ListNode MergeKLists(ListNode[] lists)
 {
	 MinHeap heap = new MinHeap();
	 
	 foreach(var node in lists)      //Add lists into Heap
	 {
		 if(node == null) continue;
		 
		 heap.Add(node.val, node);
	 }
	 
	 ListNode curr = null, newHead = null;   //Two Pointers
	 
	 while(heap.map.Count > 0)
	 {
		 ListNode node = heap.PopMin();
		 
		 if(node.next != null) //Push next node into minHeap 
		 {
			 heap.Add(node.next.val, node.next);
		 }
		 
		 if(curr == null)  //1st element
		 {
			 curr = node;
			 newHead = curr;
		 }
		 else             //Append
		 {
			 curr.next = node;
			 curr = curr.next;
		 }
	 }
	 return newHead;
 }

 
 public class MinHeap
 {
	 public SortedDictionary<int, Queue<ListNode>> map = new SortedDictionary<int, Queue<ListNode>>();
	 
	 public void Add(int val, ListNode node)
	 {
		 if(!map.ContainsKey(val))
		 {
			 map.Add(val, new Queue<ListNode>());
		 }
		 map[val].Enqueue(node);
	 }
	 
	 public ListNode PopMin()
	 {
		 int minKey = map.First().Key;
		 ListNode node = map[minKey].Dequeue();
		 
		 if(map[minKey].Count == 0)
			 map.Remove(minKey);
		 return node;
	 }
 }

  #endregion

 
 #region Slow MergeTwoLists for picky interviewer ask for just using List data structure
 //Method 2: If asked not using Another Data Structure. Use the idea of MergeTwoLists
 //Time: Merging keep going, the Length of a list could grow to as large as n*k, and merge two sorted list will be called n-1 times. Thus it's O(nk*(n-1)) = > O(n^2*k) n is average length of a LinkedList => O(N*(N/k)-1) comparing Method 1's O(N* logK)
      public ListNode MergeKLists(ListNode[] lists)
        {
            if(lists.Length == 0)              //No need to check null since array is not nullable type in C#
                return null;
            int Count = lists.Length;

            while (Count > 1)
            {
                for (int i = 0; i < Count / 2; i++)
                {
                    lists[i] = MergeTwoLists(lists[i], lists[Count - 1 - i]);
                }
                Count = (Count + 1) / 2;
            }
            return lists[0];
        }
        //Fast way, or try using MergeTwoLists's solution
        private ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            if (l1.val <= l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }
 
 #endregion
 
 
