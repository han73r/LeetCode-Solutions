public class MinStack {
    private Stack<int> topStack;
    private Stack<int> minStack;

    public MinStack() {
        topStack = new Stack<int>();
        minStack = new Stack<int>();
    }
    
    public void Push(int val) {
        topStack.Push(val);
        if (minStack.Count == 0 || val <= minStack.Peek())
            minStack.Push(val);
    }
    
    public void Pop() {
        if (minStack.Count != 0 && minStack.Peek() == topStack.Peek()) minStack.Pop();
        if (topStack.Count != 0) topStack.Pop();
    }
    
    public int Top() {
        return topStack.Peek();
    }
    
    public int GetMin() {
        return minStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
