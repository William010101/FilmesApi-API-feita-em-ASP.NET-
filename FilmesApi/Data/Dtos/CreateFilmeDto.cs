using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateFilmeDto
    {

        [Required(ErrorMessage = "titulo é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "titulo é obrigatório")]
        [StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50")]
        public string Genero { get; set; }
        [Required]
        [Range(70, 600, ErrorMessage = "a duração não pode ser maior que 600 min")]
        public int Duracao { get; set; }
    }
}
