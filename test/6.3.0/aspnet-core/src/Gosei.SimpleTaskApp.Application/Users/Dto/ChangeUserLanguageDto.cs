using System.ComponentModel.DataAnnotations;

namespace Gosei.SimpleTaskApp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}