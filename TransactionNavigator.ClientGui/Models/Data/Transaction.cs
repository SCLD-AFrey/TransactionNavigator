using System;
using JsonBase;

namespace TransactionNavigator.ClientGui.Models.Data;

public class Transaction : JsonItem
{
    public decimal Amount { get; set; } = 0;
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public TransactionType? TransactionType { get; set; } = new TransactionType();
    public TransactionCategory? TransactionCategory { get; set; } = new TransactionCategory();
    public User? AddedBy { get; set; } = new User();
}