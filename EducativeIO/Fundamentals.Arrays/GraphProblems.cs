using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals
{
    public class GraphProblems
    {
        public static int FindNumberOfComponents(int n, int[][] edges)
        {
            var e = edges.Length;
            var adjacencyList = new Dictionary<int, List<int>>();
            for(int i = 0; i<n; i++)
            {
                adjacencyList.Add(i, new List<int>());
            }

            for(int i = 0; i< e; i++)
            {
                var edge1 = edges[i][0];
                var edge2 = edges[i][1];
                adjacencyList.GetValueOrDefault(edge1).Add(edge2);
                adjacencyList.GetValueOrDefault(edge2).Add(edge1);
            }

            var visited = new bool[n];
            var count = 0;

            for(int i = 0; i< n; i++)
            {
                if(!visited[i])
                {
                    count++;
                    DFS_FindNumberOfComponents(adjacencyList, i, visited);
                }
            }

            return count;
        }

        private static void DFS_FindNumberOfComponents(Dictionary<int, List<int>> adjacencyList, int index, bool[] visited)
        {
            visited[index] = true;

            var edges = adjacencyList.GetValueOrDefault(index);
            foreach (var item in edges)
            {
                if(visited[item] == false)
                {
                    DFS_FindNumberOfComponents(adjacencyList, item, visited);
                }
            }
        }

        /// <summary>
        /// to Take course preRequisites[0][0], you have to have taken preRequisite[0][1] and so on
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="preRequisites"></param>
        /// <returns></returns>
        public static bool CanFinishCourses(int numCourses, int[][] preRequisites)
        {
            if (preRequisites == null || numCourses == 0 || preRequisites.Length == 0) return true;

            //setup a list of courses with empty edges or relations
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for(int i = 0; i<numCourses; i++)
            {
                map.TryAdd(i, new List<int>());
            }
            //each course has a preRequisite, add it to the list
            foreach(var item in preRequisites)
            {
                map.GetValueOrDefault(item[1]).Add(item[0]);
            }

            //create a visited array where 0 = unvisited, -1 = visiting, 1 = visisted
            var visited = new int[numCourses];
            for(int i = 0; i<numCourses; i++)
            {
                if (!DFS_CanFinishCourses(map, visited, i))
                    return false;
            }

            return true;
        }

        private static bool DFS_CanFinishCourses(Dictionary<int, List<int>> map, int[] visited, int i)
        {
            //we're in a current iteration or exploration
            if (visited[i] == -1) return false;

            //we've visited, just continue
            if (visited[i] == 1)
                return true;

            //set current node as visiting
            visited[i] = -1;

            if(map.ContainsKey(i))
            {
                foreach(var item in map.GetValueOrDefault(i))
                {
                    if (!DFS_CanFinishCourses(map, visited, item))
                        return false;
                }
            }

            visited[i] = 1;

            return true;
        }
    }
}
