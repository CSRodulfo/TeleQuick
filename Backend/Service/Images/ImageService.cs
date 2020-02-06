using Business.IRestServices;
using Business.MedicalInsurances;
using Business.Medicines;
using IServices.MedicalInsurances;
using IServices.Medicines;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Services.Images
{
    public class ImageService : IImageService
    {
        private readonly IImageRestService imageRestService;

        public ImageService(IImageRestService imageRestService)
        {
            this.imageRestService = imageRestService;
        }

        public async Task<byte[]> Get(string id)
        {
            var image = await this.imageRestService.Get(id);
            if (image == null)
            {
                var assembly = typeof(ImageService).GetTypeInfo().Assembly;
                var resources = assembly.GetManifestResourceNames();
                Stream resource = assembly.GetManifestResourceStream("Services.Resources.medical_default.jpg");
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = resource.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }

                    return ms.ToArray();
                }
            }

            return image;
        }
    }
}
