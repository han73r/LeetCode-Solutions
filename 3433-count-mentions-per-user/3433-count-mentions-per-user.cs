public class Solution {
    private class EventObj {
        public string Type;
        public int Time;
        public string Data;

        public EventObj(string type, int time, string data) {
            Type = type;
            Time = time;
            Data = data;
        }
    }
    public int[] CountMentions(int numberOfUsers, IList<IList<string>> events) {
        int[] mentions = new int[numberOfUsers];
        int[] offlineUntil = new int[numberOfUsers]; // 0 = online, >0 = time when they become online again

        // Build event list
        List<EventObj> evs = new List<EventObj>();
        foreach (var e in events) {
            string type = e[0];
            int time = int.Parse(e[1]);
            string data = e[2];
            evs.Add(new EventObj(type, time, data));
        }

        // Sort:
        // 1. Time ascending
        // 2. For same time: OFFLINE before MESSAGE
        evs.Sort((a, b) => {
            if (a.Time != b.Time)
                return a.Time.CompareTo(b.Time);

            if (a.Type == b.Type)
                return 0;

            return a.Type == "OFFLINE" ? -1 : 1;
        });

        // Process events in sorted order
        foreach (var ev in evs) {
            int t = ev.Time;

            // First: auto bring users online if offlineUntil <= current time
            for (int u = 0; u < numberOfUsers; u++) {
                if (offlineUntil[u] > 0 && offlineUntil[u] <= t)
                    offlineUntil[u] = 0;
            }

            if (ev.Type == "OFFLINE") {
                // User goes offline for 60 units
                int uid = int.Parse(ev.Data);
                offlineUntil[uid] = t + 60;
            }
            else { // MESSAGE
                string mentionString = ev.Data;

                if (mentionString == "ALL") {
                    // All users get mentioned regardless of offline status
                    for (int u = 0; u < numberOfUsers; u++)
                        mentions[u]++;
                }
                else if (mentionString == "HERE") {
                    // Only online users
                    for (int u = 0; u < numberOfUsers; u++) {
                        if (offlineUntil[u] == 0)
                            mentions[u]++;
                    }
                }
                else {
                    // Explicit mentions: "idX idY idZ ..."
                    string[] tokens = mentionString.Split(' ');
                    foreach (string token in tokens) {
                        if (token.StartsWith("id")) {
                            int id = int.Parse(token.Substring(2));
                            mentions[id]++; // Count even if offline
                        }
                    }
                }
            }
        }

        return mentions;
    }
}
