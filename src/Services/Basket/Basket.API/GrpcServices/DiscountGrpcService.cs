using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _grpcDiscountClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient grpcDiscountClient)
        {
            _grpcDiscountClient = grpcDiscountClient ?? throw new ArgumentNullException(nameof(grpcDiscountClient));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName };

            return await _grpcDiscountClient.GetDiscountAsync(discountRequest);
        }
    }
}
