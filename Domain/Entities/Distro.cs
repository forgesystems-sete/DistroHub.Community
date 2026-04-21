using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DistroHub.Domain.Enums;

namespace DistroHub.Domain.Entities;

public class Distro
{
    public int    Id          { get; set; }

    [Required, MaxLength(100)]
    public string Name        { get; set; } = string.Empty;

    [Required, MaxLength(110)]
    public string Slug        { get; set; } = string.Empty;

    [MaxLength(600)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? LogoUrl    { get; set; }

    [MaxLength(200)]
    public string? WebsiteUrl { get; set; }

    [MaxLength(60)]
    public string? LatestVersion { get; set; }

    [MaxLength(60)]
    public string? BasedOn    { get; set; }

    public DesktopEnv   DesktopEnv   { get; set; } = DesktopEnv.Other;
    public PackageManager PackageManager { get; set; } = PackageManager.Other;
    public InitSystem   InitSystem   { get; set; } = InitSystem.Systemd;
    public Category     Category     { get; set; } = Category.General;
    public Arch[]       Architectures { get; set; } = [Arch.X86_64];

    public bool         IsRolling    { get; set; }
    public bool         IsFeatured   { get; set; }

    // Standard+
    public int          DownloadCount { get; set; }
    public DateTime     CreatedAt    { get; set; } = DateTime.UtcNow;
    public DateTime     UpdatedAt    { get; set; } = DateTime.UtcNow;

    // Pro only
    [MaxLength(300)]
    public string? IsoDownloadUrl { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public decimal? IsoSizeMb { get; set; }

    [NotMapped]
    public string Label => $"{Name} {LatestVersion}".Trim();
}
