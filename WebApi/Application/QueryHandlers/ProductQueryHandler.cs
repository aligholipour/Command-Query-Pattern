using Library.Query;
using WebApi.Application.Query;

namespace WebApi.Application.QueryHandler
{
    public class ProductQueryHandler : IQueryHandler<ProductQueryRequest, ProductQueryResponse>
    {
        public async Task<ProductQueryResponse> Handle(ProductQueryRequest query)
        {
            //Query from database
            //_repository.GetProductName(query.Id);

            var productName = "Laptop";

            return new ProductQueryResponse
            {
                ProductName = productName,
            };
        }
    }
}
