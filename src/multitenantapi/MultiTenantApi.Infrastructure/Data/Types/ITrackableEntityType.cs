namespace MultiTenantApi.Infrastructure.Data.Types
{
    public interface ITrackableEntityType
    {
        Guid CreatedBy { get; set; }
        DateTime CreatedTimestamp { get; set; }
        Guid UpdatedBy { get; set; }
        DateTime UpdatedTimestamp { get; set; }
    }
}
