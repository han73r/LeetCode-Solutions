public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        int result = numBottles;
        int balance = 0, modulo = 0;
        while (numBottles >= numExchange) {
            modulo = numBottles % numExchange;
            balance = numBottles / numExchange;
            numBottles = balance + modulo;
            result += balance;
        }
        return result;
    }
}