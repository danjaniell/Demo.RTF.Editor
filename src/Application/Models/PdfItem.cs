namespace Application.Models
{
    public class PdfItem
    {
        public byte[] Bytes { get; }
        public string DataUri
        {
            get { return $"data:application/pdf;base64,{Base64}"; }
        }
        public string Base64
        {
            get { return Convert.ToBase64String(Bytes); }
        }

        public PdfItem(byte[] pdfBytes)
        {
            Bytes = pdfBytes;
        }
    }
}
