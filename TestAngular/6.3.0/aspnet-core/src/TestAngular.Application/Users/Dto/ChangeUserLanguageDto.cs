using System.ComponentModel.DataAnnotations;

namespace TestAngular.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}