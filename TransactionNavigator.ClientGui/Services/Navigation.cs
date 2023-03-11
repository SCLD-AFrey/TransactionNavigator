using System;
using Microsoft.Extensions.Logging;

namespace TransactionNavigator.ClientGui.Services;

public class Navigation
{
    private readonly ILogger<Navigation> m_logger;
    private readonly IServiceProvider m_serviceProvider;

    public Navigation(ILogger<Navigation> p_logger, IServiceProvider p_serviceProvider)
    {
        m_logger = p_logger;
        m_serviceProvider = p_serviceProvider;
        m_logger.LogDebug("Initializing Navigation service");
    }

    public void SetNavigation(string p_stringParameter)
    {
        m_logger.LogDebug("Navigating to '{NavigationTarget:l}'", p_stringParameter);

        switch (p_stringParameter.ToUpper())
        {
            case "WELCOME":
                NavigateToWelcomeScreen();
                break;
            case "SETTINGS":
                NavigateToSettingsScreen();
                break;
        }
    }


    private void NavigateToWelcomeScreen()
    {
        throw new NotImplementedException();
    }
    private void NavigateToSettingsScreen()
    {
        throw new NotImplementedException();
    }
}