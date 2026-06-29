public class Solution {
    public int NumOfStrings(string[] patterns_, string word_) {
        return patterns_.Count(pattern_ => word_.Contains(pattern_));
    }
}
