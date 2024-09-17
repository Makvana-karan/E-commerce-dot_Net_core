using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Faqs
    {
        [Key]
        public int faq_Id { get; set; }
        public string faq_question{ get; set; }
        public string faq_answer { get; set; }
    }
}
