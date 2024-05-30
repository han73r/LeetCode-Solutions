using System.Collections.Generic;
using System;

public class RandomizedSet
{

    private List<int> list;
    private Dictionary<int, int> map;
    private Random random;

    public RandomizedSet()
    {
        list = new List<int>();
        map = new Dictionary<int, int>();
        random = new Random();
    }

    public bool Insert(int val)
    {
        if (map.ContainsKey(val)) return false;

        map[val] = list.Count;
        list.Add(val);
        return true;
    }

    public bool Remove(int val)
    {
        if (!map.ContainsKey(val)) return false;

        int lastElement = list[list.Count - 1];
        int indexToRemove = map[val];

        list[indexToRemove] = lastElement;
        map[lastElement] = indexToRemove;

        list.RemoveAt(list.Count - 1);
        map.Remove(val);

        return true;
    }

    public int GetRandom()
    {
        int randomIndex = random.Next(list.Count);
        return list[randomIndex];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */