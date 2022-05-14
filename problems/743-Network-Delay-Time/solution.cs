public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        // Create a HashMap to store edges; essentially which nodes are connected to what other nodes.
        // It is using an int as the key, which will be the source node. The List will contain what
        // nodes connect to it and how much time it takes to get to each one.
        Dictionary<int, List<int[]>> edges = new Dictionary<int, List<int[]>>();

        // Create a List which will be used to work with all of the neighbors of a specific node.
        // The first int will be the neighbor of the node we're looking at and the second will be the time to go there.
        List<int[]> neighbors;
        
        // Unpack the times array by grabbing the ith element and adding its destination node and time
        // to reach it to the HashMap. 
        foreach(int[] connection in times) { // O(n)
            // If there is not already a list for that node, make one.
            if(!edges.ContainsKey(connection[0])) {
                edges.Add(connection[0], new List<int[]>());
            }
            
            // Get the list. TryGetValue will never fail unless something is seriously wrong (the program 
            // failed to compile properly), as we are making the list directly above this.
            edges.TryGetValue(connection[0], out neighbors);

            // Add this new destination node and how long it took to reach it to the List.
            neighbors.Add(new int[]{connection[1], connection[2]});
        }
        
        // Create a PriorityQueue, which is a data structure that stores items associated with a priority value.
        // We'll be using it to keep track of what the longest path is as we go along.
        // The first int will be the destination node and the second int will be the time to go there.
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        // Add how long it took to get to the source node
        minHeap.Enqueue(k, 0);

        // Set up a HashSet, a fast way of storing unique values. This HashSet will store what 
        // nodes we've visited. Adding or checking if something is inside is an O(1) operation.
        HashSet<int> nodesVisited = new HashSet<int>();

        // time will be used to keep track of how far we are from the source node as we iterate through the connections.
        int time = 0;
        int nodeTime, destNode;
        
        // Loop until we've run out of paths to check
        while(minHeap.Count > 0) {
            // Get the fastest path out of the queue for comparison.
            minHeap.TryDequeue(out destNode, out nodeTime);
            
            // If we have already looked at where this node goes, don't check again. 
            if(!nodesVisited.Add(destNode)) {
                continue;
            }
            
            // If the new node is further than the furthest we've gone, update how long it takes to get to the furthest node.
            time = Math.Max(time, nodeTime);
            
            // Get the list of connections for this node
            edges.TryGetValue(destNode, out neighbors);

            // Check all of its neighbors, if there are any.
            if(neighbors != null) {
                foreach(int[] neighbor in neighbors) {
                    // If we haven't already assessed that neighbor, add the connection between the two to the minHeap
                    if(!nodesVisited.Contains(neighbor[0])) {
                        minHeap.Enqueue(neighbor[0], neighbor[1] + nodeTime);
                    }
                }
            }
        }
        
        // If we were able to visit all of the nodes, give the time it would take for the message to broadcast.
        // Otherwise, return -1 since it is not possible to visit all of the nodes.
        return nodesVisited.Count == n ? time : -1;
    }
}