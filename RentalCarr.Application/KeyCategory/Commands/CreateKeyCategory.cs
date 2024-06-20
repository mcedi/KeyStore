using AutoMapper;
using KeyStore.Application.Common.Dto.Category;
using MediatR;
using MongoDB.Entities;

namespace KeyStore.Application.Category.Commands;

public record CreateKeyCategory(CreateKeyCategoryDto Category) : IRequest<string>;

public class CreateCategoryCommandHandler : IRequestHandler<CreateKeyCategory, string>
{
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateKeyCategory request, CancellationToken cancellationToken)
    {
        var keyCategory = _mapper.Map<KeyStore.Domain.Entities.KeyCategory>(request.Category);
        await keyCategory.SaveAsync(cancellation: cancellationToken);

        return "Key Category created successfully!";
    }
}