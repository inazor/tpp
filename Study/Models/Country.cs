using Study.Models.Interfaces;

namespace Study.Models
{
    public class Country : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}