using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace IposV3WebAPI.Services.S3
{

    public class AwsSettings
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string S3BucketName { get; set; }
    }

    public class S3Service
    {
        private AwsSettings s3Config;
        private static readonly Amazon.RegionEndpoint bucketRegion = Amazon.RegionEndpoint.USEast1;
        private static Amazon.S3.IAmazonS3 s3Client;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;



        public S3Service(
            Microsoft.Extensions.Configuration.IConfiguration configuration
            )
        {
            _configuration = configuration;
            s3Config = (_configuration.GetSection("AwsS3")).Get<AwsSettings>();
            s3Client = new Amazon.S3.AmazonS3Client(s3Config.AccessKey, s3Config.SecretKey, bucketRegion);


        }


        public Task UploadFile(System.IO.Stream file, string keyName, string filepath)
        {
            try
            {

                //TransferUtilityUploadRequest uR = new TransferUtilityUploadRequest
                //{
                //    BucketName = s3Config.S3BucketName,
                //    FilePath = filepath,
                //    Key = keyName

                //};

                var fileTransferUtility = new Amazon.S3.Transfer.TransferUtility(s3Client);
                fileTransferUtility.Upload(file, s3Config.S3BucketName, $"{filepath}/{keyName}");
            }
            catch (Amazon.S3.AmazonS3Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return Task.CompletedTask;
        }

        public async Task ReadFile(string keyName, string filepath)
        {

            using (var response = await s3Client.GetObjectAsync(s3Config.S3BucketName, $"{filepath}/{keyName}"))
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(response.ResponseStream))
                {
                    string contents = reader.ReadToEnd();
                    Console.WriteLine("Object - " + response.Key);
                    Console.WriteLine(" Contents - " + contents);
                }
            }

        }



        public async Task<byte[]> GetFileStream(string filepath)
        {

            using (var response = await s3Client.GetObjectAsync(s3Config.S3BucketName, $"{filepath}"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    response.ResponseStream.CopyTo(ms);
                    var bytes = ms.ToArray();
                    return bytes;
                }
            }

        }


        public async Task<List<string>> ListFilesInFolder(string folder, DateTime afterDateTime)
        {
            var lista = s3Client.ListObjectsAsync(s3Config.S3BucketName, folder).Result;
            var files = lista.S3Objects.Where(y => y.LastModified > afterDateTime).Select(x => x.Key);
            var archivos = files.Select(x => Path.GetFileName(x)).ToList();


            return archivos;

        }


        public async Task<bool> MoveFile(string fileName, string newFileName)
        {
            try
            {
                var sourceBucket = s3Config.S3BucketName;



                var copyObjectRequest = new Amazon.S3.Model.CopyObjectRequest()
                {
                    SourceBucket = sourceBucket,
                    DestinationBucket = sourceBucket,
                    SourceKey = fileName,
                    DestinationKey = newFileName,
                    CannedACL = S3CannedACL.PublicRead,
                    StorageClass = S3StorageClass.Standard,
                };

                var response1 = await s3Client.CopyObjectAsync(copyObjectRequest);

                var deleteObjectRequest = new Amazon.S3.Model.DeleteObjectRequest
                {
                    BucketName = sourceBucket,
                    Key = fileName
                };

                await s3Client.DeleteObjectAsync(deleteObjectRequest);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }



        public async Task<string> DownloadFile(string keyName, string filepath)
        {
            var routes = new List<string>();
            string tempDirectory = GetTemporaryDirectory();
            string temporalFileName = $"{tempDirectory}/{keyName}";
            await DownloadFile(keyName, filepath, temporalFileName);
            return tempDirectory;
        }


        public async Task<string> SimulateDownloadFile(string keyName, string filepath)
        {
            string tempDirectory = GetTemporaryDirectory();
            string temporalFileName = $"{tempDirectory}/{keyName}";

            using (var client = new System.Net.WebClient())
            {
                client.DownloadFile(new Uri(@"https://filebin.net/f4fvhnfclwtvqft9/dbftoreplicate16092022.zip"), temporalFileName);
                //client.DownloadFile(new Uri(@"https://filebin.net/f4fvhnfclwtvqft9/tables.DBF"), temporalFileName);
            }



            return tempDirectory;
        }

        public async Task DownloadFile(string keyName, string filepath, string temporalFileName)
        {

            var strObject = $"{filepath}/{keyName}";

            using (var response = await s3Client.GetObjectAsync(s3Config.S3BucketName, strObject))
            {

                using (System.IO.StreamReader reader = new System.IO.StreamReader(response.ResponseStream))
                {

                    //string contents = reader.ReadToEnd();
                    //Console.WriteLine("Object - " + response.Key);
                    //Console.WriteLine(" Contents - " + contents);

                    using (FileStream fs = new FileStream(temporalFileName, FileMode.Create, FileAccess.Write))
                    {
                        const int bufsize = 2048000;
                        byte[] buffer = new byte[bufsize];

                        int b = reader.BaseStream.Read(buffer, 0, bufsize);
                        int written = b;
                        while (b > 0)
                        {
                            fs.Write(buffer, 0, b);
                            b = reader.BaseStream.Read(buffer, 0, bufsize);
                            written += b;
                        }
                    }



                }
            }

        }


    }
}
