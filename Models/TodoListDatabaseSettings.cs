namespace TodoList.Models
{
    public class TodoListDbSettings : ITodoListDbSettings {
        public string TaskCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface ITodoListDbSettings {
        string TaskCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}