using Minio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uNotes.Domain.Services
{
    public class MinioService
    {
        private readonly IMinioClient _minio;

        public MinioService(IMinioClient minio)
        {
            _minio = minio;
        }

        public async Task<IEnumerable<string>> GetFolderFilesAsync(string bucketName, string folderName)
        {
            var objects = new List<string>();
            var objectsListing = _minio.ListObjectsAsync(new ListObjectsArgs()
                                            .WithBucket(bucketName)
                                            .WithRecursive(true)
                                            .WithVersions(false))
                                            .ForEachAsync(item => objects.Add(item.Key));
            return objects;
        }
    }
}
