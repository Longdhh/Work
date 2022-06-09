namespace Work.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}