using Braintree;

namespace BLL.Contracts
{
    public interface IBraintreeService
    {
        IBraintreeGateway CreateGateway();

        IBraintreeGateway GetGateway();
    }
}
