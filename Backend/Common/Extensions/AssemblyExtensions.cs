using System;
using System.IO;
using System.Reflection;
using Common.Errors;

namespace Common.Extensions
{
    public static class AssemblyExtensions
    {
        public static string GetAssemblyDate()
        {
            string date;
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var fileInfo = new FileInfo(assembly.Location);
                var writeTime = fileInfo.LastWriteTime;
                date = string.Format("{0} {1}", writeTime.ToShortDateString(), writeTime.ToShortTimeString());
            }
            catch (Exception)
            {
                throw new BusinessException(BusinessErrorCode.ErrorInterno, "No se pudo obtener fecha de ultimo build");
            }

            return date;
        }
    }
}
