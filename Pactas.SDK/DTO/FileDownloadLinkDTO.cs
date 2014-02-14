using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class FileDownloadLinkDTO
    {
        public string Url { get; set; }
        public DateTime Expiry { get; set; }
    }
}
