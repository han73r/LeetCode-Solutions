public class Solution {
    public int[] SeparateDigits(int[] nums) {
        List<int> list = new();
        foreach (int x in nums){
            string s = x.ToString();
            foreach (char ch in s) {
                list.Add(ch - '0');
            }
        }
        return (list.ToArray());
    }
}
