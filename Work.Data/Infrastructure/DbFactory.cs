namespace Work.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private WorkDbContext db;

        public WorkDbContext Init()
        {
            return db ?? (db = new WorkDbContext());
        }

        protected override void DisposeCore()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }
    }
}