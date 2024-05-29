using System.Text;

public class Solution {
    public int NumSteps(string s) {
        int steps = 0;
        while (s.Length > 1) {
            if (IsEven(s)) {
                s = DivideByTwo(s);
            } else {
                s = AddOne(s);
            }
            steps++;
        }
        return steps;
    }
    private bool IsEven(string binary) {
        return binary[binary.Length - 1] == '0';
    }
    private string DivideByTwo(string binary) {
        return binary.Substring(0, binary.Length - 1);
    }
    private string AddOne(string binary) {
        StringBuilder sb = new StringBuilder(binary);
        int carry = 1;
        for (int i = sb.Length - 1; i >= 0; i--) {
            int sum = (sb[i] - '0') + carry;
            sb[i] = (char)((sum % 2) + '0');
            carry = sum / 2;
            if (carry == 0) {
                break;
            }
        }
        if (carry == 1) {
            sb.Insert(0, '1');
        }
        return sb.ToString();
    }
}