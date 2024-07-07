public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        int result = numBottles;
        while (numBottles >= numExchange) {
            int newBottles = numBottles / numExchange;
            result += newBottles;
            numBottles = newBottles + (numBottles % numExchange);
        }
        return result;
    }
}