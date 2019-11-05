using BasicArchitectureTemplate.Models.Base;

namespace BasicArchitectureTemplate.Models
{
    public class TodoItem : EntityBase<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}