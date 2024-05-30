using System.Collections.Generic;

public class MyQueue {
    private Stack<int> inputStack;
    private Stack<int> outputStack;

    /** Initialize your data structure here. */
    public MyQueue() {
        inputStack = new Stack<int>();
        outputStack = new Stack<int>();
    }

    /** Push element x to the back of queue. */
    public void Push(int x) {
        inputStack.Push(x);
    }

    /** Removes the element from in front of queue and returns that element. */
    public int Pop() {
        EnsureOutputStack();
        return outputStack.Pop();
    }

    /** Get the front element. */
    public int Peek() {
        EnsureOutputStack();
        return outputStack.Peek();
    }

    /** Returns whether the queue is empty. */
    public bool Empty() {
        return inputStack.Count == 0 && outputStack.Count == 0;
    }

    private void EnsureOutputStack() {
        if (outputStack.Count == 0) {
            while (inputStack.Count > 0) {
                outputStack.Push(inputStack.Pop());
            }
        }
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */