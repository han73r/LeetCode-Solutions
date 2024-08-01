using System;

public class Solution {
    public int CountSeniors(string[] details) {
        int ans = 0;
        for (int i = 0; i < details.Length; i++) {
            string check = "";
            check += details[i][11];
            check += details[i][12];
            if (Convert.ToInt32(check) > 60) ans++;
        }
        return ans;
    }
}
// Dont work with ["9751302862F0693","3888560693F7262","5485983835F0649","2580974299F6042","9976672161M6561","0234451011F8013","4294552179O6482"] %) 
// public class Solution {
//     private readonly int ageFilter = 60;
//     public int CountSeniors(string[] details) {
//         int seniorsCount = default;
//         string s = default;
//         int age = default;
//         foreach (string detail in details) {
//             s = detail.Substring(11,2);
//             age = Convert.ToInt32(s);
//             if (age >= 60) {
//                 seniorsCount++;
//             }
//         }
//         return seniorsCount;
//     }
// }