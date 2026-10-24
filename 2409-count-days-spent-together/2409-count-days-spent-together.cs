public class Solution {
    public int CountDaysTogether(
        string arriveAlice, 
        string leaveAlice, 
        string arriveBob, 
        string leaveBob) {
            
        int start = Math.Max(
            DateTime.Parse(arriveAlice).DayOfYear,
            DateTime.Parse(arriveBob).DayOfYear);

        int end = Math.Min(
            DateTime.Parse(leaveAlice).DayOfYear,
            DateTime.Parse(leaveBob).DayOfYear);

        return Math.Max(0, end - start + 1);
    }
}
