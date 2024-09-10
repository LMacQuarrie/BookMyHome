using System.Data;
using BookMyHome.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookMyHome.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookMyHomeContext _db;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(BookMyHomeContext db)
    {
        _db = db;
    }

    void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
    {
        if (_db.Database.CurrentTransaction != null) return;
        _transaction = _db.Database.BeginTransaction(isolationLevel);
    }

    void IUnitOfWork.Commit()
    {
        if (_transaction == null) throw new Exception("You must call 'BeginTransaction' before Commit is called");
        _transaction.Commit();
        _transaction.Dispose();
    }

    void IUnitOfWork.Rollback()
    {
        if (_transaction == null) throw new Exception("You must call 'BeginTransaction' before Rollback is called");
        _transaction.Rollback();
        _transaction.Dispose();
    }
}