using System;
using System.Web;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace AddRawUrlToApplicationInsights
{
    public class RawUrlTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            if (telemetry is RequestTelemetry requestTelemetry)
            {
                var httpContext = HttpContext.Current;
                if (httpContext?.Request == null)
                {
                    return;
                }

                var request = httpContext.Request;
                requestTelemetry.Properties["RawUrl"] = request.RawUrl;
                requestTelemetry.Properties["RawUrlFqdn"] = new Uri(request.Url, request.RawUrl).ToString();
            }
        }
    }
}