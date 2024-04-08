using System.Collections.Generic;

public class Solution {
    public int CountStudents(int[] students, int[] sandwiches) {
        var studentsQueue = new Queue<int>(students);
        var sandwichesStack = new Stack<int>();
        for (int i = sandwiches.Length - 1; i >= 0; i--) {
            sandwichesStack.Push(sandwiches[i]);
        }
        int attempts = 0;
        while (attempts != studentsQueue.Count()) {
            if (sandwichesStack.Peek() == studentsQueue.Peek()) {
                sandwichesStack.Pop();
                attempts = 0;
            } else {
                studentsQueue.Enqueue(studentsQueue.Peek());
                attempts++;
            }
            studentsQueue.Dequeue();
        }
        return studentsQueue.Count();
    }
}