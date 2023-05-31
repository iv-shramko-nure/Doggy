using BLL.Contracts;
using Braintree;
using Common.Configs;

namespace BLL.Services
{
    public class BraintreeService : IBraintreeService
    {
        private readonly BraintreeGatewayConfig _braintreeGatewayConfig;

        public BraintreeService(
            BraintreeGatewayConfig braintreeGatewayConfig)
        {
            _braintreeGatewayConfig = braintreeGatewayConfig;
        }

        public IBraintreeGateway CreateGateway()
        {
            var newGateway = new BraintreeGateway()
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = _braintreeGatewayConfig.MerchantId,
                PublicKey = _braintreeGatewayConfig.PublicKey,
                PrivateKey = _braintreeGatewayConfig.PrivateKey
            };

            return newGateway;
        }

        public IBraintreeGateway GetGateway()
        {
            return CreateGateway();
        }
    }
}
