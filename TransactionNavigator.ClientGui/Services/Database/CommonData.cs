using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Splat;
using TransactionNavigator.ClientGui.Models.Data;
using TransactionNavigator.ClientGui.Services.Infrastructure;

namespace TransactionNavigator.ClientGui.Services.Database;

public class CommonData
{
    private static ILogger<CommonData> m_logger;
    private readonly CommonDirectories m_commonDirectories;
    private static readonly PasswordHash m_hash = new PasswordHash();

    public CommonData(CommonDirectories p_commonDirectories, ILogger<CommonData> p_logger)
    {
        m_commonDirectories = p_commonDirectories;
        m_logger = p_logger;
        Users = new UserBase(m_commonDirectories.m_ClientDataPath);
        Transactions = new TransactionBase(m_commonDirectories.m_ClientDataPath);
        TransactionCategories = new TransactionCategoryBase(m_commonDirectories.m_ClientDataPath);
        TransactionTypes = new TransactionTypeBase(m_commonDirectories.m_ClientDataPath);
    }
    
    public static UserBase Users { get; set; }
    public static TransactionBase Transactions { get; set; }
    public static TransactionCategoryBase TransactionCategories { get; set; }
    public static TransactionTypeBase TransactionTypes { get; set; }

    public static void InitData()
    {
        InitUsers();
        InitTransactionTypes();
        InitTransactionCategories();
        InitTransactions();
    }

    private static void InitUsers()
    {
        try
        {
            if (Users.Count == 0)
            {
                m_logger.LogDebug($"Initializing Users Data");
                var admin = UserBase.DefaultUser();
                admin.Oid = Users.Count + 1;
                Users.Add(UserBase.DefaultUser());
                
                Users.Add(new User()
                {
                    UserName = "afrey",
                    Password = m_hash.GeneratePasswordHash("password", out var salt),
                    Salt = salt,
                    FirstName = "Arthur",
                    LastName = "Frey"
                });
                
                Users.Commit();
            }
        }
        catch (Exception e)
        {
            m_logger.LogError(e, "Error initializing users");
        }

    }

    private static void InitTransactionCategories()
    {
        try
        {
            if (TransactionCategories.Count == 0)
            {
                m_logger.LogDebug($"InitTransactionCategories");
                
                TransactionCategories.Add(new TransactionCategory() { Title = "Adjustment", IsLocked = true });
                TransactionCategories.Add(new TransactionCategory() { Title = "Misc", IsLocked = true });
                TransactionCategories.Add(new TransactionCategory() { Title = "Food/Grocery", IsLocked = false });
                TransactionCategories.Add(new TransactionCategory() { Title = "Utilities", IsLocked = false });
                TransactionCategories.Add(new TransactionCategory() { Title = "Home Improvement", IsLocked = false });
                TransactionCategories.Add(new TransactionCategory() { Title = "Fuel", IsLocked = false });
                TransactionCategories.Commit();
            }
        }
        catch (Exception e)
        {
            m_logger.LogError(e, "Error InitTransactionCategories: {E}", e.Message);
        }
    }

    private static void InitTransactionTypes()
    {
        try
        {
            if (TransactionTypes.Count == 0)
            {
                m_logger.LogDebug($"InitTransactionTypes");
                
                TransactionTypes.Add(new TransactionType() { Title = "Initial Deposit", IsLocked = true });
                TransactionTypes.Add(new TransactionType() { Title = "Cash", IsLocked = true });
                TransactionTypes.Add(new TransactionType() { Title = "Check", IsLocked = true });
                TransactionTypes.Add(new TransactionType() { Title = "Debit Card", IsLocked = true });
                TransactionTypes.Add(new TransactionType() { Title = "Electronic Payment", IsLocked = true });
                TransactionTypes.Commit();
            }
        }
        catch (Exception e)
        {
            m_logger.LogError(e, "Error InitTransactionTypes: {E}", e.Message);
        }
    }

    private static void InitTransactions()
    {
        try
        {
            if (Transactions.Count == 0)
            {
                
                TransactionType? transactionType = TransactionTypes.FirstOrDefault(p_x => p_x.Title == "Initial Deposit");
                TransactionCategory? transactionCategory = TransactionCategories.FirstOrDefault(p_x => p_x.Title == "Adjustment");
                User? user = Users.FirstOrDefault(p_x => p_x.UserName == "admin");
                
                
                m_logger.LogDebug($"InitTransactions");
                Transactions.Add(new Transaction()
                {
                    Amount = 100,
                    TransactionCategory = transactionCategory,
                    TransactionType = transactionType,
                    TransactionDate = DateTime.UtcNow,
                    AddedBy = user
                });
                Transactions.Commit();
            }
        }
        catch (Exception e)
        {
            m_logger.LogError(e, "Error InitTransactions");
        }
    }
}