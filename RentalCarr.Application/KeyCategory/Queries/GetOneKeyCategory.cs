using AutoMapper;
using KeyStore.Application.Common.Dto.Category;
using KeyStore.Application.Common.Exceptions;
using MediatR;

using MongoDB.Entities;

namespace KeyStore.Application.Category.Queries;

public record GetOneKeyCategory(string KeyCategoryId) : IRequest<KeyCategoryInformationDto>;

public class GetOneKeyCategoryQueryHandler : IRequestHandler<GetOneKeyCategory, KeyCategoryInformationDto>
{
    private readonly IMapper _mapper;

    public GetOneKeyCategoryQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<KeyCategoryInformationDto> Handle(GetOneKeyCategory request, CancellationToken cancellationToken)
    {
        var keyCategory = await DB.Find<KeyStore.Domain.Entities.KeyCategory>()
            .OneAsync(request.KeyCategoryId, cancellation: cancellationToken);

        if (keyCategory == null)
            throw new NotFoundException("Key Category not found!");

        return _mapper.Map<KeyCategoryInformationDto>(keyCategory);
    }
};
