using System.Collections.Generic;

public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new();
        foreach (string token in tokens) {
            if (IsOperand(token)) {
                stack.Push(int.Parse(token));
            } else {
                stack.Push(PerformOperation(stack.Pop(), stack.Pop(), token));
            }
        }
        return stack.Pop();
    }

    private bool IsOperand(string token) {
        return !("+ - * /".Contains(token));
    }

    private int PerformOperation(int num1, int num2, string op) {
        return op switch {
            "+" => num2 + num1,
            "-" => num2 - num1,
            "*" => num2 * num1,
            "/" => num2 / num1
        };
    }
}