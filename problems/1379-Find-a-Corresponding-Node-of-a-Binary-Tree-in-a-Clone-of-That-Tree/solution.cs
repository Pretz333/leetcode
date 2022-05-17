/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
        // To solve this problem, we're going to implement a depth-first search using recursive 
        // calls to the function. This is an O(n) solution, as it looks at each node once.
        
        // This is to be lazy of our implementation of the recursive calls later. Note that the problem
        // specifies that its call of the function will never provide a null original or cloned, which
        // means that this statement will only ever return to our calls, not to the original source
        // call. This means that returning null here is not actually declaring our answer as 
        // null, but rather to inform the calling code that we've hit the bottom of the tree.
        if(original == null) return null;
        
        // If this node is the target, return the cloned version of it (as is our goal).
        // This call will only return to the call directly to it, meaning that this
        // won't return to the source call unless the original TreeNode is the target.
        if(original == target) return cloned;
        
        // If this node wasn't the proper node, test its left node. If it doesn't exist, the
        // check above for a null node will catch it for us and will return null. If it is not
        // the correct node, it will end up calling its children nodes using this same call.
        TreeNode left = GetTargetCopy(original.left, cloned.left, target);
        
        // If the left node was the correct node, return it to whatever called it. Note that if
        // we hit the bottom of the tree, it will simply return null and we will skip this line.
        if(left != null) return left;
        
        // Same as above, but for the right side.
        TreeNode right = GetTargetCopy(original.right, cloned.right, target);
        
        // Same as above, but for the right side.
        if(right != null) return right;
        
        // If this node was not the correct node, and neither of its children (or their children)
        // were the correct node, return null. This will tell the calling code that we hit the
        // bottom of this branch.
        return null;
    }
}