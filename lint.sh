#!/usr/bin/env bash
# Run all linters for SpdxWorkflows

set -e  # Exit on error

echo "📝 Checking markdown..."
npx markdownlint-cli2 "**/*.md"

echo "🔤 Checking spelling..."
npx cspell "**/*.{cs,md,json,yaml,yml}" --no-progress

echo "📋 Checking YAML..."
yamllint -c .yamllint.yaml .

echo "✨ All linting passed!"
