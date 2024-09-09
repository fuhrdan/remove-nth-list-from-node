//*****************************************************************************
//** 19. Remove Nth Node From End of List  leetcode                          **
//*****************************************************************************


/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* removeNthFromEnd(struct ListNode* head, int n) 
{
    // Create a dummy node to simplify edge cases (e.g., removing the first node)
    struct ListNode* dummy = (struct ListNode*)malloc(sizeof(struct ListNode));
    dummy->next = head;
    
    struct ListNode* fast = dummy;
    struct ListNode* slow = dummy;

    // Move the fast pointer n+1 steps ahead to create a gap between fast and slow
    for(int i = 0; i <= n; ++i) 
    {
        fast = fast->next;
    }

    // Move both pointers until fast reaches the end
    while(fast != NULL) 
    {
        fast = fast->next;
        slow = slow->next;
    }

    // Remove the nth node
    struct ListNode* toDelete = slow->next;
    slow->next = slow->next->next;
    
    // Free the memory of the node to be deleted
    free(toDelete);

    // Return the head of the modified list
    struct ListNode* result = dummy->next;
    free(dummy); // Free the dummy node

    return result;
}