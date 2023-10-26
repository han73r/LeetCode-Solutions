public class Solution 
{
    public bool IsValid(string s) 
    {
        if (s.Length % 2 != 0)              // Check length 
        {
            return false;
        }   

        char[] stack = new char[s.Length];
        int top = -1;                       // index top of stack

        foreach (char c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack[++top] = c;           // Add to stack
            }
            else
            {
                if (top == -1 || !IsValidPair(stack[top], c))
                {
                    return false;
                }
                top--;                      // Delete from stack
            }
        }
        return top == -1;                   // stack should be empty
    }

    private bool IsValidPair(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '[' && close == ']') ||
               (open == '{' && close == '}');
    }
}
