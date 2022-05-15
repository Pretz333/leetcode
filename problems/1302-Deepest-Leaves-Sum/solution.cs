/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int DeepestLeavesSum(TreeNode root) {
        // This will be used to keep track of the sum per level
        int sum = 0;
        
        // We're going to use a queue to store what nodes we haven't looked at yet.
        // Queues are ideal for this because they are first-in, first-out, meaning that we
        // can simply enqueue each node as we find it and it will keep us on the same level.
        Queue<TreeNode> queue = new Queue<TreeNode>();

        // Add the first (source/root) node
        queue.Enqueue(root);
        
        // The while loop will loop until the entire tree has been covered.
        while(queue.Count > 0) {
            // Reset the sum, as if we are here, it means we are assessing a new level of the tree.
            // Since we only want to return the deepest level's sum, toss out the sum from the previous level.
            sum = 0;
            
            // The for loop will loop through the level. We grab the levelSize before entering the loop to 
            // ensure that we don't add the next level of nodes into out current pass through the level. 
            // For example, if we moved the queue.Count into the place of levelSize in the for loop, during
            // during our first pass through the for loop in Example 1 ([1,2,3,4,5,null,6,7,null,null,null,null,8]),
            // we add two new nodes (2 and 3) to the queue. When we hit the bottom of the loop, queue.Count is now
            // equal to two, so intead of breaking the for loop and resetting the count (as it should), it instead
            // will go through the for loop again. This will result in the incorrect return of 8 instead of 15.
            int levelSize = queue.Count;
            for(int i = 0; i < levelSize; i++) {
                // Grab the oldest item in the queue (leftmost item on the current level)
                TreeNode currentNode = queue.Dequeue();

                // Add the currentNode's value to the level sum
                sum += currentNode.val;
                
                // If the current node has children nodes, add them to the queue for the next pass.
                if(currentNode.left != null) queue.Enqueue(currentNode.left);
                if(currentNode.right != null) queue.Enqueue(currentNode.right);
            }
        }
        
        return sum;
    }
}