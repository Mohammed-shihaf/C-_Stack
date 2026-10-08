#!/usr/bin/env bash
# NuGet Audit — dotnet list package --include-transitive --vulnerable --format json
# Platform tool:    dotnet-sca  (version 8.0.0)
# Registry version: dotnet list package  (SDK 8.0.0)
# S3 output:        nuget-audit/nuget-audit.json
#
# Usage: ./nuget-audit.sh <workspace_root> [output_dir]
#   workspace_root  — path to repo root (must contain .sln or .csproj)
#   output_dir      — optional; defaults to <workspace_root>/testable-output/nuget-audit/

set -euo pipefail

WORKSPACE="${1:-.}"
OUTPUT_DIR="${2:-${WORKSPACE}/testable-output/nuget-audit}"

mkdir -p "$OUTPUT_DIR"

# Locate project root
SLN=$(find "$WORKSPACE" -maxdepth 2 -name "*.sln" | head -1)
TARGET="${SLN:-$(find "$WORKSPACE" -maxdepth 3 -name "*.csproj" | head -1)}"

if [[ -z "$TARGET" ]]; then
  echo '{"error":"no_csharp_project","skipped":true}' > "$OUTPUT_DIR/nuget-audit.json"
  exit 0
fi

# Platform env
export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_NOLOGO=1
export NUGET_PACKAGES="${NUGET_PACKAGES:-/opt/wb-toolcache-nuget}"

dotnet restore "$TARGET" --nologo -v quiet 2>/dev/null || true

# Run audit — exit 0 even when vulnerabilities found (non-zero exit = parse error)
dotnet list "$TARGET" package \
  --include-transitive \
  --vulnerable \
  --format json \
  > "$OUTPUT_DIR/nuget-audit.json" 2>&1 || true

echo "NuGet audit written to: $OUTPUT_DIR/nuget-audit.json"
