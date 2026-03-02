# Security Policy

## Supported Versions

We release patches for security vulnerabilities in the following versions:

| Version   | Supported          |
| --------- | ------------------ |
| Latest    | :white_check_mark: |
| < Latest  | :x:                |

## Reporting a Vulnerability

We take the security of SpdxWorkflows seriously. If you believe you have found a
security vulnerability, please report it to us as described below.

### How to Report

**Please do not report security vulnerabilities through public GitHub issues.**

Instead, please report them using one of the following methods:

- **Preferred**: [GitHub Security Advisories][security-advisories] - Use the private vulnerability reporting feature
- **Alternative**: Contact the project maintainers directly through GitHub

Please include the following information in your report:

- **Type of vulnerability** (e.g., command injection, path traversal, etc.)
- **Full path** of source file(s) related to the vulnerability
- **Location** of the affected source code (tag/branch/commit or direct URL)
- **Step-by-step instructions** to reproduce the issue
- **Proof-of-concept or exploit code** (if possible)
- **Impact** of the issue, including how an attacker might exploit it

### What to Expect

After submitting a vulnerability report, you can expect:

1. **Acknowledgment**: We will acknowledge receipt of your vulnerability report promptly
2. **Investigation**: We will investigate the issue and determine its impact and severity
3. **Updates**: We will keep you informed of our progress as we work on a fix
4. **Resolution**: Once the vulnerability is fixed, we will:
   - Release a security patch
   - Publicly disclose the vulnerability (with credit to you, if desired)
   - Update this security policy as needed

### Response Timeline

- **Initial Response**: Promptly
- **Status Update**: Regular updates as investigation progresses
- **Fix Timeline**: Varies based on severity and complexity

### Security Update Policy

Security updates will be released as:

- **Critical vulnerabilities**: Patch release as soon as possible
- **High severity**: Patch release within 30 days
- **Medium/Low severity**: Included in the next regular release

## Security Best Practices

When using SpdxWorkflows, we recommend following these security best practices:

### Workflow Integrity

- Always specify an integrity hash when referencing a workflow by URL, to protect against tampering:

  ```yaml
  - command: run-workflow
    inputs:
      url: 'https://github.com/demaconsulting/SpdxWorkflows/blob/0.1.0/GetDotNetVersion.yaml'
      integrity: d9c80d18f6ad6b3cbd5facb28d6c5712bc68c58ace11ebf890cfc92e0857628b
  ```

- Use pinned version tags rather than `main` or `latest` when referencing workflows
- Use the latest version of SpdxWorkflows to benefit from security updates

### Dependencies

- Keep SpdxTool and its dependencies up to date
- Review the release notes for security-related updates

## Known Security Considerations

### Workflow Execution

SpdxWorkflows files are executed by SpdxTool and may invoke external programs. Users should:

- Review workflow files before use
- Ensure the integrity hash matches the expected value
- Run workflows with the minimum required permissions
- Be cautious when using workflows that invoke external tools in untrusted environments

## Security Disclosure Policy

When we receive a security bug report, we will:

1. Confirm the problem and determine affected versions
2. Audit code to find similar problems
3. Prepare fixes for all supported versions
4. Release patches as soon as possible

We will credit security researchers who report vulnerabilities responsibly. If you would like to be credited:

- Provide your name or pseudonym
- Optionally provide a link to your website or GitHub profile
- Let us know if you prefer to remain anonymous

## Third-Party Dependencies

SpdxWorkflows relies on third-party packages for its tests. We:

- Regularly update dependencies to address known vulnerabilities
- Use Dependabot to monitor for security updates
- Review security advisories for all dependencies

## Contact

For security concerns, please use [GitHub Security Advisories][security-advisories] or contact the project
maintainers directly through GitHub.

For general bugs and feature requests, please use [GitHub Issues][issues].

## Additional Resources

- [OWASP Secure Coding Practices][owasp-practices]

Thank you for helping keep SpdxWorkflows and its users safe!

[security-advisories]: https://github.com/demaconsulting/SpdxWorkflows/security/advisories
[issues]: https://github.com/demaconsulting/SpdxWorkflows/issues
[owasp-practices]: https://owasp.org/www-project-secure-coding-practices-quick-reference-guide/
