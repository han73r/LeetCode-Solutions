using System;
using System.Linq;

public class Solution {
    public int LargestPerimeter(int[] nums) {
        // Сортируем массив по убыванию
        Array.Sort(nums);
        Array.Reverse(nums);
        
        // Перебираем тройки элементов в отсортированном массиве
        for (int i = 0; i < nums.Length - 2; i++) {
            int a = nums[i];
            int b = nums[i + 1];
            int c = nums[i + 2];
            
            // Проверяем, является ли текущая тройка допустимой стороной для полигона
            if (a < b + c) {
                // Если да, то возвращаем сумму сторон тройки как наибольший периметр
                return a + b + c;
            }
        }
        
        // Если не удалось найти допустимый полигон, возвращаем -1
        return -1;
    }
}
