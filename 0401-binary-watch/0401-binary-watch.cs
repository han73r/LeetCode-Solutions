public class Solution {
    public IList<string> ReadBinaryWatch(int turnedOn) {
        return (from minute in Enumerable.Range(0, 60)
        from hour in Enumerable.Range(0,12)
        where int.PopCount(minute) + int.PopCount(hour) == turnedOn
        select $"{hour}:{minute:D2}").ToList();
    }
}
