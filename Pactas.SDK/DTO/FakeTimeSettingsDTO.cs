using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pactas.SDK.DTO
{
    public class FakeTimeSettingsDTO
    {
        public DateTime StartDate { get; set; }
        public PeriodDTO Period { get; set; }
        public int MinutesPerPrometheusLoop { get; set; }
        public DateTime EndDate {get; set;}
    }
}
