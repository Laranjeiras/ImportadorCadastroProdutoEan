using System;

namespace ImportadorCadastroEan.Modelos
{
    public class Produto
    {
        public Guid GuidProduto { get; set; } = Guid.NewGuid();

        private string _gtin;

        public string Gtin
        {
            get { return Zion.Common.Helpers.StringHelper.MaxLength(_gtin, 14); }
            set { _gtin = value; }
        }

        //private string _descricaoNormalizada;

        //public string DescricaoNormalizada
        //{
        //    get { return Zion.Common.Helpers.StringHelper.MaxLength(_descricaoNormalizada,50); }
        //    set { _descricaoNormalizada = value; }
        //}

        private string _descricaoUpper;

        public string DescricaoUpper
        {
            get { return Zion.Common.Helpers.StringHelper.MaxLength(_descricaoUpper, 60); }
            set { _descricaoUpper = value; }
        }

        //public string DescricaoAcento { get; set; }
        //public string Peso { get; set; }
        private string _ncm;

        public string Ncm
        {
            get { return Zion.Common.Helpers.StringHelper.MaxLength(_ncm, 8); }
            set { _ncm = value; }
        }

        public string Ucom { get; set; }

        //public string Cest { get; set; }
        //public string Marca { get; set; }
        //public string Categoria { get; set; }

        private string _embalagem;
        public string Embalagem
        {
            get { return Zion.Common.Helpers.StringHelper.MaxLength(_embalagem, 6); }
            set { _embalagem = value; }
        }

        public decimal QuantidadeEmbalagem { get; set; } = 0;
        public decimal PrecoMedio { get; set; } = 0;
        //public string ImgGtin { get; set; }
        //public string FotoPng { get; set; }
        //public string FotoGif { get; set; }
        //public string FotoTabloidePng { get; set; }
        //public string FotoTabloideGif { get; set; }

        public int IdProduto { get; set; } = 0;

        public int PrecoCusto { get; set; } = 0;
        public int Comissao { get; set; } = 0;

        public int Estoque { get; set; } = 0;
        public int EstoqueInicial { get; set; } = 0;

        //public bool ExibirNaTabela { get; set; } = false;

        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime AtualizadoEm { get; set; } = DateTime.Now;

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
