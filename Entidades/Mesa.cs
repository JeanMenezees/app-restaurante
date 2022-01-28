namespace Entidades
{
    public class Mesa
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public bool Ocupada { get; set; }
        public decimal Conta { get; set; }

        public void AdicionarCliente(string nomeDoCliente)
        {
            this.Cliente = nomeDoCliente;
            this.Ocupada = true;
        }

        public void RemoverCliente()
        {
            this.Cliente = "";
            this.Ocupada = false;
        }

        public void ZerarConta()
        {
            this.Conta = 0;
        }

        public void AdicionarNaConta(decimal precoProduto)
        {
            this.Conta += precoProduto;
        }
    }
}