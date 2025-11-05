#!/bin/bash

echo "=================================="
echo "Task Management App - Startup"
echo "=================================="
echo ""

# Kill all existing dotnet processes
echo "Cleaning up existing processes..."
pkill -9 -f "dotnet" 2>/dev/null
sleep 3

# Navigate to project directory
cd "/Users/aifanzenterprise/Desktop/AIFANZ ENTERPRISE/Test"

# Clean build
echo "Building application..."
/usr/local/share/dotnet/x64/dotnet clean > /dev/null 2>&1
/usr/local/share/dotnet/x64/dotnet build

if [ $? -ne 0 ]; then
    echo "❌ Build failed!"
    exit 1
fi

echo ""
echo "✅ Build successful!"
echo ""

# Run the application
cd src/TaskManagementApp.Web
echo "Starting application on http://localhost:5000"
echo ""
echo "=================================="
echo "Open your browser to:"
echo "http://localhost:5000"
echo "=================================="
echo ""
echo "Press Ctrl+C to stop the server"
echo ""

/usr/local/share/dotnet/x64/dotnet run --urls="http://localhost:5000"
