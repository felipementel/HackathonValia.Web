using Hackathon.VALIA.WEB.Data;
using POCAttribute.Models.ElementAttribute;
using System;
using System.Reflection;
using Hackathon.VALIA.WEB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace POCAttribute.Models
{
    class Empregado
    {
        private readonly ApplicationDbContext _context;

        public Empregado(ApplicationDbContext context)
        {
            _context = context;
        }

        public Empregado(string line, int lineNumber, string fileName)
        {
            Type classType = typeof(Empregado);
            PropertyInfo propInfo = null;
            EmpregadoAttribute attr = null;
            try
            {

                foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
                {
                    propInfo = propertyInfo;
                    EmpregadoAttribute attribute = (EmpregadoAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(EmpregadoAttribute));
                    attr = attribute;

                    string strValue = line.Substring(attribute.InitialPosition, attribute.Length).Trim();

                    if (propertyInfo.PropertyType.Name == nameof(DateTime))
                    {
                        if (strValue == "00/00/0000")
                        {
                            propertyInfo.SetValue(this, DateTime.MinValue);
                        }
                        else
                        {
                            int year = int.Parse(strValue.Substring(6, 4));
                            int month = int.Parse(strValue.Substring(3, 2));
                            int day = int.Parse(strValue.Substring(0, 2));
                            propertyInfo.SetValue(this, new DateTime(year, month, day));
                        }
                    }
                    else if (propertyInfo.PropertyType.Name == nameof(Int32))
                    {
                        if (!int.TryParse(strValue, out int intValue))
                        {
                            throw new FormatException(string.Format("O valor \"{0}\" não pode ser convertido em um tipo inteiro válido.", strValue));
                        }

                        propertyInfo.SetValue(this, intValue);
                    }
                    else if (propertyInfo.PropertyType.Name == nameof(Char))
                    {
                        propertyInfo.SetValue(this, strValue[0]);
                    }
                    else
                    {
                        propertyInfo.SetValue(this, strValue);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format(
                    "Um erro ocorreu ao processar a linha {0}; campo \"{1}\" (posição inicial {2})\nErro Técnico: {3}",
                    lineNumber, propInfo.Name, (attr.InitialPosition + 1).ToString(), ex.Message));

                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("Server=tcp:hackathonvalia.database.windows.net,1433;Initial Catalog=DesafioValia;Persist Security Info=False;User ID=firjan;Password=!@#123qweasdzxc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                using (var _context = new ApplicationDbContext(optionsBuilder.Options))
                {
                    // do stuff
            
                    Arquivo arquivo = _context.Arquivos.FirstOrDefault(a => a.NomeArquivo.Equals(fileName));

                    if (arquivo == null)
                    {
                        throw new NullReferenceException("O arquivo " + fileName + " não foi localizado");
                    }

                    Erros erro = new Erros
                    {
                        Campo = propInfo.Name,
                        PosicaoInicial = attr.InitialPosition + 1,
                        PosicaoFinal = ((attr.InitialPosition + 1) + attr.Length) - 1,
                        Linha = lineNumber,
                        Texto =  ex.ToString(),
                        Tamanho = attr.Length,
                        ArquivoId = 1

                    };
                    _context.Erros.Add(erro);
                    _context.SaveChanges();

                    //string originPath = Path.Combine(@"D:\OneDrive\Novo", fileName + "111.txt");
                    //string destinationPath = Path.Combine(@"D:\OneDrive\Parcialmentebemsucedido", fileName + "111.txt");
                    //File.Move(originPath, destinationPath);
                }
            }
        }


        [EmpregadoAttribute(0, 1, true)]
        public string Grupo { get; set; }

        [EmpregadoAttribute(1, 3, true)]
        public string CodEmpresa { get; set; }

        [EmpregadoAttribute(4, 10, true)]
        public string Registro { get; set; }

        [EmpregadoAttribute(14, 50, true)]
        public string Nome { get; set; }

        [EmpregadoAttribute(64, 11, true)]
        public string CPF { get; set; }

        [EmpregadoAttribute(75, 15, true)]
        public string RG { get; set; }

        [EmpregadoAttribute(90, 6, true)]
        public string RGOrgaoExpedidor { get; set; }

        [EmpregadoAttribute(96, 5, false)]
        public string OrgaoLotaco { get; set; }

        [EmpregadoAttribute(101, 10, true)]
        public DateTime DataNascimento { get; set; }

        [EmpregadoAttribute(111, 2, true)]
        public string SituacaoPatrocinador { get; set; }

        [EmpregadoAttribute(113, 1, true)]
        public int CodEstadoCivil { get; set; }

        [EmpregadoAttribute(114, 50, true)]
        public string Pai { get; set; }

        [EmpregadoAttribute(164, 50, true)]
        public string Mae { get; set; }

        [EmpregadoAttribute(214, 1, true)]
        public char Sexo { get; set; }

        [EmpregadoAttribute(215, 80, true)]
        public string Endereco { get; set; }

        [EmpregadoAttribute(295, 25, true)]
        public string Bairro { get; set; }

        [EmpregadoAttribute(320, 40, true)]
        public string Cidade { get; set; }

        [EmpregadoAttribute(360, 2, true)]
        public string UF { get; set; }

        [EmpregadoAttribute(362, 8, true)]
        public string CEP { get; set; }

        [EmpregadoAttribute(370, 4, true)]
        public string DDDTelefone { get; set; }

        [EmpregadoAttribute(374, 25, true)]
        public string Telefone { get; set; }

        [EmpregadoAttribute(399, 10, true)]
        public DateTime DataInscricao { get; set; }

        [EmpregadoAttribute(409, 3, true)]
        public string Banco { get; set; }

        [EmpregadoAttribute(412, 7, true)]
        public string Agencia { get; set; }

        [EmpregadoAttribute(419, 15, true)]
        public string ContaCorrente { get; set; }

        [EmpregadoAttribute(434, 30, true)]
        public string Nacionalidade { get; set; }

        [EmpregadoAttribute(464, 4, false)]
        public string Ramal { get; set; }

        [EmpregadoAttribute(468, 15, true)]
        public string Salario { get; set; }

        [EmpregadoAttribute(483, 50, false)]
        public string Email { get; set; }

        [EmpregadoAttribute(533, 25, false)]
        public string Celular { get; set; }

        [EmpregadoAttribute(558, 4, false)]
        public string DDDCelular { get; set; }

        [EmpregadoAttribute(562, 10, true)]
        public DateTime DataAdmissao { get; set; }

        [EmpregadoAttribute(572, 10, false)]
        public DateTime DataAfastamento { get; set; }

        [EmpregadoAttribute(582, 10, true)]
        public DateTime DtInicioAlteracaoSituacao { get; set; }

        [EmpregadoAttribute(592, 10, false)]
        public DateTime DataDemissao { get; set; }

        [EmpregadoAttribute(602, 10, false)]
        public DateTime DataDesligamentoPlano { get; set; }

        [EmpregadoAttribute(612, 2, true)]
        public string CodMotivoDemissao { get; set; }

        [EmpregadoAttribute(614, 10, false)]
        public DateTime DataObito { get; set; }

        [EmpregadoAttribute(624, 1, false)]
        public int CodConfidencialidade { get; set; }

        [EmpregadoAttribute(625, 1, true)]
        public int CodContratoTrabalho { get; set; }

        [EmpregadoAttribute(626, 100, false)]
        public string CodEstrutural { get; set; }

        [EmpregadoAttribute(726, 10, true)]
        public DateTime RGDataExpedicao { get; set; }

        [EmpregadoAttribute(736, 14, true)]
        public string PercentualContribuicao { get; set; }

        [EmpregadoAttribute(750, 3, true)]
        public string Plano { get; set; }

        [EmpregadoAttribute(753, 15, false)]
        public string ContribuicaoEsporadica { get; set; }

        [EmpregadoAttribute(768, 10, false)]
        public DateTime DataInicio { get; set; }

        [EmpregadoAttribute(778, 10, false)]
        public DateTime DataFim { get; set; }

        [EmpregadoAttribute(788, 30, true)]
        public string Livre { get; set; }

        [EmpregadoAttribute(818, 2, true)]
        public string Tipo { get; set; }
    }
}