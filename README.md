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

## Tests

### Sample1

Contains:
- Version as property defined in Directory.Build.Props, used in Directory.Package.Props
- PackageVersion in Directory.Package.Props
- Multiple outdated as version property and literals in Directory.Package.Props
- Deprecated top-level (direct) dependency in Directory.Package.Props
- Multiple deprecated and vulnerable transitive (indirect) dependencies

Results
- Dependabot Version Updates
  - Recognizes all outdated top-level dependencies, even correctly updates the version property definition.
  - Not yet tested: `VersionOverride` attribute, `GlobalPackageReference`
- Dependabot Alerts
  - Does **NOT** recognize deprecated top-level dependency
  - Does **NOT** recognize vulnerable/deprecated transitive dependencies
- Dependency Graph
  - Does **NOT** recognize any version numbers at all

### Sample2

Contains
- Literal versions in *.csproj files, including outdated, deprecated, and vulnerable top-level dependencies
- Multiple deprecated and vulnerable transitive dependencies

Results
- Dependabot Version Updates
  - Recognizes all outdated top-level dependencies
- Dependabot Alerts
  - Does recognize vulnerable top-level dependency
  - Does **NOT** recognize deprecated top-level dependency
  - Does **NOT** recognize vulnerable/deprecated transitive dependencies
- Dependency Graph
  - Recognizes all top-level dependency versions
  - Does **NOT** recognize any transitive dependency versions
