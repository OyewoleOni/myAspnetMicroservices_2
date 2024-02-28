using MediatR;


namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<IEnumerable<OrderDto>>
    {
        public string Username { get; set; }

        public GetOrdersListQuery(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
