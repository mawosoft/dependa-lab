# dependa-lab

Playground for managing .NET/NuGet dependencies with GitHub *Dependabot* and *Dependency Graph*.

~~GitHub's support for *NuGet eco system* is very limited.~~

*Dependabot* and *Dependency Graph* seem to use very different logic when scanning for dependencies.
- *Dependency Graph* understands only static dependencies in `.*proj`, `packages.config`, and `.nuspec`. Workaround could probably be the new [Dependency Submission API](https://docs.github.com/en/code-security/supply-chain-security/understanding-your-software-supply-chain/using-the-dependency-submission-api)
- *Dependabot* (version updates) seems to have a wider scope and also scans typical includes like `Directory.Build.props` and even `Directory.Package.props`. See [dependabot test fixtures](https://github.com/dependabot/dependabot-core/tree/main/nuget/spec/fixtures) to get an idea.  
**TODO:** Not sure yet if it understands project structure or simply threats those files individually.

Alternatives:
- Custom solution for Dependency Alerts based on `dotnet list package`. Successfully used in a number of projects. See [sample output](https://github.com/mawosoft/dependa-lab/issues/4).
- ???
