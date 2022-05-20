public class Solution {
    // We're going to implement Tarjan's Algorithm, which has a time complexity of O(connections + nodes).
    // I learned of this algorithm and how to implement it here: https://en.wikipedia.org/wiki/Tarjan%27s_strongly_connected_components_algorithm
    // Due to the fact that it uses a depth-first search (DFS), we're going to implement a recursive solution.
    // This means we'll either need to make the variables class-wide or we'll need to pass them into every time
    // we call the method. I took the lazy (and easier to debug, in my opinion) approach of making them class-wide.

    // Used to track when we discovered and looked at the node's connections
    private int time = 0;

    // What we'll return. I spent more time trying to return a correct answer than working on the problem,
    // which I suppose is the downside of returning an interface that is being used as an object.
    private IList<IList<int>> result;

    // Use a C# HashMap to keep track of the node's connections.
    private Dictionary<int, List<int>> graph;

    // discovered will track when we've found the node by using the node's index (discovered[node]) to store the time.
    // If we haven't discovered it yet, it will be a value of -1.
    // low will track the smallest node id that the current node can be reached from.
    int[] discovered, low;

    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
        // Initialize the class-level variables.
        result = new List<IList<int>>();
        graph = new Dictionary<int, List<int>>();
        discovered = new int[n];
        low = new int[n];
        Array.Fill(discovered, -1); // This will pre-pack the array with -1 so we know we haven't visited it

        // Add each node to the graph (HashMap) and make a list for each node
        for(int i = 0; i <= n; i++) {
            graph.Add(i, new List<int>());
        }

        // Add every node's neighbors to the graph. Taking the first example, this will 
        // allow us to see that node 1 is connected to nodes 0, 2, and 3 (but is unsorted).
        foreach(IList<int> connection in connections) {
            graph[connection[0]].Add(connection[1]);
            graph[connection[1]].Add(connection[0]);
        }

        // Traverse the graph. This will start at node 0, wherever it is, and do the following:
        // 1. Mark this node as visited
        // 2. Look at all of its connections
        // 3. Visit each connection, starting from step 1 again
        // When the first node has run through all of its connections (and their connections, and their
        // connections, etc.), we come back and check if any nodes haven't been visited and start from the top.
        for(int i = 0; i < n; i++) {
            if(discovered[i] == -1) DFS(i, i);
        }

        // Return our result, which is filled in the DFS section.
        return result;
    }

    private void DFS(int node, int parent) {
        // Mark when the node was discovered
        discovered[node] = time;
        low[node] = time;

        // Increment the time counter to show that we've looked at something new
        time++;

        // Check the node's neighbors
        for(int i = 0; i < graph[node].Count; i++) {
            // Get the neighbor's node number
            int neighbor = graph[node][i];

            // If that neighbor is the node we came from (the parent), skip it
            if(neighbor == parent) continue;

            // If the neighbor has not been looked at yet, go deeper
            if(discovered[neighbor] == -1) {
                // Take a look at the neighbor
                DFS(neighbor, node);

                // Check if the neighbor can get closer to the source than this node can. 
                // If so, set this node to be able to reach the closest node the neighbor can.
                low[node] = Math.Min(low[node], low[neighbor]);

                // If the neighbor can reach the source of our search before we can get to this
                // node, the connection between node and neighbor is the "critical connection".
                if(low[neighbor] > discovered[node]) result.Add(new List<int>{node, neighbor});
            } else {
                // If the neighbor is already visited, then the connection between the node and neighbor is a back-edge in the DFS tree.
                // low stores the highestest node in the tree we can reach, so we'll want to use discovered[neighbor] here.
                low[node] = Math.Min(low[node], discovered[neighbor]);
            }
        }
    }
}