using JsonBase;
using System;
using TransactionNavigator.ClientGui.Services;

namespace TransactionNavigator.ClientGui.Models.Data;

public class TransactionCategoryBase : JsonBase<TransactionCategory>
{
    public TransactionCategoryBase(string p_folder) : base(p_folder)
    {
        //m_commonFiles = p_commonFiles;
    }
}