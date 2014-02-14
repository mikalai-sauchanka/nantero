using System;

namespace Pactas.SDK.DTO
{
    public class FileReferenceDTO
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public DateTime Uploaded { get; set; }
    }

    public class PdfSettingsDTO
    {
        public FileReferenceDTO FirstPageTemplate { get; set; }
        public FileReferenceDTO NextPagesTemplate { get; set; }
        public string FontName { get; set; }
        public bool PrintLogo { get; set; }
        public bool PrintPactasLogo { get; set; }
        public bool PrintLegalInfo { get; set; }
        public bool PrintPaymentMeans { get; set; }
        public bool PrintSenderAddress { get; set; }
        public bool PrintContactInformation { get; set; }
    }
}
