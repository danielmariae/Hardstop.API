using System.Data;

namespace Hardstop.API.Entities
{
    /// <summary>
    /// Representa um pagamento associado a um pedido.
    /// </summary>
    public class Pagamento
    {
        /// <summary>
        /// Identificador único do pagamento.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Forma de pagamento utilizada.
        /// </summary>
        public required string FormaPagamento { get; set; }

        /// <summary>
        /// Data e hora em que o pagamento foi realizado.
        /// </summary>
        public DateTime DataHoraPagamento { get; set; }

        /// <summary>
        /// Valor do pagamento.
        /// </summary>
        public decimal ValorPagamento { get; set; }

        /// <summary>
        /// Indicação se o pagamento foi validado com sucesso.
        /// </summary>
        public bool ValidacaoPagamento { get; set; }

        /// <summary>
        /// Atualiza os detalhes do pagamento.
        /// </summary>
        /// <param name="formaPagamento">Nova forma de pagamento.</param>
        /// <param name="dataHoraPagamento">Nova data e hora do pagamento.</param>
        /// <param name="valorPagamento">Novo valor do pagamento.</param>
        /// <param name="validacaoPagamento">Nova validação do pagamento.</param>
        public void Update(string formaPagamento, DateTime dataHoraPagamento, decimal valorPagamento, bool validacaoPagamento)
        {
            FormaPagamento = formaPagamento;
            DataHoraPagamento = dataHoraPagamento;
            ValorPagamento = valorPagamento;
            ValidacaoPagamento = validacaoPagamento;
        }
    }

    /// <summary>
    /// Data Transfer Object (DTO) para Pagamento, usado para transferir dados entre camadas.
    /// </summary>
    public class PagamentoDTO
    {
        /// <summary>
        /// Forma de pagamento utilizada.
        /// </summary>
        public required string FormaPagamento { get; set; }

        /// <summary>
        /// Data e hora em que o pagamento foi realizado.
        /// </summary>
        public DateTime DataHoraPagamento { get; set; }

        /// <summary>
        /// Valor do pagamento.
        /// </summary>
        public decimal ValorPagamento { get; set; }

        /// <summary>
        /// Indicação se o pagamento foi validado com sucesso.
        /// </summary>
        public bool ValidacaoPagamento { get; set; }
    }
}