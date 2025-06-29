namespace Chronobox.API.Contracts
{
    public record ContainersResponse(
        Guid Id,
        string Name,
        DateOnly DateOfCreation);
}
