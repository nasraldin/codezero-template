using CodeZero.Domain.Messaging;

namespace CodeZeroTemplate.Entities.Events
{
    public class ToDoItemCompletedEvent : Event
    {
        public ToDoItem CompletedItem { get; set; }

        public ToDoItemCompletedEvent(ToDoItem completedItem)
        {
            CompletedItem = completedItem;
        }
    }
}
