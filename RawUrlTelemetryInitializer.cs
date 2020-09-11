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
                var request = HttpContext.Current.Request;
                requestTelemetry.Properties["RawUrl"] = request.RawUrl;
                requestTelemetry.Properties["RawUrlFqdn"] = new Uri(request.Url, request.RawUrl).ToString();
            }
        }
    }
}