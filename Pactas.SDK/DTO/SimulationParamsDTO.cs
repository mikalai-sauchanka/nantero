using System;

namespace Pactas.SDK.DTO
{
    public class SimulationParamsDTO
    {
        public DateTime From { get; set; }
        public DateTime Until { get; set; }

        public string ContractId { get; set; }
    }
}
