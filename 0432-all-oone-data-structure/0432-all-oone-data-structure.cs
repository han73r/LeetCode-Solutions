using System.Collections.Generic;

public class AllOne {
    private class Node {
        public int count;
        public HashSet<string> keys;
        public Node prev, next;
        public Node(int count) {
            this.count = count;
            this.keys = new HashSet<string>();
        }
    }
    private Dictionary<string, int> keyCount;
    private Dictionary<int, Node> countMap;
    private Node head, tail;
    public AllOne() {
        keyCount = new Dictionary<string, int>();
        countMap = new Dictionary<int, Node>();
        head = new Node(0); // Dummy head for easier list management
        tail = new Node(0); // Dummy tail for easier list management
        head.next = tail;
        tail.prev = head;
    }
    public void Inc(string key) {
        if (keyCount.ContainsKey(key)) {
            ChangeKeyCount(key, 1);
        } else {
            keyCount[key] = 1;
            if (!countMap.ContainsKey(1)) {
                AddNewNodeAfter(new Node(1), head);
            }
            countMap[1].keys.Add(key);
        }
    }
    public void Dec(string key) {
        if (!keyCount.ContainsKey(key)) return;

        int count = keyCount[key];
        if (count == 1) {
            keyCount.Remove(key);
            RemoveKeyFromNode(countMap[count], key);
        } else {
            ChangeKeyCount(key, -1);
        }
    }
    public string GetMaxKey() {
        if (tail.prev == head) return "";
        foreach (var key in tail.prev.keys) return key;
        return "";
    }
    public string GetMinKey() {
        if (head.next == tail) return "";
        foreach (var key in head.next.keys) return key;
        return "";
    }
    private void ChangeKeyCount(string key, int offset) {
        int count = keyCount[key];
        int newCount = count + offset;
        keyCount[key] = newCount;
        Node currentNode = countMap[count];
        if (!countMap.ContainsKey(newCount)) {
            Node newNode = new Node(newCount);
            AddNewNodeAfter(newNode, offset == 1 ? currentNode : currentNode.prev);
        }
        countMap[newCount].keys.Add(key);
        RemoveKeyFromNode(currentNode, key);
    }
    private void AddNewNodeAfter(Node newNode, Node prevNode) {
        newNode.next = prevNode.next;
        newNode.prev = prevNode;
        prevNode.next.prev = newNode;
        prevNode.next = newNode;
        countMap[newNode.count] = newNode;
    }
    private void RemoveKeyFromNode(Node node, string key) {
        node.keys.Remove(key);
        if (node.keys.Count == 0) {
            RemoveNodeFromList(node);
        }
    }
    private void RemoveNodeFromList(Node node) {
        node.prev.next = node.next;
        node.next.prev = node.prev;
        countMap.Remove(node.count);
    }
}