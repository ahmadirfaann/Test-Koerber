#!/usr/bin/env zsh

set -euo pipefail

REPO_DIR="$(cd "$(dirname "$0")" && pwd)"
cd "$REPO_DIR"

if ! command -v dotnet >/dev/null 2>&1; then
  echo "❌ .NET SDK not found. Install .NET 8 SDK first."
  echo "   macOS (Homebrew): brew install --cask dotnet-sdk"
  exit 127
fi

echo "ℹ️ Using SDK: $(dotnet --version)"
echo "📦 Restoring packages..."
dotnet restore TaskManagementApp.sln

echo "🏗️ Building (Release)..."
dotnet build TaskManagementApp.sln -c Release

echo "🚀 Running Web app on http://localhost:5002"
dotnet run --project src/TaskManagementApp.Web/TaskManagementApp.Web.csproj --urls=http://localhost:5002