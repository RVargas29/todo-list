namespace TodoList.Models
{
    public class TodoListDatabaseSettings : ITodoListDatabaseSettings {
        public string TaskCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface ITodoListDatabaseSettings {
        string TaskCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}