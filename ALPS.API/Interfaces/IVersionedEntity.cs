namespace ALPS.API.Interfaces
{
    public interface IVersionedEntity
    {
        byte[] Version { get; set; }
    }
}