using AutoMapper;
using TrainComponent.Application.Features.TrainComponent.Commands.Create;
using TrainComponent.Application.Features.TrainComponent.Commands.Delete;
using TrainComponent.Application.Features.TrainComponent.Commands.Update;
using TrainComponent.Application.Features.TrainComponent.Queries;
using TrainComponent.Domain.Entities;

namespace TrainComponent.Application.Features.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TrainComponentNode, TrainComponentVm>().ReverseMap();

        CreateMap<TrainComponentNode, CreateComponentCommand>().ReverseMap();
        CreateMap<TrainComponentNode, UpdateComponentCommand>().ReverseMap();
        CreateMap<TrainComponentNode, DeleteComponentCommand>().ReverseMap();

    }
}
