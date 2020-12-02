namespace TemplateMicroservice.Infrastructure.Model
{
    public interface IDbEntity<out TDomainEntity>
    {
        TDomainEntity ConvertToDomainEntity();
    }
}