public class Solution {
    public IList<int> BusiestServers(int k, int[] arrival, int[] load) {
        var count = new int[k];
        var result = new List<int>();
        var free = new PriorityQueue<int,int>();
        var busy = new PriorityQueue<(int,int),int>();

        for(int i=0;i<k;i++) {
            free.Enqueue(i,i);
        }

        for(int i=0;i<arrival.Length;i++) {
            int start = arrival[i];

            while(busy.Count>0 && busy.Peek().Item1 <=start){
                var curr = busy.Dequeue();
                int serverId = curr.Item2;
                int modifiedId = ((serverId-i)%k+k)%k+i;
                free.Enqueue(modifiedId,modifiedId);
            }

            if(free.Count>0) {
                int busyId = free.Dequeue()%k;
                busy.Enqueue((start+load[i],busyId),start+load[i]);
                count[busyId]++;
            }
        }

        int max = Int32.MinValue;
        
        foreach(int c in count) {
            max = Math.Max(max,c);
        }

        for(int i=0;i<count.Length;i++) {
            if(max==count[i]) {
                result.Add(i);
            }
        }

        return result;
    }
}
