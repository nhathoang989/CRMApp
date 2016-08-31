using System.Web.Http;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HCMS.API.Controllers
{
    [RoutePrefix("api/File")]
    public class FileController : BaseApiController
    {
        [Route("Upload/{type}")]
        public async Task<IHttpActionResult> Upload(string type)
        {

            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest();
            }

            string root = "";// common.getUploadFolder(type);
            var provider = new MultipartFormDataStreamProvider(root);
            var result = await Request.Content.ReadAsMultipartAsync(provider);

            //foreach (var key in provider.FormData.AllKeys)
            //{
            //    foreach (var val in provider.FormData.GetValues(key))
            //    {
            //        if (key == "companyName")
            //        {
            //            var companyName = val;
            //        }
            //    }
            //}

            // On upload, files are given a generic name like "BodyPart_26d6abe1-3ae1-416a-9429-b35f15e6e5d5"
            // so this is how you can get the original file name
            var originalFileName = GetDeserializedFileName(result.FileData.First());

            var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);
            string path = result.FileData.First().LocalFileName;
            FileStream fs = uploadedFileInfo.Create();
            //Do whatever you want to do with your file here


            return Ok(originalFileName);
        }

        private object BadRequest(HttpStatusCode unsupportedMediaType)
        {
            throw new NotImplementedException();
        }

        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        public string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }
    }
}