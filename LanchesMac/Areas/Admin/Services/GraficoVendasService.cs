using LanchesMac.Context;
using LanchesMac.Models;

namespace LanchesMac.Areas.Admin.Services
{
    public class GraficoVendasService
    {
        private readonly AppDbContext _context;

        public GraficoVendasService(AppDbContext context)
        {
            _context = context;
        }

        public List<LancheGrafico> GetVendasLanches(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var lanches = (from pd in _context.PedidoDetalhes
                           join l in _context.Lanches on pd.LancheId equals l.LancheId
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.LancheId, l.Nome, pd.Quantidade}
                           into g
                           select new LancheGrafico
                           {
                               LancheNome = g.Key.Nome,
                               LancheQuantidade = g.Sum(q => q.Quantidade),
                               LancheValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           }).ToList();
             
            return lanches;
        }
    }
}
