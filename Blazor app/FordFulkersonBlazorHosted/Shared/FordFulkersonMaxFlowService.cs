using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordFulkersonBlazor.Shared
{
    public class FordFulkersonMaxFlowService
    {

        static bool bfs(int[,] rGraph, int s, int t, int[] parent)
        {
            int length = rGraph.GetLength(0);
            bool[] visited = new bool[length];
            for (int i = 0; i < length; ++i)
                visited[i] = false;
            List<int> queue = new List<int>();
            queue.Add(s);
            visited[s] = true;
            parent[s] = -1;

            while (queue.Count != 0)
            {
                int u = queue[0];
                queue.RemoveAt(0);

                for (int v = 0; v < length; v++)
                {
                    if (visited[v] == false
                        && rGraph[u, v] > 0)
                    {
                        if (v == t)
                        {
                            parent[v] = u;
                            return true;
                        }
                        queue.Add(v);
                        parent[v] = u;
                        visited[v] = true;
                    }
                }
            }

            return false;
        }

        public static int fordFulkerson(int[,] graph, int s, int t)
        {
            int length = graph.GetLength(0);
            int u, v;

            int[,] rGraph = new int[length, length];

            for (u = 0; u < length; u++)
                for (v = 0; v < length; v++)
                    rGraph[u, v] = graph[u, v];

            int[] parent = new int[length];

            int maxFlow = 0;

            while (bfs(rGraph, s, t, parent))
            {
                int pathFlow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    pathFlow
                        = Math.Min(pathFlow, rGraph[u, v]);
                }

                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= pathFlow;
                    rGraph[v, u] += pathFlow;
                }

                maxFlow += pathFlow;
            }

            return maxFlow;
        }
    }
}
