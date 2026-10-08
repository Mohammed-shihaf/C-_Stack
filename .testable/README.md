# Testable Platform — C# Whitebox Tool Configuration
**Repo:** `deepthi-ck/C-_Stack`  
**Branch:** `Scholarship-CMGroups-negative`  
**Language:** C# / .NET 8  
**Config root:** `.testable/`

---

## Tool versions (from Whitebox_Tool_Registry_1.xlsx — C# sheet)

| Platform name | Underlying tool | Version | Category | Build? |
|---|---|---|---|---|
| `lizard` | Lizard | 1.17.10 | Cyclomatic Complexity | No |
| `roslyn-analyzers` | Microsoft.CodeAnalysis.NetAnalyzers | 8.0.0 | Linter / Code Style | Yes |
| `sonar-cs` | SonarAnalyzer.CSharp | 9.32.0.97167 | SAST — Cognitive | Yes |
| `security-code-scan` | SecurityCodeScan.VS2019 | 5.6.7 | SAST — Security | Yes |
| `jscpd-cs` | jscpd | 4.0.5 | Duplication | No |
| `semgrep-perf-static` | Semgrep (Performance Rules) | 1.0.0 | Perf Heuristics | No |
| `semgrep` | Semgrep | 1.50.0 | SAST Multi-Language | No |
| `dotnet-sca` | dotnet list package --vulnerable | 8.0.0 | SCA / CVE | No |
| `csharp-perf-dependency` | Roslyn + dotnet build | 1.0.0 | Perf Dependency | Yes |
| `presidio` | Microsoft Presidio | 2.2.354 | Compliance / PII | No |
| `semgrep-pii` | Semgrep (PII Rules) | 1.95.0 | Compliance / PII logs | No |
| `coverlet` | Coverlet | 6.0.0 | Coverage Stmt/Branch | Yes |
| `altcover` | AltCover | 8.8.0 | Coverage Path | Yes |
| `stryker-net` | Stryker.NET | 4.0.0 | Mutation Testing | Yes |
| `cs_coverage_delta` | diff-cover | 1.0.0 | Coverage Delta | No |
| `cs_all_defs_uses` | Stryker.NET Def-Use Proxy | 0.0.1 | Dataflow Coverage | No |
| `cs-side-effect` | Git Diff + AST Regex | 1.0.0 | Git Side Effects | No |
| `git_churn` | Git Log / Churn | 1.0.0 | Git Churn | No |
| `pydriller` | PyDriller | 2.7 | Git Technical Debt | No |
| **`opentelemetry-dotnet`** | **OpenTelemetry (.NET) + OTLP/Jaeger/Zipkin** | **1.9.0** | **Perf Runtime Spans** | **Yes** |

---

## OpenTelemetry (.NET) — Special Notes

The platform tool `opentelemetry-dotnet` uses the .NET 1.9.0 SDK and supports
three exporters simultaneously:

| Exporter | Protocol | Env var | Default |
|---|---|---|---|
| OTLP | gRPC | `OTEL_EXPORTER_OTLP_ENDPOINT` | `http://localhost:4317` |
| Jaeger | Thrift HTTP | `OTEL_EXPORTER_JAEGER_ENDPOINT` | `http://localhost:14268/api/traces` |
| Zipkin | HTTP | `OTEL_EXPORTER_ZIPKIN_ENDPOINT` | `http://localhost:9411/api/v2/spans` |

The platform sets `OTEL_SPAN_EXPORT_PATH` so span data is written to a JSON
file and uploaded to S3 as `opentelemetry-dotnet/otel-spans.json`.

Wired in `backend/Program.cs` via `builder.Services.AddOtelInstrumentation()`.  
Bootstrap class: `backend/Observability/OtelBootstrap.cs`.

---

## S3 output structure (per tool)

When triggered by the platform, each tool writes its output to S3 under:
```
s3://<bucket>/<tenant>/<repo>/<run_id>/<tool_name>/
```

Key files per tool:
- `lizard/lizard.xml`
- `roslyn-analyzers/roslyn-analyzers.sarif`
- `sonar-cs/sonar-cs.sarif`
- `security-code-scan/security-code-scan.sarif`
- `jscpd-cs/jscpd-report.json`
- `semgrep/semgrep-findings.json`
- `dotnet-sca/nuget-audit.json`
- `coverlet/coverage.cobertura.xml`
- `altcover/altcover.xml`
- `stryker-net/mutation-report.json`
- `pydriller/pydriller.json`
- `opentelemetry-dotnet/otel-spans.json`

---

## Config files in `.testable/`

| File | Purpose |
|---|---|
| `.testable.yml` | Master tool list with versions |
| `.testable/lizard/.lizardrc` | Lizard thresholds |
| `.testable/roslyn/Directory.Analyzers.props` | All three Roslyn analyzers |
| `.testable/roslyn/sonar-only.props` | SonarAnalyzer pass only |
| `.testable/roslyn/scs-only.props` | SecurityCodeScan pass only |
| `.testable/jscpd/jscpd.config.json` | jscpd C# config |
| `.testable/semgrep/semgrep-ruleset.yml` | Semgrep C# rules |
| `.testable/coverlet/dotnet-coverlet.runsettings` | Coverlet runsettings |
| `.testable/stryker/stryker-config.json` | Stryker.NET 4.0.0 config |
| `.testable/otel/otel-config.json` | OTel exporter config |
| `.testable/nuget-audit/nuget-audit.sh` | NuGet vulnerability audit script |
