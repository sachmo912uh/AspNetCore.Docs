# Overview

The app has been deployed and a DevOps pipeline has been established. Now that the application is in production, it's important to understand how to monitor and troubleshoot the app.

In this section, you'll complete the following tasks:

* Find basic monitoring and troubleshooting data in the Azure portal
* Learn how Azure Monitor provides a deeper look at metrics across all Azure services
* Connect the web app with Application Insights for application profiling
* Turn on logging and learn where to download logs
* Stream logs in real time
* Learn where to set up near real time alerts
* Learn about remote debugging Azure App Service web apps.

## Basic monitoring and troubleshooting

App Service Web Apps are easily monitored in real time. The Azure portal renders metrics in easy-to-understand charts and graphs.

1. Sign into the [Azure portal](https://portal.azure.com).

2. In the **Search** bar at the top of the page, type the first few characters of your web app's name. There will be multiple results with the same name. Select the *App Service* result with the globe icon.
    
    ![Search results](./media/05/search.png)

3. The *Overview* tab displays useful "at-a-glance" information, including graphs displaying recent metrics.

    ![Overview panel](./media/05/overview.png)

    * **Http 5xx**: Count of server-side errors, usually exceptions in ASP.NET Core code.
    * **Data In**: Data ingress coming into your web app.
    * **Data Out**: Data egress from your web app to clients.
    * **Requests**: Count of HTTP requests.
    * **Average Response Time**: Average time for the web app to respond to HTTP requests.

    Several self-service tools for troubleshooting and optimization are also found on this page.

    ![Self-service tools](./media/05/wizards.png)
    
    * **Diagnose and solve problems** is a self-service troubleshooter that presents a step-by-step wizard for diagnosing and resolving issues.
    * **Application Insights** is for profiling performance and application behavior, and is discussed later in this section.
    * **App Service Advisor** makes recommendations to tune your app experience.

## Advanced monitoring

[Azure Monitor](https://docs.microsoft.com/azure/monitoring-and-diagnostics/) is the centralized service for monitoring all metrics and setting alerts across Azure services. Within Azure Monitor, administrators can granularly track performance and identify trends. Each Azure service exposes its own [set of metrics](https://docs.microsoft.com/azure/monitoring-and-diagnostics/monitoring-supported-metrics#microsoftwebsites-excluding-functions) to Azure Monitor.

## Profiling with Application Insights

[Application Insights](https://docs.microsoft.com/azure/application-insights/app-insights-overview) is an Azure service for analyzing the performance and stability of web apps and how users use them. The data from Application Insights is broader and deeper than that of Azure Monitor, and can provide developers and administrators with key information for improving apps. Application Insights can be added to an Azure App Service resource without code changes.

1. From the *Overview* tab, select the *Application Insights* tile.
    
    ![Application Insights tile](./media/05/app-insights.png)

2. Select **Create new resource**. Leave the default name and select the location for the Application Insights resource. It doesn't need to be the same location as your web app.
    
    ![Application Insights setup](./media/05/new-app-insights.png)

3. For **Runtime/Framework**, select **ASP.NET Core**. Accept the default settings.
4. Select **OK**. If prompted to confirm, select **Continue**.
5. After the resource has been created, click the name of Application Insights resource to navigate directly to the Application Insights blade.
    
        ![New Application Insights resource is ready](./media/05/new-app-insights-done.png)

As the app is used, data accumulates in near real time. Select **Refresh** to reload the blade with new data.

Application Insights provides useful server-side information with no additional configuration, but to get the most value from Application Insights, be sure to [instrument your application with the Application Insights SDK](https://docs.microsoft.com/azure/application-insights/app-insights-asp-net-core). When properly configured, Application Insights provides end-to-end monitoring across the web server and browser. For more information, see the [Application Insights documentation](https://docs.microsoft.com/azure/application-insights/app-insights-overview).


## Logging

Web server and application logs are disabled by default in Azure App Service, but are easily enabled.

1. Navigate to the App Service blade.
2. In the menu to the left, scroll down to the **Monitoring** section and select **Diagnostics logs**.
    
    ![Diagnostic logs link](./media/05/logging.png)

3. Turn on **Application Logging (Filesystem). If prompted, click the box to install the extensions to enable application logging in the web app.
4. Set **Web server logging** to **File System**.
5. Set the desired **Retention Period**.
6. Select **Save**.

ASP.NET Core and web server (App Service) logs will be generated for the web app. They can be downloaded using the FTP/FTPS information displayed (the password is the same as the deployment credentials in Chapter 3). The logs can also be [downloaded with PowerShell or Azure CLI](https://docs.microsoft.com/azure/app-service/web-sites-enable-diagnostic-log#download). Logs can also be [viewed in Application Insights](https://docs.microsoft.com/azure/app-service/web-sites-enable-diagnostic-log#how-to-view-logs-in-application-insights).


## Log streaming

Application and web server logs can be streamed in real time through the portal.

1. Navigate to the App Service blade.
2. In the menu to the left, scroll down to the **Monitoring** section and select **Log stream**.
    
    ![Log stream link](./media/05/log-stream.png)

Logs can also be [streamed via Azure CLI or Azure PowerShell](, including through the Cloud Shell.
 
## Alerts

Azure Monitor also provides [real time alerts](https://docs.microsoft.com/azure/monitoring-and-diagnostics/insights-alerts-portal) based on metrics, administrative events, and other criteria.

> *Note: Currently alerting on web app metrics is only available in the Alerts (classic) service.*

The [Alerts (classic) service](https://docs.microsoft.com/azure/monitoring-and-diagnostics/monitor-quick-resource-metric-alert-portal) can be found in Azure Monitor or under the **Monitoring** section of the App Service blade.

![Alerts (classic) link](./media/05/alerts.png)

## Live debugging

Azure App Service can be [debugged remotely with Visual Studio](https://docs.microsoft.com/azure/app-service/web-sites-dotnet-troubleshoot-visual-studio#remotedebug) when logs don't provide enough information. However, this requires the application to be compiled with debug symbols, and should not be done in production except as a last resort.

## Conclusion

In this section, you completed the following tasks:

* Find basic monitoring and troubleshooting data in the Azure portal
* Learn how Azure Monitor provides a deeper look at metrics across all Azure services
* Connect the web app with Application Insights for application profiling
* Turn on logging and learn where to download logs
* Stream logs in real time
* Learn where to set up near real time alerts
* Learn about remote debugging Azure App Service web apps.

## Additional reading

* [Monitor Azure web app performance with Application Insights](https://docs.microsoft.com/azure/application-insights/app-insights-azure-web-apps)
* [Enable diagnostics logging for web apps in Azure App Service](https://docs.microsoft.com/en-us/azure/app-service/web-sites-enable-diagnostic-log)
* [Troubleshoot a web app in Azure App Service using Visual Studio](https://docs.microsoft.com/azure/app-service/web-sites-dotnet-troubleshoot-visual-studio)
* [Create classic metric alerts in Azure Monitor for Azure services - Azure portal](https://docs.microsoft.com/azure/monitoring-and-diagnostics/insights-alerts-portal)
