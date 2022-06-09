using System;

namespace Work.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        WorkDbContext Init();
    }
}