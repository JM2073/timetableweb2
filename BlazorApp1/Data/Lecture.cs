using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Data
{
    public class Lecture
    {
        [Required]
        public string courseName { get; set; }
        
        [Required]
        public string moduleCode { get; set; }
        
        [Required]
        public string moduleName { get; set; }
        
        [Required]
        public string lecturerName { get; set; }
        
        [Required]
        public int roomNumber { get; set; }
        
        public string dayOfTheWeek { get; set; }
        
        [Required]
        public string ID { get; set; }
        
        [Required]
        public DateTime startTime { get; set; }
        
        [Required]
        public DateTime endTime { get; set; }
        
    }
}
