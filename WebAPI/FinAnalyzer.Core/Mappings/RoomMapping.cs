using AutoMapper;
using FinAnalyzer.Common;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Core.Mappings;

public class RoomMapping : Profile
{
    public RoomMapping()
    {
        CreateMap<RoomCreateRequest, Room>();
        CreateMap<RoomUpdateRequest, Room>();
        CreateMap<Room, RoomResponse>();
        CreateMap<PaginationResponse<Room>, PaginationResponse<RoomResponse>>();
    }
}

