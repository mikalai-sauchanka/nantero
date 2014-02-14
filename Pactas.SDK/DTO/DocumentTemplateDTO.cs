using System;

namespace Pactas.SDK.DTO
{
    public class DocumentTemplateDTO
    {
        public DocumentType DocumentType { get; set; }

        public string Name { get; set; }
        public string SequenceId { get; set; }
        public LocalizableString Epilogue { get; set; }
        public LocalizableString Prologue { get; set; }
    }

    public class DocumentTemplateReadDTO : DocumentTemplateDTO
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
    }
}
