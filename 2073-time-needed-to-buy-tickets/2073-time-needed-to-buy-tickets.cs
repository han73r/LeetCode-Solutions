using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Solution {
    public int TimeRequiredToBuy(int[] tickets, int k) {
        int n = tickets.Length;
        int totalTime = 0;
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < n; i++) {
            queue.Enqueue(i);
        }
        int index = 0;
        while (queue.Count > 0) {
            int person = queue.Dequeue();
            if (tickets[person] > 0) {
                tickets[person]--;
                totalTime++;
                if (person == k && tickets[person] == 0) {
                    return totalTime;
                }
            } else {
                continue;
            }
            queue.Enqueue(person);
        }
        return totalTime;
    }
}


//public interface GetReverseWordCount() {
//    var text = File.ReadAllText("worldAndPeace.txt");
//    var words = text.Split(' ');
//    return words.Distinct()
//                .Count(word => words.Any(anotherWord => anotherWord == word.Reverse()));
//}