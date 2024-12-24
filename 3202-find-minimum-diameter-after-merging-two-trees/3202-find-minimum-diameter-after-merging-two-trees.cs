using System.Collections.Generic;
using System;

public class Solution {
    int maxDiameter = 0; // Global variable to track the maximum diameter during traversal
    public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2) {

        // Create adjacency lists for both trees
        List<int>[] adj1 = CreateAdjList(edges1);
        List<int>[] adj2 = CreateAdjList(edges2);

        // Calculate the maximum depth and diameter of the first tree
        FindMaxDepth(adj1, 0, new HashSet<int>());
        var d1MaxDiameter = maxDiameter;
        maxDiameter = 0; // Reset maxDiameter for the second tree

        // Calculate the maximum depth and diameter of the second tree
        FindMaxDepth(adj2, 0, new HashSet<int>());
        var d2MaxDiameter = maxDiameter;

        // Compute the minimum possible diameter after merging the two trees
        var res = Math.Max(
            Math.Max(d1MaxDiameter, d2MaxDiameter), // Larger of the two diameters
            Math.Ceiling(d1MaxDiameter / 2.0) + Math.Ceiling(d2MaxDiameter / 2.0) + 1 // Combined diameter with the new edge
        );
        return (int)res;
    }

    // This method creates an adjacency list from the given edges
    private List<int>[] CreateAdjList(int[][] edges) {
        List<int>[] adjList = new List<int>[edges.Length + 1]; // Initialize adjacency list

        // Populate the adjacency list with edges
        for (var i = 0; i < edges.Length; i++) {
            if (adjList[edges[i][0]] == null)
                adjList[edges[i][0]] = new List<int>();
            adjList[edges[i][0]].Add(edges[i][1]);
            if (adjList[edges[i][1]] == null)
                adjList[edges[i][1]] = new List<int>();
            adjList[edges[i][1]].Add(edges[i][0]);
        }
        return adjList; // Return the constructed adjacency list
    }

    // This method calculates the maximum depth of a given adjacency list and updates the global maxDiameter
    private int FindMaxDepth(List<int>[] adj, int currentIndex, HashSet<int> visitedNodes) {
        // If the current node has no neighbors, return 0
        if (adj[currentIndex] == null) return 0;

        int m1 = 0; // First largest depth from the current node
        int m2 = 0; // Second largest depth from the current node
        visitedNodes.Add(currentIndex); // Mark the current node as visited

        // Traverse all adjacent nodes
        foreach (var node in adj[currentIndex]) {
            // Skip already visited nodes
            if (!visitedNodes.Contains(node)) {
                var d = 1 + FindMaxDepth(adj, node, visitedNodes); // Recursively calculate depth
                // Update the two largest depths
                if (d > m2) {
                    m1 = m2;
                    m2 = d;
                } else if (d > m1) {
                    m1 = d;
                }
            }
        }
        // Update the maximum diameter using the two largest depths
        maxDiameter = Math.Max(maxDiameter, m1 + m2);
        return Math.Max(m1, m2); // Return the largest depth from the current node
    }
}