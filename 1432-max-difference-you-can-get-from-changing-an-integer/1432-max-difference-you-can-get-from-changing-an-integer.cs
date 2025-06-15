public class Solution {
    public int MaxDiff(int num) {
       string org = num.ToString();
        string maxStr = org;
        foreach (var item in org)
        {
            if (item != '9')
            {
                maxStr = org.Replace(item, '9');
                break;
            }
        }

        int maxNum = int.Parse(maxStr);
        string minStr = org;
        if (org[0] != '1')
        {
            minStr = org.Replace(org[0], '1');
        } else {
            for (int i = 1; i < org.Length; i++)
            {
                if (org[i] != '0' && org[i] != org[0])
                {
                    minStr = org.Replace(org[i], '0');
                    break;
                }
            }
        }
        int minNum = int.Parse(minStr);

        return maxNum - minNum;
    }
}