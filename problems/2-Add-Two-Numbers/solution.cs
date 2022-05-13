/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        // Since we need to return the first node, we'll need to keep track of it separately from the node we finish on
        ListNode startNode = new ListNode(0);

        // This ListNode will be the node we work with as we step through the other lists's values
        ListNode l3 = startNode;
        
        // Declare some variables for holding the values as we step along the lists
        // l1Value and l2Value are the values of the current ListNode from each list
        // carry is in case (l1Value + l2Value >= 10), since each ListNode holds a single digit
        // currentSum is the currentSum of those values
        int l1Value, l2Value, currentSum, carry = 0;
        
        // Step through the lists until we run out of values in both lists
        while(l1 != null || l2 != null)
        {
            // Grab the values of the current ListNode from each list and advance to the next value
            // If the current value is null (we reached the end of the list), set that value to 0
            if(l1 == null)
            {
                l1Value = 0;
            }
            else
            {
                l1Value = l1.val;
                l1 = l1.next;
            }

            if(l2 == null)
            {
                l2Value = 0;
            }
            else
            {
                l2Value = l2.val;
                l2 = l2.next;
            }
            
            // Add the values of the two current ListNodes and the carry, in case the last set of ListNodes had a value >= 10
            currentSum = l1Value + l2Value + carry;

            // Set the carry. We do not need to round down as int division does so automatically, as in 12/10 = 1
            carry = currentSum / 10;
            
            // Make a new ListNode and set the value to be the sum of currentSum, minus the carry
            l3.next = new ListNode(currentSum % 10);
            
            // Advance the ListNode we are building on
            l3 = l3.next;
        }
        
        if(carry > 0)
        {
            l3.next = new ListNode(1);
        }
        
        return startNode.next;
    }
}