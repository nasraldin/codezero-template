using System;
using System.Linq.Expressions;
using CodeZero.Domain.Specification;
using CodeZeroTemplate.Entities;

namespace CodeZeroTemplate.Core.Specifications
{
    public class IncompleteItemsSpecification : Specification<ToDoItem>
    {

        public IncompleteItemsSpecification()
        {
            //// Query.Where(item => !item.IsDone);
        }

        public override Expression<Func<ToDoItem, bool>> ToExpression()
        {
            throw new NotImplementedException();
        }
    }
}