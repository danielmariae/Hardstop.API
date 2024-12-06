using System.Data;

namespace Hardstop.API.Entities
{
    public class Pagamento
    {
        public Guid Id { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime DataHoraPagamento { get; set; }
        public decimal ValorPagamento { get; set; }
        public bool ValidacaoPagamento { get; set; }

        public void Update(String formaPagamento,  DateTime dataHoraPagamento, decimal valorPagamento, bool validacaoPagamento)
        {
            FormaPagamento = formaPagamento;
            DataHoraPagamento = dataHoraPagamento;
            ValorPagamento = valorPagamento;
            ValidacaoPagamento = validacaoPagamento;
        }
    }
    public class PagamentoDTO
    {
        public string FormaPagamento { get; set; }
        public DateTime DataHoraPagamento { get; set; }
        public decimal ValorPagamento { get; set; }
        public bool ValidacaoPagamento { get; set; }
    }
}