using System;
using JsonBase;
using TransactionNavigator.ClientGui.Services;

namespace TransactionNavigator.ClientGui.Models.Data;

public class TransactionType : JsonItem
{
    public string Title { get; set; } = string.Empty;
    public bool IsLocked { get; set; } = false;
}