namespace TeleQuick.Business.Models
{
    public partial class Concessionary
    {
        public AutopistasConstants GetAutopista()
        {
            return (AutopistasConstants)this.Id;
        }
    }
}
