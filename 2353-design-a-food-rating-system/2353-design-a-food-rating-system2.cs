using System.Collections.Generic;

public class FoodRatings {
    private Dictionary<string, (string cuisine, int rating)> foodInfo;
    private Dictionary<string, SortedSet<(int rating, string food)>> cuisineFoods;

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings) {
        foodInfo = new Dictionary<string, (string cuisine, int rating)>();
        cuisineFoods = new Dictionary<string, SortedSet<(int, string)>>();
        var size = foods.Length;
        for (int i = 0; i < size; i++) {
            string food = foods[i];
            string cuisine = cuisines[i];
            int rating = ratings[i];
            foodInfo[food] = (cuisine, rating);
            if (!cuisineFoods.ContainsKey(cuisine))
                cuisineFoods[cuisine] = new SortedSet<(int, string)>(new FoodComparer());
            cuisineFoods[cuisine].Add((rating, food));
        }
    }

    public void ChangeRating(string food, int newRating) {
        var (cuisine, oldRating) = foodInfo[food];
        cuisineFoods[cuisine].Remove((oldRating, food));
        foodInfo[food] = (cuisine, newRating);
        cuisineFoods[cuisine].Add((newRating, food));
    }

    public string HighestRated(string cuisine) {
        return cuisineFoods[cuisine].First().food;
    }

    class FoodComparer : IComparer<(int rating, string food)> {
        public int Compare((int rating, string food) a, (int rating, string food) b) {
            int cmp = b.rating.CompareTo(a.rating);
            if (cmp == 0)
                cmp = a.food.CompareTo(b.food);
            return cmp;
        }
    }
}

/**
 * Your FoodRatings object will be instantiated and called as such:
 * FoodRatings obj = new FoodRatings(foods, cuisines, ratings);
 * obj.ChangeRating(food,newRating);
 * string param_2 = obj.HighestRated(cuisine);
 */