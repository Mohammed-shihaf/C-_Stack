// OpenTelemetry (.NET) 1.9.0 Bootstrap
// Platform tool   : opentelemetry-dotnet
// Exporters       : OTLP (gRPC), Jaeger (thrift HTTP), Zipkin
// Config          : .testable/otel/otel-config.json
//
// The platform runner sets:
//   OTEL_EXPORTER_OTLP_ENDPOINT   — gRPC endpoint (default: http://localhost:4317)
//   OTEL_EXPORTER_JAEGER_ENDPOINT — HTTP Thrift endpoint (default: http://localhost:14268/api/traces)
//   OTEL_EXPORTER_ZIPKIN_ENDPOINT — HTTP endpoint (default: http://localhost:9411/api/v2/spans)
//   OTEL_SPAN_EXPORT_PATH         — JSON span dump path (for S3 upload)
//   OTEL_SERVICE_NAME             — service name (default: ScholarshipCMGroups)
//
// Called from Program.cs: builder.AddOtelInstrumentation();

using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace ScholarshipCMGroups.Observability;

public static class OtelBootstrap
{
    private const string DefaultServiceName = "ScholarshipCMGroups";

    /// <summary>
    /// Registers OpenTelemetry tracing with OTLP, Jaeger, and Zipkin exporters.
    /// All exporter endpoints are read from environment variables so the platform
    /// runner can override them without code changes.
    /// </summary>
    public static IServiceCollection AddOtelInstrumentation(this IServiceCollection services)
    {
        var serviceName = Environment.GetEnvironmentVariable("OTEL_SERVICE_NAME")
                         ?? DefaultServiceName;

        services.AddOpenTelemetry()
            .ConfigureResource(r => r.AddService(serviceName))
            .WithTracing(tracing =>
            {
                tracing
                    // ── Instrumentation ────────────────────────────────────
                    .AddAspNetCoreInstrumentation(opts =>
                    {
                        opts.RecordException = true;
                    })
                    .AddHttpClientInstrumentation(opts =>
                    {
                        opts.RecordException = true;
                    })

                    // ── OTLP exporter (primary — gRPC to Jaeger / OTel collector) ──
                    .AddOtlpExporter(otlp =>
                    {
                        var endpoint = Environment.GetEnvironmentVariable(
                            "OTEL_EXPORTER_OTLP_ENDPOINT") ?? "http://localhost:4317";
                        otlp.Endpoint = new Uri(endpoint);
                        otlp.Protocol = OtlpExportProtocol.Grpc;
                    })

                    // ── Jaeger exporter (thrift HTTP — legacy collector path) ──
                    .AddJaegerExporter(jaeger =>
                    {
                        var jaegerEndpoint = Environment.GetEnvironmentVariable(
                            "OTEL_EXPORTER_JAEGER_ENDPOINT")
                            ?? "http://localhost:14268/api/traces";
                        // Jaeger exporter reads AgentHost/AgentPort or HttpEndpoint
                        jaeger.AgentHost = new Uri(jaegerEndpoint).Host;
                        jaeger.AgentPort = new Uri(jaegerEndpoint).Port;
                        jaeger.ExportProcessorType = ExportProcessorType.Simple;
                    })

                    // ── Zipkin exporter ───────────────────────────────────
                    .AddZipkinExporter(zipkin =>
                    {
                        var zipkinEndpoint = Environment.GetEnvironmentVariable(
                            "OTEL_EXPORTER_ZIPKIN_ENDPOINT")
                            ?? "http://localhost:9411/api/v2/spans";
                        zipkin.Endpoint = new Uri(zipkinEndpoint);
                    });
            });

        return services;
    }
}
