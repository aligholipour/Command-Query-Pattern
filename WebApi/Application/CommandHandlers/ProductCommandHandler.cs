using Library.Command;
using WebApi.Application.Command;

namespace WebApi.Application.CommandHandlers
{
    public class ProductCommandHandler : ICommandHandler<ProductCommand>
    {
        public async Task Handle(ProductCommand command)
        {
            //..
        }
    }
}
