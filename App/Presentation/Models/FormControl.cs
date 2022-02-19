namespace Presentation.Models
{
    public class FormControl
    {
        public object Value { get; set; }
        public string Error { get; set; }
        public Validators Validator { get; set; }
    }
}
