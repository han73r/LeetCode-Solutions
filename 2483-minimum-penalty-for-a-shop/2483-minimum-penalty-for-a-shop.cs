public class Solution {
    private readonly char customerIndex = 'Y';
    public int BestClosingTime(string customers) {
        int penalty = 0, 
        minCustomerPenalty = 0, 
        bestClosingHour = 0;
        int workHours = customers.Length;

        foreach (char ch in customers)
            if (ch == customerIndex) penalty++;
        minCustomerPenalty = penalty;

        for (int hour = 0; hour < workHours; hour++) {
            if (customers[hour] == customerIndex)
                penalty--;
            else
                penalty++;
            if (penalty < minCustomerPenalty) {
                minCustomerPenalty = penalty;
                bestClosingHour = hour + 1;
            }
        }
        return bestClosingHour;
    }
}
