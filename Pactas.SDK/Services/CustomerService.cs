using Pactas.SDK.DTO;
using Pactas.SDK.DTO.SelfService;

namespace Pactas.SDK.Services
{
    public class CustomerService : ServiceBase<CustomerReadDTO, CustomerDTO>
    {
        public CustomerService(PactasApi api)
            : base(api, "customers/:id")
        {
        }
    }

    public class OrderService : ServiceBase<OrderReadDTO, OrderDTO>
    {
        public OrderService(PactasApi api)
            : base(api, "order/:id")
        {
        }
    }

    /// <summary>
    /// Not sure about the design of dependent components yet. However, since instantiating
    /// a class like this is practically for free, that might be a good idea since it saves
    /// us from passing the objects to every call (and hence, from modifying the signature)
    /// </summary>
    public class MeteredUsageService : ServiceBase<MeteredUsageReadDTO, MeteredUsageDTO>
    {
        private readonly string url;
        protected override string _urlFormatContext { get { return url; } }

        public MeteredUsageService(PactasApi api, string contractId)
            : base(api, "contracts/:contractId/usage/:id")
        {

            // metered usage service (constructor)
            // .../:contractId/:id --> ../1231432/:id


            // TODO: Test
            // Should make replace :contractId with the contract's actual id
            url = FormatUrl("contracts/:contractId/usage/:id", new { contractId = contractId});
        }
    }

    public class ContractService : ServiceBase<ContractReadDTO, ContractDTO>
    {
        public ContractService(PactasApi api)
            : base(api, "contracts/:id")
        {
        }
    }

    public class WebhookService : ServiceBase<HookReadDTO, HookDTO>
    {
        public WebhookService(PactasApi api)
            : base(api, "webhooks/:id")
        {
        }
    }
}
