using JsonBase;
using System;
using TransactionNavigator.ClientGui.Services;
namespace TransactionNavigator.ClientGui.Models.Data;

public class TransactionBase : JsonBase<Transaction>
{
    public TransactionBase(string p_folder) : base(p_folder) { }
}