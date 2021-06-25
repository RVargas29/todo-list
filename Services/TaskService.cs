using System.Threading.Tasks;
using TodoList.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TodoList.Services {
    public class TasksService {
        private readonly IMongoCollection<TodoList.Models.Task> _tasks;

        public TasksService(ITodoListDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tasks = database.GetCollection<TodoList.Models.Task>(settings.TaskCollectionName);
        }

        public List<TodoList.Models.Task> Get() =>  _tasks.Find(task => true).ToList();

        public TodoList.Models.Task Get(string id) => _tasks.Find<TodoList.Models.Task>(task => task.Id == id).FirstOrDefault();

        public TodoList.Models.Task Create(TodoList.Models.Task task) {
            _tasks.InsertOne(task);
            return task;
        }

        public void Update(string id, TodoList.Models.Task taskIn) => _tasks.ReplaceOne(task => task.Id == id, taskIn);

        public void Remove(TodoList.Models.Task taskIn) => _tasks.DeleteOne(task => task.Id == taskIn.Id);
    }
}