public class MyCircularDeque {

    private Node front;
    private Node last;

    private int capacity;
    private int nodes = 0;

    public MyCircularDeque(int k) {
        capacity = k;
    }

    public bool InsertFront(int value) {
        if (IsFull())
            return false;

        nodes++;
        if (front == null) {
            front = new Node(value);
            last = front;
            return true;
        }

        var temp = new Node(value, front, last);
        front = temp;
        return true;
    }

    public bool InsertLast(int value) {
        if (IsFull())
            return false;

        nodes++;
        if (last == null) {
            last = new Node(value);
            front = last;
            return true;
        }

        var temp = new Node(value, front, last);
        last = temp;

        return true;
    }

    public bool DeleteFront() {
        if (IsEmpty())
            return false;

        if (nodes == 1) {
            last = null;
            front = null;
        } else {
            var tempL = front.Left;
            var tempR = front.Right;
            tempL.Right = tempR;
            tempR.Left = tempL;
            front = tempL;
        }

        nodes--;
        return true;
    }

    public bool DeleteLast() {
        if (IsEmpty())
            return false;

        if (nodes == 1) {
            last = null;
            front = null;
        } else {
            var tempL = last.Left;
            var tempR = last.Right;
            tempL.Right = tempR;
            tempR.Left = tempL;
            last = tempR;
        }

        nodes--;
        return true;
    }

    public int GetFront() {
        if (IsEmpty())
            return -1;

        return front.Value;
    }

    public int GetRear() {
        if (IsEmpty())
            return -1;

        return last.Value;
    }

    public bool IsEmpty() {
        return nodes == 0;
    }

    public bool IsFull() {
        return nodes == capacity;
    }
}

public class Node {
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int value, Node left = null, Node right = null) {
        Value = value;
        Left = left;
        Right = right;

        if (left != null)
            left.Right = this;

        if (right != null)
            right.Left = this;
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */