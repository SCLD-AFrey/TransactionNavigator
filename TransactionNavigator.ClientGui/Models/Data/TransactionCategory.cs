using System;
using JsonBase;
using TransactionNavigator.ClientGui.Services;

namespace TransactionNavigator.ClientGui.Models.Data;

public class TransactionCategory : JsonItem
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsLocked { get; set; } = false;
}