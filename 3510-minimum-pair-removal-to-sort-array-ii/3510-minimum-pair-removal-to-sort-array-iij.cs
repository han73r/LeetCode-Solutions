public class Solution {
    public int MinimumPairRemoval(int[] InputNumbers) {
        var PriorityQueue = new PriorityQueue<Item, Item>();
        bool[] IsMerged = new bool[InputNumbers.Length];
        int InversionCount = 0;
        int OperationCount = 0;

        List<Node> NodeList = new List<Node>();
        NodeList.Add(new Node(InputNumbers[0], 0));

        for (int Index = 1; Index < InputNumbers.Length; Index++) {
            NodeList.Add(new Node(InputNumbers[Index], Index));

            NodeList[Index - 1].Next = NodeList[Index];
            NodeList[Index].Previous = NodeList[Index - 1];

            var NewItem = new Item(NodeList[Index - 1], NodeList[Index], NodeList[Index - 1].Value + NodeList[Index].Value);
            PriorityQueue.Enqueue(NewItem, NewItem);

            if (InputNumbers[Index - 1] > InputNumbers[Index]) {
                InversionCount++;
            }
        }

        while (InversionCount > 0) {
            if (PriorityQueue.Count == 0) {
                break;
            }

            var CurrentItem = PriorityQueue.Dequeue();
            Node First = CurrentItem.FirstNode;
            Node Second = CurrentItem.SecondNode;
            long CurrentSum = CurrentItem.PairSum;

            if (IsMerged[First.OriginalIndex] || IsMerged[Second.OriginalIndex] || First.Value + Second.Value != CurrentSum) {
                continue;
            }

            OperationCount++;

            if (First.Value > Second.Value) {
                InversionCount--;
            }

            Node PreviousNode = First.Previous;
            Node NextNode = Second.Next;

            First.Next = NextNode;
            if (NextNode != null) {
                NextNode.Previous = First;
            }

            if (PreviousNode != null) {
                bool WasInverted = PreviousNode.Value > First.Value;
                bool IsInverted = PreviousNode.Value > CurrentSum;

                if (WasInverted && !IsInverted) {
                    InversionCount--;
                } else if (!WasInverted && IsInverted) {
                    InversionCount++;
                }

                var LeftItem = new Item(PreviousNode, First, PreviousNode.Value + CurrentSum);
                PriorityQueue.Enqueue(LeftItem, LeftItem);
            }

            if (NextNode != null) {
                bool WasInverted = Second.Value > NextNode.Value;
                bool IsInverted = CurrentSum > NextNode.Value;

                if (WasInverted && !IsInverted) {
                    InversionCount--;
                } else if (!WasInverted && IsInverted) {
                    InversionCount++;
                }

                var RightItem = new Item(First, NextNode, CurrentSum + NextNode.Value);
                PriorityQueue.Enqueue(RightItem, RightItem);
            }

            First.Value = CurrentSum;
            IsMerged[Second.OriginalIndex] = true;
        }

        return OperationCount;
    }
}
