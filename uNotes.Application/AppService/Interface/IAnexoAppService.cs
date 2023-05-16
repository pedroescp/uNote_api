using Microsoft.AspNetCore.Http;

namespace uNotes.Application.AppService.Interface
{
    public interface IAnexoAppService
    {
        Task<IEnumerable<string>> ObterArquivosPorDocumento(Guid documentoId);
        Task<string> SalvarArquivo(IFormFile arquivo, Guid documentoId);
    }
}
