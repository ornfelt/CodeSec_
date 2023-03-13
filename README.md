# CodeSec - Final version for school project

- Dotnet project using entity framework 2.2 / 7.0

# Notes

You need these nuget packages:
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Tools.Dotnet
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore
- Microsoft.AspNetCore.Razor.Design
- Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.AspNetCore.Identity
- Newtonsoft.Json

- You need to create the databases "CodeSec" and "CodeSecIdentity" and do:
- (Not sure if this is correct, might need to follow the instructions on EnvironmentCrime...
- dotnet ef --startup-project ./ migrations add CodeSecMigration -c ApplicationDbContext
- dotnet ef --startup-project ./ migrations add CodeSecMigration -c AppIdentityDbContext
- dotnet ef database update --context ApplicationDbContext
- dotnet ef database update --context AppIdentityDbContext