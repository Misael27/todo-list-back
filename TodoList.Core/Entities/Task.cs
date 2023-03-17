using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoList.Core.Entities
{
    public class Task
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime date { get; set; }
        public int TaskStateId { get; set; }
        [JsonIgnore]
        public virtual TaskState? TaskState { get; set; }
        public int TaskCategoryId { get; set; }
        [JsonIgnore]
        public virtual TaskCategory? TaskCategory { get; set; }
    }
}
