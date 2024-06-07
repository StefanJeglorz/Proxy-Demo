using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Projects
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Code { get; set; }

        public decimal Budget { get; set; }

        public DateTime From { get; set; }
        public DateTime Until { get; set; }
    }
}
