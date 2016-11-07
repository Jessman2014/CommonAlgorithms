using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class ShortestPath
    {
        // A utility function to find the vertex with minimum distance value,
        // from the set of vertices not yet included in shortest path tree
        const int V = 9;
        int minDistance(int[] dist, bool[] sptSet)
        {
            // Initialize min value
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        // A utility function to print the constructed distance array
        void printSolution(int[] dist)
        {
            Console.WriteLine("Vertex   Distance from Source");
            for (int i = 0; i < V; i++)
                Console.WriteLine(i + " \t\t " + dist[i]);
        }

        // Funtion that implements Dijkstra's single source shortest path
        // algorithm for a graph represented using adjacency matrix
        // representation
        void dijkstra(int[][] graph, int src)
        {
            bool[] sptSet = new bool[V];
            sptSet[src] = true;
            int[] dist = new int[V];
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[src] = 0;

            bool finished = false;
            while (!finished)
            {
                int srcDst = dist[src];
                for (int i = 0; i < V; i++)
                {
                    if (i != src && !sptSet[i])
                    {
                        int newDist = graph[src][i] + srcDst;
                        if (dist[i] > 0 && graph[src][i] > 0 && newDist < dist[i])
                        {
                            dist[i] = newDist;
                        }
                    }
                }

                src = minDistance(dist, sptSet);
                sptSet[src] = true;

                //we need all elements to be traversed before we can finish
                finished = true;
                for (int i = 0; i < V; i++)
                {
                    if (sptSet[i] == false)
                        finished = false;
                }
            }
            printSolution(dist);
        }

        static void Main(string[] args)
        {
            /* Let us create the example graph discussed above */
            int[][] graph = {
                new int[] {0, 4, 0, 0, 0, 0, 0, 8, 0},
                new int[]{4, 0, 8, 0, 0, 0, 0, 11, 0},
                new int[]{0, 8, 0, 7, 0, 4, 0, 0, 2},
                new int[]{0, 0, 7, 0, 9, 14, 0, 0, 0},
                new int[]{0, 0, 0, 9, 0, 10, 0, 0, 0},
                new int[]{0, 0, 4, 14, 10, 0, 2, 0, 0},
                new int[]{0, 0, 0, 0, 0, 2, 0, 1, 6},
                new int[]{8, 11, 0, 0, 0, 0, 1, 0, 7},
                new int[]{0, 0, 2, 0, 0, 0, 6, 7, 0}
            };
            ShortestPath t = new ShortestPath();
            t.dijkstra(graph, 0);
        }
    }
}
