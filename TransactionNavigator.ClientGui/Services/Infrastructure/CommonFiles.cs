using System;
using System.IO;

namespace TransactionNavigator.ClientGui.Services.Infrastructure
{
    public class CommonFiles
    {
        private readonly CommonDirectories m_commonDirectories;
    
        public CommonFiles(CommonDirectories p_commonDirectories)
        {
            m_commonDirectories = p_commonDirectories;


            ClientLogsPath = Path.Combine(m_commonDirectories.m_ClientDataPath, "logs", "events.log");
            ClientSettingsPath = Path.Combine(m_commonDirectories.m_ClientDataPath, "settings.ini");

            // ServerLogsPath = Path.Combine(m_commonDirectories.m_ServerDataPath, "logs", "events.log");
            // ServerSettingsPath = Path.Combine(m_commonDirectories.m_ServerDataPath, "settings", "settings.ini");
            // ServerDataBasePath = Path.Combine(m_commonDirectories.m_ServerDataPath, "data", "transactions.db");

            Console.WriteLine("CommonFiles");

            CreateNecessaryDirectories();
        }

        public string ClientLogsPath { get; }
        public string ClientSettingsPath { get; }
        // public string ServerLogsPath { get; }
        // public string ServerSettingsPath { get; }
        // public string ServerDataBasePath { get; }

        private void CreateNecessaryDirectories()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(ClientLogsPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(ClientSettingsPath) ?? string.Empty);
            // Directory.CreateDirectory(Path.GetDirectoryName(ServerLogsPath) ?? string.Empty);
            // Directory.CreateDirectory(Path.GetDirectoryName(ServerSettingsPath) ?? string.Empty);
            // Directory.CreateDirectory(Path.GetDirectoryName(ServerDataBasePath) ?? string.Empty);
        }
    }
}