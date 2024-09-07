namespace Hospital.Core.Abstract.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken token);

        Task RollbackAsync();
    }
}
