using CodeZero.Domain.Messaging;

namespace Entities.Events
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
