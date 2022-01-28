using Entidades;
using Contexto;

namespace Repositorios
{
    public class RepositorioMesa : IRepositorioMesa
    {
        private readonly ContextoApi _contexto;

        public RepositorioMesa(ContextoApi contexto)
        {
            _contexto = contexto;
        }

        public async Task<Mesa> ObterMesaPorId(int idMesa)
        {
            var mesa = await _contexto.Mesas.FindAsync(idMesa);
            if (mesa != null)
            {
                return mesa;
            }
            else
            {
                throw new NullReferenceException($"Mesa com a id={idMesa} não foi encontrada!");
            }
        }

        public async Task AdicionarClienteNaMesa(int idMesa, string nomeCliente)
        {
            var mesa = await ObterMesaPorId(idMesa);
            try
            {
                mesa.AdicionarCliente(nomeCliente);
                await _contexto.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Falha ao adicionar cliente");
            }
        }

        public async Task RemoverClienteNaMesa(int idMesa)
        {
            var mesa = await ObterMesaPorId(idMesa);
            try
            {
                mesa.RemoverCliente();
                await _contexto.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Falha ao adicionar cliente");
            }
        }

        public async Task AdicionarContaNaMesa(int idMesa, decimal valorDaConta)
        {
            var mesa = await ObterMesaPorId(idMesa);
            try
            {
                mesa.AdicionarNaConta(valorDaConta);
                await _contexto.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Falha ao adicionar conta ao cliente");
            }

        }
        public async Task ZerarContaDaMesa(int idMesa)
        {
            try
            {
                var mesa = await ObterMesaPorId(idMesa);
                mesa.ZerarConta();
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}