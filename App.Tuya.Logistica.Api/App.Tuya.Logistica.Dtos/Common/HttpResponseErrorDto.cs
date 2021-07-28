namespace App.Tuya.Logistica.Dtos.Common
{
    public class HttpResponseErrorDto : HttpResponseGenericDto
    {
        public string Detalle { get; set; }
        public string Mensaje { get; set; }
    }
}
