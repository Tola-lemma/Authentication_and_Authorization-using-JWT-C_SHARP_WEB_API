namespace classTwoTodo.Models
{
    public class TodoItems
    {
        public string id { get; set; }
        public string task { get; set; }
        public bool completed { get; set; }
        public string userID { get; set; }

        public TodoItems(string id, string task, bool completed, string userID)
        {
            this.id = id;
            this.task = task;
            this.completed = completed;
            this.userID = userID;
        }
    }

}
