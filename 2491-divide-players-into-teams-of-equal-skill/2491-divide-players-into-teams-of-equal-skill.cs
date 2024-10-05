using System;

public class Solution {
    public long DividePlayers(int[] skill) {
        Array.Sort(skill);
        int n = skill.Length;
        long totalChemistry = 0;
        int teamSkillSum = skill[0] + skill[n - 1];
        for (int i = 0; i < n / 2; i++) {
            int currentTeamSkill = skill[i] + skill[n - 1 - i];
            if (currentTeamSkill != teamSkillSum) {
                return -1;
            }
            totalChemistry += (long)skill[i] * skill[n - 1 - i];
        }
        return totalChemistry;
    }
}