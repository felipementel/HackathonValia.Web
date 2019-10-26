using System.ComponentModel.DataAnnotations;

namespace Hackathon.VALIA.WEB.Models
{
    public class Arquivo
    {
        [Key]
        public int ArquivoId { get; set; }

        [StringLength(200)]
        public string NomeArquivo { get; set; }

        public string User { get; set; }

        public string Status { get; set; }
    }

    public class Erros
    {
        public int Linha { get; set; }

        public int PosicaoInicial { get; set; }
        
        public int Tamanho { get; set; }

        public string Texto { get; set; }

        public string Campo { get; set; }

        public int ArquivoId { get; set; }

        public int ErroId { get; set; }
    }
}
