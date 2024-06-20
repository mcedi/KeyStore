using AutoMapper;
using KeyStore.Application.Common.Dto.Category;
using MediatR;
using MongoDB.Entities;

namespace KeyStore.Application.Category.Queries;

public record GetAllKeyCategories : IRequest<List<KeyCategoryInformationDto>>;

public class GetAllKeysCategoriesQueryHandler : IRequestHandler<GetAllKeyCategories, List<KeyCategoryInformationDto>>
{
    private readonly IMapper _mapper;

    public GetAllKeysCategoriesQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<List<KeyCategoryInformationDto>> Handle(GetAllKeyCategories request, CancellationToken cancellationToken)
    {
        var keyCategories = await DB.Find<KeyStore.Domain.Entities.KeyCategory>()
            .ManyAsync(cat => cat.Active == true, cancellationToken);

        return _mapper.Map<List<KeyCategoryInformationDto>>(keyCategories);
    }
}
