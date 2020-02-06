using Newtonsoft.Json;

namespace Common.Errors
{
    public class DetailBusinessError
    {
        public DetailBusinessError(string fieldCode, string detailError)
        {
            this.FieldCode = fieldCode;
            this.DetailError = detailError;
        }

        public string FieldCode { get; private set; }

        public string DetailError { get; private set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
