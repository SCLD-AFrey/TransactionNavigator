using JsonBase;
using System;
using TransactionNavigator.ClientGui.Services;

namespace TransactionNavigator.ClientGui.Models.Data;

public class TransactionTypeBase : JsonBase<TransactionType>
{
    public TransactionTypeBase(string p_folder) : base(p_folder)
    {
        //m_commonFiles = p_commonFiles;
    }
}