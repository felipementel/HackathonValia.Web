using System.ComponentModel.DataAnnotations;

namespace Hackathon.VALIA.WEB.Models
{
    public class Arquivo
    {
        [Key]
        public int ArquivoId { get; set; }

        public string NomeArquivo { get; set; }

        public string User { get; set; }

        public string Status { get; set; }
    }
}
