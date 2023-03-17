using TodoList.Core.Entities;

namespace TodoList.Application.Tasks
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive => TaskState?.Id == TaskConstants.ACTIVE_STATE;
        public virtual TaskState? TaskState { get; set; }
        public virtual TaskCategory? TaskCategory { get; set; }
    }
}
