#!/usr/bin/env zsh

set -euo pipefail

REPO_DIR="$(cd "$(dirname "$0")" && pwd)"
cd "$REPO_DIR"

# Find dotnet, fallback to common install path if not on PATH
DOTNET_CMD="dotnet"
if ! command -v dotnet >/dev/null 2>&1; then
  if [[ -x "/usr/local/share/dotnet/dotnet" ]]; then
    DOTNET_CMD="/usr/local/share/dotnet/dotnet"
    echo "⚠️ .NET SDK not found on PATH; using $DOTNET_CMD"
  else
    echo "❌ .NET SDK not found. Install .NET 8 SDK first."
    echo "   macOS (Homebrew): brew install --cask dotnet-sdk"
    exit 127
  fi
fi

echo "ℹ️ Using SDK: $($DOTNET_CMD --version)"
echo "📦 Restoring packages..."
$DOTNET_CMD restore TaskManagementApp.sln

echo "🏗️ Building (Release)..."
$DOTNET_CMD build TaskManagementApp.sln -c Release -v minimal

echo "🚀 Running Web app on http://localhost:5050"
$DOTNET_CMD run --project src/TaskManagementApp.Web/TaskManagementApp.Web.csproj --urls=http://localhost:5050