using System;

namespace ImportadorCadastroEan.Modelos
{
    public class Produto
    {
        public Guid GuidProduto { get; set; } = Guid.NewGuid();
        public string Gtin { get; set; }
        public string DescricaoNormalizada { get; set; }
        public string DescricaoUpper { get; set; }
        public string DescricaoAcento { get; set; }
        public string Peso { get; set; }
        public string Ncm { get; set; }
        public string Cest { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Embalagem { get; set; }
        public decimal Quantidade { get; set; } = 0;
        public decimal PrecoMedio { get; set; } = 0;
        public string ImgGtin { get; set; }
        public string FotoPng { get; set; }
        public string FotoGif { get; set; }
        public string FotoTabloidePng { get; set; }
        public string FotoTabloideGif { get; set; }

        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public bool ValidoParaNFe() 
        {
            return true;

            //Zion.Common.Validations.ZionValidation.IsNullOrEmptyOrWhiteSpace(DescricaoNormalizada) ||
            //Zion.Common.Validations.ZionValidation.StringHasLen(DescricaoNormalizada, 0, 60) ||
           // Zion.Common.Validations.ZionValidation.IsNullOrEmptyOrWhiteSpace(DescricaoUpper) ||
           // Zion.Common.Validations.ZionValidation.StringHasLen(DescricaoUpper, 0, 60);
        }

        public static string RemoverAspas(string texto) 
        {
            if (Zion.Common.Helpers.StringHelper.IsNullOrEmptyOrWhiteSpace(texto))
                return null;
            if (texto.StartsWith("\""))
                texto = texto.Substring(1, texto.Length - 1);
            if (texto.EndsWith("\""))
                texto = texto.Substring(0, texto.Length - 1);

            return texto.Trim();
        }
    }
}
