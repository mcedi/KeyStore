
using AutoMapper;
using KeyStore.Application.Common.Dto.Category;
using MediatR;
using MongoDB.Entities;
using NotFoundException = KeyStore.Application.Common.Exceptions.NotFoundException;

namespace KeyStore.Application.Category.Commands;

public record UpdateKeyCategory(UpdateKeyCategoryDto KeyCategory) : IRequest<string>;

public class UpdateKeyCategoryCommandHandler : IRequestHandler<UpdateKeyCategory, string>
{
    private readonly IMapper _mapper;

    public UpdateKeyCategoryCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<string> Handle(UpdateKeyCategory request, CancellationToken cancellationToken)
    {
        var keyCategory = await DB.Find<Domain.Entities.KeyCategory>()
            .OneAsync(request.KeyCategory.KeyCategoryId, cancellation: cancellationToken);

        if (keyCategory == null)
        {
            throw new NotFoundException("Key Category not found!");
        }

        _mapper.Map(request.KeyCategory, keyCategory);

        return "Key Category updated successfully!";
    }
}
