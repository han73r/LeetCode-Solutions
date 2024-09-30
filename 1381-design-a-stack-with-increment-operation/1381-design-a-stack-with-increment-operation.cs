using System;

public class CustomStack {
    private int[] stack;
    private int[] inc;
    private int maxSize;
    private int top;
    public CustomStack(int maxSize) {
        this.maxSize = maxSize;
        this.stack = new int[maxSize];
        this.inc = new int[maxSize];
        this.top = 0;
    }

    public void Push(int x) {
        if (top < maxSize) {
            stack[top] = x;
            top++;
        }
    }

    public int Pop() {
        if (top == 0) {
            return -1;
        }
        top--;
        int value = stack[top] + inc[top];
        if (top > 0) {
            inc[top - 1] += inc[top];
        }
        inc[top] = 0;
        return value;
    }

    public void Increment(int k, int val) {
        int limit = Math.Min(k, top);
        if (limit > 0) {
            inc[limit - 1] += val;
        }
    }
}

/**
 * Your CustomStack object will be instantiated and called as such:
 * CustomStack obj = new CustomStack(maxSize);
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * obj.Increment(k,val);
 */