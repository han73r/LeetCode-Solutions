using System.Collections.Generic;

public class TaskManager {
    private readonly Dictionary<int, int> taskToPriority = new();
    private readonly Dictionary<int, int> taskToUser = new();
    private readonly PriorityQueue<(int taskId, int priority), (int negPriority, int negTaskId)> queue = new();

    public TaskManager(IList<IList<int>> tasks) {
        foreach (var task in tasks) {
            int userId = task[0];
            int taskId = task[1];
            int priority = task[2];
            taskToPriority[taskId] = priority;
            taskToUser[taskId] = userId;
            queue.Enqueue((taskId, priority), (-priority, -taskId));
        }
    }

    public void Add(int userId, int taskId, int priority) {
        taskToPriority[taskId] = priority;
        taskToUser[taskId] = userId;
        queue.Enqueue((taskId, priority), (-priority, -taskId));
    }

    public void Edit(int taskId, int newPriority) {
        taskToPriority[taskId] = newPriority;
        queue.Enqueue((taskId, newPriority), (-newPriority, -taskId));
    }

    public void Rmv(int taskId) {
        taskToPriority.Remove(taskId);
        taskToUser.Remove(taskId);
    }

    public int ExecTop() {
        while (queue.Count > 0) {
            var (taskId, priority) = queue.Dequeue();
            if (!taskToPriority.TryGetValue(taskId, out int correctPriority)) continue;
            if (priority != correctPriority) continue;

            int userId = taskToUser[taskId];
            Rmv(taskId);
            return userId;
        }
        return -1;
    }
}
