using Business.Medicines;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Medicines
{
    public interface IImageService
    {
        Task<byte[]> Get(string id);
    }
}
