using System;

public class Solution {
    public int ClosestMeetingNode(int[] edges, int node1, int node2) {
        Span<bool> occ = stackalloc bool[edges.Length];

        Span<bool> visitedFromNode1 = stackalloc bool[edges.Length];
        Span<bool> visitedFromNode2 = stackalloc bool[edges.Length];

        var currNode1 = node1;
        var currNode2 = node2;

        var foundFromNode1 = -1;
        var foundFromNode2 = -1;

        while ((currNode1 != -1 || currNode2 != -1) && (foundFromNode1 == -1 && foundFromNode2 == -1)) {

            if (currNode1 == -1 || visitedFromNode1[currNode1]) {
                currNode1 = -1;//cycle or no path
            } else {
                visitedFromNode1[currNode1] = true;

                if (visitedFromNode2[currNode1]) {
                    foundFromNode1 = currNode1;
                    currNode1 = -1;
                } else {
                    currNode1 = edges[currNode1];
                }

            }

            if (currNode2 == -1 || visitedFromNode2[currNode2]) {
                currNode2 = -1;//cycle or no path
            } else {
                visitedFromNode2[currNode2] = true;

                if (visitedFromNode1[currNode2]) {
                    foundFromNode2 = currNode2;
                    currNode2 = -1;
                } else {
                    currNode2 = edges[currNode2];
                }
            }
        }
        return foundFromNode1 == -1 ? foundFromNode2 : foundFromNode2 == -1 ? foundFromNode1 : Math.Min(foundFromNode1, foundFromNode2);
    }
}