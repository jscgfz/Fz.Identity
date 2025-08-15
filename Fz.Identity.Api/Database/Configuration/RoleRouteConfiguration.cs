using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class RoleRouteConfiguration : IEntityTypeConfiguration<RoleRoute>
{
  public void Configure(EntityTypeBuilder<RoleRoute> builder)
  {
    builder.ToTable("RoleRoutes", IdentityContextSchemas.Configuration);
    builder.HasKey(row => new { row.RoleId, row.RouteId });
    builder
      .HasOne(row => row.Role)
      .WithMany(row => row.Routes)
      .HasForeignKey(row => row.RoleId)
      .OnDelete(DeleteBehavior.NoAction);
    builder
      .HasOne(row => row.Route)
      .WithMany(row => row.Roles)
      .HasForeignKey(row => row.RouteId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.ReadClaim)
      .WithMany(row => row.ReadRoutes)
      .HasForeignKey(row => row.ReadClaimId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.CreateClaim)
      .WithMany(row => row.CreateRoutes)
      .HasForeignKey(row => row.CreateClaimId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.EditClaim)
      .WithMany(row => row.EditRoutes)
      .HasForeignKey(row => row.EditClaimId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.StatusClaim)
      .WithMany(row => row.StatusRoutes)
      .HasForeignKey(row => row.StatusClaimId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.DownloadClaim)
      .WithMany(row => row.DownloadRoutes)
      .HasForeignKey(row => row.DownloadClaimId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.SpecialConditionClaim)
      .WithMany(row => row.SpecialConditionRoutes)
      .HasForeignKey(row => row.SpecialConditionClaimId)
      .OnDelete(DeleteBehavior.NoAction);

    builder
      .HasData([
        new() { RouteId = 1, RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68"), ReadClaimId = 2 },
        new() { RouteId = 2, RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68") },
        new() { RouteId = 3, RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68"), ReadClaimId = 1 },
        new() { RouteId = 4, RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68"), ReadClaimId = 2, CreateClaimId = 3, EditClaimId = 4 },
        new() { RouteId = 14, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 15, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 16, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 17, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 18, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 19, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 20, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 21, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 22, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 23, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 24, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 25, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 26, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 27, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 28, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 22, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 23, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 24, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 25, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 26, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 27, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 28, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 40, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 40, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 45, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 45, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 46, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 46, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 51, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 52, RoleId = Guid.Parse("0085E762-9A41-4867-942A-0E1B3F892E3F") },
        new() { RouteId = 53, RoleId = Guid.Parse("0085E762-9A41-4867-942A-0E1B3F892E3F") },
        new() { RouteId = 56, RoleId = Guid.Parse("0085E762-9A41-4867-942A-0E1B3F892E3F") },
        new() { RouteId = 59, RoleId = Guid.Parse("0085E762-9A41-4867-942A-0E1B3F892E3F") },
        new() { RouteId = 62, RoleId = Guid.Parse("0085E762-9A41-4867-942A-0E1B3F892E3F") },
        new() { RouteId = 52, RoleId = Guid.Parse("79DFB3C0-05C5-40C0-93F5-A9A8984DEED4") },
        new() { RouteId = 53, RoleId = Guid.Parse("79DFB3C0-05C5-40C0-93F5-A9A8984DEED4") },
        new() { RouteId = 54, RoleId = Guid.Parse("79DFB3C0-05C5-40C0-93F5-A9A8984DEED4") },
        new() { RouteId = 55, RoleId = Guid.Parse("79DFB3C0-05C5-40C0-93F5-A9A8984DEED4") },
        new() { RouteId = 56, RoleId = Guid.Parse("79DFB3C0-05C5-40C0-93F5-A9A8984DEED4") },
        new() { RouteId = 57, RoleId = Guid.Parse("79DFB3C0-05C5-40C0-93F5-A9A8984DEED4") },
        new() { RouteId = 58, RoleId = Guid.Parse("79DFB3C0-05C5-40C0-93F5-A9A8984DEED4") },
        new() { RouteId = 59, RoleId = Guid.Parse("79DFB3C0-05C5-40C0-93F5-A9A8984DEED4") },
        new() { RouteId = 61, RoleId = Guid.Parse("79DFB3C0-05C5-40C0-93F5-A9A8984DEED4") },
        new() { RouteId = 62, RoleId = Guid.Parse("79DFB3C0-05C5-40C0-93F5-A9A8984DEED4") },
        new() { RouteId = 63, RoleId = Guid.Parse("d525cf87-3c00-48dc-992d-284d2a12772f") },
        new() { RouteId = 63, RoleId = Guid.Parse("2513a3ec-519a-437c-9f47-d3ed69b5cd06") },
        new() { RouteId = 64, RoleId = Guid.Parse("2513a3ec-519a-437c-9f47-d3ed69b5cd06") },
        new() { RouteId = 65, RoleId = Guid.Parse("2513a3ec-519a-437c-9f47-d3ed69b5cd06") },
        new() { RouteId = 66, RoleId = Guid.Parse("2513a3ec-519a-437c-9f47-d3ed69b5cd06") },
        new() { RouteId = 67, RoleId = Guid.Parse("2513a3ec-519a-437c-9f47-d3ed69b5cd06") },
        new() { RouteId = 68, RoleId = Guid.Parse("2513a3ec-519a-437c-9f47-d3ed69b5cd06") },
        new() { RouteId = 69, RoleId = Guid.Parse("2513a3ec-519a-437c-9f47-d3ed69b5cd06") },
        new() { RouteId = 70, RoleId = Guid.Parse("2513a3ec-519a-437c-9f47-d3ed69b5cd06") },
        new() { RouteId = 71, RoleId = Guid.Parse("22526b31-4f44-4775-b5b4-6b07005dda60") },
        new() { RouteId = 72, RoleId = Guid.Parse("2514961B-2FB5-4494-95B9-64787B3A5CA7") },
        new() { RouteId = 73, RoleId = Guid.Parse("2514961B-2FB5-4494-95B9-64787B3A5CA7") },
        new() { RouteId = 74, RoleId = Guid.Parse("2514961B-2FB5-4494-95B9-64787B3A5CA7") },
        new() { RouteId = 75, RoleId = Guid.Parse("2514961B-2FB5-4494-95B9-64787B3A5CA7") },
        new() { RouteId = 76, RoleId = Guid.Parse("9B9D01C9-9EC8-46AE-8030-62112E045EA4") },
        new() { RouteId = 77, RoleId = Guid.Parse("9B9D01C9-9EC8-46AE-8030-62112E045EA4") },
        new() { RouteId = 78, RoleId = Guid.Parse("9B9D01C9-9EC8-46AE-8030-62112E045EA4") },
        new() { RouteId = 79, RoleId = Guid.Parse("9B9D01C9-9EC8-46AE-8030-62112E045EA4") },
        new() { RouteId = 80, RoleId = Guid.Parse("9B9D01C9-9EC8-46AE-8030-62112E045EA4") },
        new() { RouteId = 81, RoleId = Guid.Parse("9B9D01C9-9EC8-46AE-8030-62112E045EA4") },
        new() { RouteId = 76, RoleId = Guid.Parse("A1B62929-957C-4EE6-A02C-DD0AEE3555EE") },
        new() { RouteId = 77, RoleId = Guid.Parse("A1B62929-957C-4EE6-A02C-DD0AEE3555EE") },
        new() { RouteId = 78, RoleId = Guid.Parse("A1B62929-957C-4EE6-A02C-DD0AEE3555EE") },
        new() { RouteId = 79, RoleId = Guid.Parse("A1B62929-957C-4EE6-A02C-DD0AEE3555EE") },
        new() { RouteId = 80, RoleId = Guid.Parse("A1B62929-957C-4EE6-A02C-DD0AEE3555EE") },
        new() { RouteId = 81, RoleId = Guid.Parse("A1B62929-957C-4EE6-A02C-DD0AEE3555EE") },
        new() { RouteId = 82, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 83, RoleId = Guid.Parse("b3bb793d-4386-4f98-bcc0-c3844f61c9e3") },
        new() { RouteId = 84, RoleId = Guid.Parse("b3bb793d-4386-4f98-bcc0-c3844f61c9e3") },
        new() { RouteId = 72, RoleId = Guid.Parse("b3bb793d-4386-4f98-bcc0-c3844f61c9e3") },
        new() { RouteId = 73, RoleId = Guid.Parse("b3bb793d-4386-4f98-bcc0-c3844f61c9e3") },
        new() { RouteId = 85, RoleId = Guid.Parse("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5") },
        new() { RouteId = 85, RoleId = Guid.Parse("d502d91b-7514-4e87-81e5-173584c7bd4a") },
        new() { RouteId = 86, RoleId = Guid.Parse("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5") },
        new() { RouteId = 86, RoleId = Guid.Parse("d502d91b-7514-4e87-81e5-173584c7bd4a") },
        new() { RouteId = 52, RoleId = Guid.Parse("ded75b0d-570d-4687-ba95-e9348d29e37e") },
        new() { RouteId = 93, RoleId = Guid.Parse("ded75b0d-570d-4687-ba95-e9348d29e37e") },
        new() { RouteId = 94, RoleId = Guid.Parse("ded75b0d-570d-4687-ba95-e9348d29e37e") },
        new() { RouteId = 95, RoleId = Guid.Parse("ded75b0d-570d-4687-ba95-e9348d29e37e") },
        new() { RouteId = 87, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 88, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 89, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 90, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 91, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 92, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 96, RoleId = Guid.Parse("d502d91b-7514-4e87-81e5-173584c7bd4a") },
        new() { RouteId = 96, RoleId = Guid.Parse("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5") },
        new() { RouteId = 97, RoleId = Guid.Parse("d502d91b-7514-4e87-81e5-173584c7bd4a") },
        new() { RouteId = 97, RoleId = Guid.Parse("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5") },
        new() { RouteId = 23, RoleId = Guid.Parse("66551899-cf82-4548-8c4b-052745d2869a") },
        new() { RouteId = 31, RoleId = Guid.Parse("66551899-cf82-4548-8c4b-052745d2869a") },
        new() { RouteId = 32, RoleId = Guid.Parse("66551899-cf82-4548-8c4b-052745d2869a") },
        new() { RouteId = 46, RoleId = Guid.Parse("b3bb793d-4386-4f98-bcc0-c3844f61c9e3") },
        new() { RouteId = 47, RoleId = Guid.Parse("b3bb793d-4386-4f98-bcc0-c3844f61c9e3") },
        new() { RouteId = 48, RoleId = Guid.Parse("b3bb793d-4386-4f98-bcc0-c3844f61c9e3") },
        new() { RouteId = 51, RoleId = Guid.Parse("b3bb793d-4386-4f98-bcc0-c3844f61c9e3") },
        new() { RouteId = 46, RoleId = Guid.Parse("66818ace-8c12-4588-be9a-0343922e7623") },
        new() { RouteId = 47, RoleId = Guid.Parse("66818ace-8c12-4588-be9a-0343922e7623") },
        new() { RouteId = 48, RoleId = Guid.Parse("66818ace-8c12-4588-be9a-0343922e7623") },
        new() { RouteId = 49, RoleId = Guid.Parse("66818ace-8c12-4588-be9a-0343922e7623") },
        new() { RouteId = 50, RoleId = Guid.Parse("66818ace-8c12-4588-be9a-0343922e7623") },
        new() { RouteId = 51, RoleId = Guid.Parse("66818ace-8c12-4588-be9a-0343922e7623") },
        new() { RouteId = 73, RoleId = Guid.Parse("66818ace-8c12-4588-be9a-0343922e7623") },
        new() { RouteId = 74, RoleId = Guid.Parse("66818ace-8c12-4588-be9a-0343922e7623") },
        new() { RouteId = 75, RoleId = Guid.Parse("66818ace-8c12-4588-be9a-0343922e7623") },
        new() { RouteId = 98, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 99, RoleId = Guid.Parse("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5") },
        new() { RouteId = 100, RoleId = Guid.Parse("ded75b0d-570d-4687-ba95-e9348d29e37e") },
        new() { RouteId = 101, RoleId = Guid.Parse("ded75b0d-570d-4687-ba95-e9348d29e37e") },
        new() { RouteId = 102, RoleId = Guid.Parse("ded75b0d-570d-4687-ba95-e9348d29e37e") },
        new() { RouteId = 103, RoleId = Guid.Parse("ded75b0d-570d-4687-ba95-e9348d29e37e") },
        new() { RouteId = 104, RoleId = Guid.Parse("ded75b0d-570d-4687-ba95-e9348d29e37e") },
        new() { RouteId = 105, RoleId = Guid.Parse("ded75b0d-570d-4687-ba95-e9348d29e37e") },
        new() { RouteId = 106, RoleId = Guid.Parse("8B2D7CDE-FAC7-4C8F-9CC5-D3053568B300") },
        new() { RouteId = 107, RoleId = Guid.Parse("8B2D7CDE-FAC7-4C8F-9CC5-D3053568B300") },
        new() { RouteId = 108, RoleId = Guid.Parse("8B2D7CDE-FAC7-4C8F-9CC5-D3053568B300") },
        new() { RouteId = 109, RoleId = Guid.Parse("8B2D7CDE-FAC7-4C8F-9CC5-D3053568B300") },
        new() { RouteId = 110, RoleId = Guid.Parse("8B2D7CDE-FAC7-4C8F-9CC5-D3053568B300") },
        new() { RouteId = 111, RoleId = Guid.Parse("8B2D7CDE-FAC7-4C8F-9CC5-D3053568B300") },
        new() { RouteId = 112, RoleId = Guid.Parse("8B2D7CDE-FAC7-4C8F-9CC5-D3053568B300") },
        new() { RouteId = 113, RoleId = Guid.Parse("8B2D7CDE-FAC7-4C8F-9CC5-D3053568B300") },
        new() { RouteId = 114, RoleId = Guid.Parse("8B2D7CDE-FAC7-4C8F-9CC5-D3053568B300") },
        new() { RouteId = 115, RoleId = Guid.Parse("8B2D7CDE-FAC7-4C8F-9CC5-D3053568B300") },
        new() { RouteId = 116, RoleId = Guid.Parse("8B2D7CDE-FAC7-4C8F-9CC5-D3053568B300") },
        new() { RouteId = 106, RoleId = Guid.Parse("1F5C213E-78E3-41C6-AF55-D80AF0F25763") },
        new() { RouteId = 107, RoleId = Guid.Parse("1F5C213E-78E3-41C6-AF55-D80AF0F25763") },
        new() { RouteId = 110, RoleId = Guid.Parse("1F5C213E-78E3-41C6-AF55-D80AF0F25763") },
        new() { RouteId = 112, RoleId = Guid.Parse("1F5C213E-78E3-41C6-AF55-D80AF0F25763") },
        new() { RouteId = 113, RoleId = Guid.Parse("1F5C213E-78E3-41C6-AF55-D80AF0F25763") },
        new() { RouteId = 115, RoleId = Guid.Parse("1F5C213E-78E3-41C6-AF55-D80AF0F25763") },
        new() { RouteId = 117, RoleId = Guid.Parse("1F5C213E-78E3-41C6-AF55-D80AF0F25763") },
        new() { RouteId = 118, RoleId = Guid.Parse("1F5C213E-78E3-41C6-AF55-D80AF0F25763") },
        new() { RouteId = 119, RoleId = Guid.Parse("1F5C213E-78E3-41C6-AF55-D80AF0F25763") },
        new() { RouteId = 2, RoleId = Guid.Parse("8C187A8E-A65A-45A1-A29B-49C99E1B3CFF") },
        new() { RouteId = 13, RoleId = Guid.Parse("8C187A8E-A65A-45A1-A29B-49C99E1B3CFF") },
        new() { RouteId = 2, RoleId = Guid.Parse("89789F4A-570D-451D-B99B-69127421F1FE") },
        new() { RouteId = 13, RoleId = Guid.Parse("89789F4A-570D-451D-B99B-69127421F1FE") },
        new() { RouteId = 2, RoleId = Guid.Parse("228EE2E2-843E-47CC-98FF-AE78E52340B7") },
        new() { RouteId = 6, RoleId = Guid.Parse("228EE2E2-843E-47CC-98FF-AE78E52340B7") },
        new() { RouteId = 9, RoleId = Guid.Parse("228EE2E2-843E-47CC-98FF-AE78E52340B7") },
        new() { RouteId = 11, RoleId = Guid.Parse("228EE2E2-843E-47CC-98FF-AE78E52340B7") },
      ]);
  }
}
