using Entidades;

namespace Repositorios
{
    public interface IRepositorioMesa
    {
        Task AdicionarClienteNaMesa(Mesa mesa);
        Task AdicionarContaNaMesa(int idMesa, decimal valorDaConta);
        Task<Mesa> ObterMesaPorId(int idMesa);
        Task ZerarContaDaMesa(int idMesa);
        Task RemoverClienteNaMesa(int idMesa);
    }
}