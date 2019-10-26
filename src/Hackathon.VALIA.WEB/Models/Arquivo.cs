using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hackathon.VALIA.WEB.Models
{
    public class TipoArquivo
    {
        [Key]
        public int TipoArquivoId { get; set; }

        public string NomeTipoArquivo { get; set; }
    }
    public class Arquivo
    {
        [Key]
        public int ArquivoId { get; set; }

        [StringLength(200)]
        public string NomeArquivo { get; set; }

        public string User { get; set; }

        public string Status { get; set; }

        public int? ErroId { get; set; }

        public TipoArquivo TipoArquivo { get; set; }

        public ICollection<Erros> Erros { get; set; }
    }

    public class Erros
    {
        [Key]
        public int ErroId { get; set; }

        public int PosicaoInicial { get; set; }

        public int Tamanho { get; set; }

        public string Texto { get; set; }

        public string Campo { get; set; }

        public int ArquivoId { get; set; }

        public int Linha { get; set; }
    }
}
