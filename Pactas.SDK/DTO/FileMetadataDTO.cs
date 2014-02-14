using System;

namespace Pactas.SDK.DTO
{
    public class FileMetadataDTO
    {
        //FIXME: Needs fix in GridFS...
        public string Id { get; set; }
        public string Name { get; set; }
        public string MD5 { get; set; }
        public int Length { get; set; }
        public DateTime UploadDate { get; set; }
        public string ContentType { get; set; }
    }
}
