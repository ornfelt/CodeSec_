# CodeSec - Final version for school project

- Dotnet project using entity framework 2.2

# Notes

- You need to create the databases "CodeSec" and "CodeSecIdentity" and do:
- (Not sure if this is correct, might need to follow the instructions on EnvironmentCrime...
- dotnet ef --startup-project ./ migrations add CodeSecMigration -c ApplicationDbContext
- dotnet ef --startup-project ./ migrations add CodeSecMigration -c AppIdentityDbContext
- dotnet ef database update --context ApplicationDbContext
- dotnet ef database update --context AppIdentityDbContext