public class Solution {
    // For another example of the same problem, see the original solution. This was made 
    // as I didn't like the score I received on the first solution, so I made a new one.

    // We're still going to implement Tarjan's Algorithm, which has a time complexity of O(connections + nodes).
    // Due to the fact that it uses a depth-first search (DFS), we're going to implement a recursive solution.
    // Originally, I took the lazy (and easier to debug, in my opinion) approach of making the variables class-wide
    // and the searching function a separate function of the class. This caused a hit to the memory, so this time, 
    // I embedded the DPS function into this function. This makes it less easy to read (in my opinion), but is less
    // memory intensive.
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
        // Same as before, make a result and a graph.
        IList<IList<int>> result = new List<IList<int>>();
        List<List<int>> graph = new List<List<int>>();

        // Add each node to the graph and make a list for each node
        for(int i=0; i<n; i++) {
            graph.Add(new List<int>());
        }

        // Add every node's neighbors to the graph. Taking the first example, this will 
        // allow us to see that node 1 is connected to nodes 0, 2, and 3 (but is unsorted).
        foreach(IList<int> connection in connections) {
            graph[connection[0]].Add(connection[1]);
            graph[connection[1]].Add(connection[0]);
        }

        // Make the arrays we need, they serve the same purpose as before.
        // I renamed "discovered" to "visited" as I think "-1" as a result is more clear with that name.
        int[] visited = new int[n]; // Named "discovered" in the original solution
        int[] parent = new int[n]; // This will be used to track which node we came from when traversing.
        int[] low = new int[n]; // Same as before

        // Fill all of the arrays with -1 to indicate that we haven't visited them yet.
        Array.Fill(visited, -1);
        Array.Fill(parent, -1);
        Array.Fill(low, -1);

        // We still need the time, so we'll make that now.
        int time = 0;

        // Traverse the graph. This will start at node 0, wherever it is, and do the following:
        // 1. Mark this node as visited
        // 2. Look at all of its connections
        // 3. Visit each connection, starting from step 1 again
        // When the first node has run through all of its connections (and their connections, and their
        // connections, etc.), we come back and check if any nodes haven't been visited and start from the top.
        // You'll notice we no longer pass in the parent to DFS, as we track that in the array above.
        for(int i=0; i<n; i++) {
            if(visited[i] == -1) DFS(i);
        }

        // Return our result, which is filled in the DFS section.
        return result;

        void DFS(int node) {
            // Increment the time counter to show that we've looked at something new
            time++;

            // Mark when the node was discovered, now in one line! Yes, it's less readable.
            visited[node] = low[node] = time;

            // Check the node's neighbors
            foreach(int neighbor in graph[node]) {
                // If we've already visited the neighbor or the neighbor is the parent, skip checking it
                if(visited[neighbor] != -1 && neighbor == parent[node]){
                    continue;
                }

                // If we haven't visited the neighbor:
                parent[neighbor] = n; // Set the parent to be the node we came from
                DFS(neighbor); // Look at its neighbors

                // Check if the neighbor can get closer to the source than this node can. 
                // If so, set this node to be able to reach the closest node the neighbor can.
                low[node] = Math.Min(low[node], low[neighbor]);

                // If the neighbor can reach the source of our search before we can get to this
                // node, the connection between node and neighbor is the "critical connection".
                if(low[neighbor] > visited[node]) {
                    result.Add(new List<int>{node, neighbor});
                }
            }
        }
    }
}