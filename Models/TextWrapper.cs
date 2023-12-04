using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TSLAssignment.Models
{
    public class TextWrapper
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public bool EnableReversed { get; set; }
        public string? ReversedText { get; set; }
        [Display(Name = "Created Time")]
        public DateTime CreatedTime { get; set; }
    }
}
