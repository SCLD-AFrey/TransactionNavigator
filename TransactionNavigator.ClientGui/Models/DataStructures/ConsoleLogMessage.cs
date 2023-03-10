using Serilog.Events;

namespace TransactionNavigator.ClientGui.Models.DataStructures;

public class ConsoleLogMessage
{
    public LogEventLevel LogLevel { get; set; }
    public string? Text { get; set; }
}