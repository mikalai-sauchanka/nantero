
using System.ComponentModel.DataAnnotations;

namespace Pactas.SDK.DTO
{
    public enum SequenceType
    {
        Global = 0,
        Yearly = 1,
    }

    public class SequenceSettingsReadDTO : SequenceSettingsDTO
    {
        public string Id { get; set; }

        public string CurrentString { get; set; }
    }

    public class SequenceSettingsDTO
    {
        [EnumDataType(typeof(SequenceType))]
        public SequenceType SequenceType { get; set; }

        public string SequenceName { get; set; }
        public int DigitCount { get; set; }
        public string FormatString { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }

        public long CurrentNumber { get; set; }

        public int? Counter { get; set; }
    }
}
