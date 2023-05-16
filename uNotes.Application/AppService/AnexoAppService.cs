using AutoMapper;
using Microsoft.AspNetCore.Http;
using uNotes.Application.AppService.Interface;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.UoW;
using Minio;
using System.Reactive.Linq;
using uNotes.Domain.Services;
using Minio.DataModel;
using System.IO;
using System.Net.Mime;

namespace uNotes.Application.AppService
{
    public class AnexoAppService : IAnexoAppService
    {
        private readonly IMinioClient _minio;
        private readonly MinioService _minioService;
        private const string _bucketName = "images";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnexoAppService(IMinioClient minio, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _minio = minio;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _minioService = new MinioService(_minio);
        }

        public async Task<IEnumerable<string>> ObterArquivosPorDocumento(Guid documentoId)
        {
            return await _minioService.GetFolderFilesAsync(_bucketName, documentoId.ToString());
        }

        public async Task<string> SalvarArquivo(IFormFile arquivo, Guid documentoId)
        {
            await _minio.PutObjectAsync(new PutObjectArgs()
                                            .WithStreamData(arquivo.OpenReadStream())
                                            .WithObjectSize(arquivo.Length)
                                            .WithObject(arquivo.FileName)
                                            .WithFileName(documentoId.ToString())
                                            .WithBucket(_bucketName)
                                            .WithContentType("image/png"));
            return "Arquivo Salvo";
        }

    }
}
