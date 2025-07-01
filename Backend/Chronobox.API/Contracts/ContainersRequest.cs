namespace Chronobox.API.Contracts
{
    public record ContainersRequest(
        string Name,
        DateOnly DateOfCreation);
}
