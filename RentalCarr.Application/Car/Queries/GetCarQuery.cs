using MediatR;


namespace KeyStore.Application.Car.Queries;

public record GetCarQuery(string CarName) : IRequest<string>;

public class GetCarQueryHandler : IRequestHandler<GetCarQuery, string>
{
    public async Task<string> Handle(GetCarQuery request, CancellationToken cancellationToken)
    {
        return request.CarName;
    }
}