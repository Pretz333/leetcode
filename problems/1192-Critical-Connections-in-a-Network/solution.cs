// Does not yet work, but it's 1:20 AM and I have to go to work in the morning

public class Solution {
    private Dictionary<int, List<int>> nodes = new Dictionary<int, List<int>>();
    private int[] rank;
    
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
        rank = new int[n];
        Array.Fill<int>(rank, -2, 0, n);
        
        for(int i = 0; i <= n; i++) {
            nodes.Add(i, new List<int>());
        }
        
        foreach(IList<int> connection in connections) {
            nodes[connection[0]].Add(connection[1]);
            nodes[connection[1]].Add(connection[0]);
        }
        
        dfs(0, 0, connections);
        
        return connections;
    }
    
    private int dfs(int node, int depth, IList<IList<int>> connections) {
        if(rank[node] > 0) return rank[node]; // already visited
        rank[node] = depth;
        int minDepthFound = depth;
        foreach(int neighbor in nodes[node]) {
            if(rank[neighbor] == depth - 1) continue; // ignore its parent
            int minDepth = dfs(neighbor, depth + 1, connections);
            minDepthFound = Math.Min(minDepth, minDepthFound);
            if(minDepth <= depth) {
                Console.WriteLine("R " + node + ", " + neighbor);
                for(int i = 0; i < connections.Count; i++) {
                    if((connections[i][0] == node || connections[i][0] == neighbor) 
                       && (connections[i][1] == node || connections[i][1] == neighbor))
                        connections.RemoveAt(i);
                }
            }
        }
        
        return minDepthFound;
    }
}