namespace Rencontrer.Consultorio.Web.Models
{
    public class LoginResponseViewModel
    {
        public int usuarioId { get; set; }
        public string nome { get; set; }
        public string token { get; set; }
        public string tipoAcesso { get; set; }
        public int empresaId { get; set; }
    }
}
