# dependa-lab

Playground for managing .NET/NuGet dependencies with GitHub *Dependabot* and *Dependency Graph*.

GitHub's support for *NuGet eco system* is very limited. It only understands static dependencies in `.*proj`, `packages.config`, and `.nuspec`.

Not supported:
- include files, e.g. Directory.Build.props
- transitive dependencies
- build variables, e.g. $(MyPackageVersion)
- NuGet package lock files (packages.lock.json)
- central package management (Directory.Package.props)  
  **EDIT** Actually, *Dependabot* offers version updates here, but *Dependency Graph* doesn't show any versions.

Alternatives:
- Custom solution for Dependency Alerts based on `dotnet list package`. Successfully used in a number of projects. See [sample output](https://github.com/mawosoft/dependa-lab/issues/4).
- Create and check-in a file format that GitHub understands.
- Use the new GitHub REST APIs (public beta) to submit dependencies.
- ???
