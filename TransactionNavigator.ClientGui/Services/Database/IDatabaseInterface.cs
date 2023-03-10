using DevExpress.Xpo;

namespace TransactionNavigator.ClientGui.Services.Database;

public interface IDatabaseInterface
{
    public IDataLayer DataLayer { get; }

    public UnitOfWork ProvisionUnitOfWork();
}