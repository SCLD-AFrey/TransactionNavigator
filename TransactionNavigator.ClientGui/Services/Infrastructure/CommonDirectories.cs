using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace TransactionNavigator.ClientGui.Services.Infrastructure;

public class CommonDirectories
{
    private readonly ILogger<CommonDirectories> m_logger;
    
    public CommonDirectories(ILogger<CommonDirectories> p_logger)
    {
        m_logger = p_logger;
        CreateFolders();
    }

    public string m_AppDataPath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), ".TransactionNavigator");
    public string m_ClientDataPath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), ".TransactionNavigator", "ClientData");
    public string m_ServerDataPath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), ".TransactionNavigator", "ServerData");
    
    private void CreateFolders()
    {
        var newDirectory = Directory.CreateDirectory(m_AppDataPath);
    }
}