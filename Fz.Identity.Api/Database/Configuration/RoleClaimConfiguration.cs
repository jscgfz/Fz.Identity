using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
  public void Configure(EntityTypeBuilder<RoleClaim> builder)
  {
    builder.ToTable("RoleClaims", IdentityContextSchemas.Auth);
    builder
      .HasIndex(builder => new { builder.RoleId, builder.ClaimId })
      .IsUnique();
    builder
      .HasOne(builder => builder.Role)
      .WithMany(builder => builder.RoleClaims)
      .HasForeignKey(builder => builder.RoleId);
    builder
      .HasOne(builder => builder.Claim)
      .WithMany(builder => builder.RoleClaims)
      .HasForeignKey(builder => builder.ClaimId);
    builder
      .HasData([
        new RoleClaim { Id = 1, RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68"), ClaimId = 1 },
        new RoleClaim { Id = 2, RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68"), ClaimId = 2 },
        new RoleClaim { Id = 3, RoleId = Guid.Parse("89789f4a-570d-451d-b99b-69127421f1fe"), ClaimId = 3 },
        new RoleClaim { Id = 4, RoleId = Guid.Parse("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"), ClaimId = 3 },
        new RoleClaim { Id = 5, RoleId = Guid.Parse("228ee2e2-843e-47cc-98ff-ae78e52340b7"), ClaimId = 4 },
        new RoleClaim { Id = 6, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 87 },
        new RoleClaim { Id = 7, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 88 },
        new RoleClaim { Id = 8, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 89 },
        new RoleClaim { Id = 9, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 90 },
        new RoleClaim { Id = 10, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 91 },
        new RoleClaim { Id = 11, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 92 },
        new RoleClaim { Id = 12, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 93 },
        new RoleClaim { Id = 13, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 94 },
        new RoleClaim { Id = 14, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 95 },
        new RoleClaim { Id = 15, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 96 },
        new RoleClaim { Id = 16, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 97 },
        new RoleClaim { Id = 17, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 98 },
        new RoleClaim { Id = 18, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 99 },
        new RoleClaim { Id = 19, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 100 },
        new RoleClaim { Id = 20, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 101 },
        new RoleClaim { Id = 21, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 102 },
        new RoleClaim { Id = 22, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 103 },
        new RoleClaim { Id = 23, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 104 },
        new RoleClaim { Id = 24, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 105 },
        new RoleClaim { Id = 25, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 106 },
        new RoleClaim { Id = 26, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 107 },
        new RoleClaim { Id = 27, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 108 },
        new RoleClaim { Id = 28, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 109 },
        new RoleClaim { Id = 29, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 110 },
        new RoleClaim { Id = 30, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 111 },
        new RoleClaim { Id = 31, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 112 },
        new RoleClaim { Id = 32, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 113 },
        new RoleClaim { Id = 33, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 114 },
        new RoleClaim { Id = 34, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 115 },
        new RoleClaim { Id = 35, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 116 },
        new RoleClaim { Id = 36, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 117 },
        new RoleClaim { Id = 37, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 118 },
        new RoleClaim { Id = 38, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 119 },
        new RoleClaim { Id = 39, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 120 },
        new RoleClaim { Id = 40, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 121 },
        new RoleClaim { Id = 41, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 123 },
        new RoleClaim { Id = 42, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 124 },
        new RoleClaim { Id = 43, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 125 },
        new RoleClaim { Id = 44, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 126 },
        new RoleClaim { Id = 45, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 127 },
        new RoleClaim { Id = 46, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 128 },
        new RoleClaim { Id = 47, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 129 },
        new RoleClaim { Id = 48, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 130 },
        new RoleClaim { Id = 49, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 131 },
        new RoleClaim { Id = 50, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 132 },
        new RoleClaim { Id = 51, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 133 },
        new RoleClaim { Id = 52, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 134 },
        new RoleClaim { Id = 53, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 135 },
        new RoleClaim { Id = 54, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 136 },
        new RoleClaim { Id = 55, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 137 },
        new RoleClaim { Id = 56, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 138 },
        new RoleClaim { Id = 57, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 139 },
        new RoleClaim { Id = 58, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 140 },
        new RoleClaim { Id = 59, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 141 },
        new RoleClaim { Id = 60, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 142 },
        new RoleClaim { Id = 61, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 143 },
        new RoleClaim { Id = 62, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 144 },
        new RoleClaim { Id = 63, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 145 },
        new RoleClaim { Id = 64, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 146 },
        new RoleClaim { Id = 65, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 147 },
        new RoleClaim { Id = 66, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 148 },
        new RoleClaim { Id = 67, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 149 },
        new RoleClaim { Id = 68, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 150 },
        new RoleClaim { Id = 69, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 151 },
        new RoleClaim { Id = 70, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 152 },
        new RoleClaim { Id = 71, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 153 },
        new RoleClaim { Id = 72, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 154 },
        new RoleClaim { Id = 73, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 155 },
        new RoleClaim { Id = 74, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 156 },
        new RoleClaim { Id = 75, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 157 },
        new RoleClaim { Id = 76, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 158 },
        new RoleClaim { Id = 77, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 159 },
        new RoleClaim { Id = 78, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 160 },
        new RoleClaim { Id = 79, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 161 },
        new RoleClaim { Id = 80, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 162 },
        new RoleClaim { Id = 81, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 163 },
        new RoleClaim { Id = 82, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 164 },
        new RoleClaim { Id = 83, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 165 },
        new RoleClaim { Id = 84, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 166 },
        new RoleClaim { Id = 85, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 167 },
        new RoleClaim { Id = 86, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 168 },
        new RoleClaim { Id = 87, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 169 },
        new RoleClaim { Id = 88, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 170 },
        new RoleClaim { Id = 89, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 171 },
        new RoleClaim { Id = 90, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 172 },
        new RoleClaim { Id = 91, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 173 },
        new RoleClaim { Id = 92, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 174 },
        new RoleClaim { Id = 93, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 175 },
        new RoleClaim { Id = 94, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 176 },
        new RoleClaim { Id = 95, RoleId = Guid.Parse("BC59A574-4972-41D7-92A9-FDFBEF4AAD8A"), ClaimId = 177 },
      ]);
  }     
}       
        