public class Solution {
    private bool Andd(string exp) {
        int n = exp.Length, j = 0;
        string subexp = "";
        int active = 0;
        while (j < n) {
            if (active == 0 && exp[j] == ',') {
                if (!ParseBoolExpr(subexp)) return false;
                subexp = "";
                j++;
                continue;
            }
            if (exp[j] == '(') active++;
            if (exp[j] == ')') active--;
            subexp += exp[j++];
        }
        if (!ParseBoolExpr(subexp)) return false;
        return true;
    }
    private bool Orr(string exp) {
        int n = exp.Length, j = 0;
        string subexp = "";
        int active = 0;
        while (j < n) {
            if (active == 0 && exp[j] == ',') {
                if (ParseBoolExpr(subexp)) return true;
                subexp = "";
                j++;
                continue;
            }
            if (exp[j] == '(') active++;
            if (exp[j] == ')') active--;
            subexp += exp[j++];
        }
        if (ParseBoolExpr(subexp)) return true;
        return false;
    }
    public bool ParseBoolExpr(string exp) {
        int n = exp.Length;
        if (n == 1) return (exp[0] == 't');
        if (exp[0] == '!') return !ParseBoolExpr(exp.Substring(2, n - 3));
        if (exp[0] == '&') return Andd(exp.Substring(2, n - 3));
        if (exp[0] == '|') return Orr(exp.Substring(2, n - 3));
        return false;
    }
}