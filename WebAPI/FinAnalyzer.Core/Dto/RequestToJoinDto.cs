using FinAnalyzer.Core.Dto.Person;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Core.Dto;

public class RequestToJoinResponse
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public PersonResponse Person { get; set; }

    public DateTime DateTime { get; set; }

    public RequestToJoinStatus Status { get; set; }
}
