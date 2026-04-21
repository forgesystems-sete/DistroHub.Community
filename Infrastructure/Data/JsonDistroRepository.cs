using System.Text.Json;
using DistroHub.Domain.Entities;
using Microsoft.AspNetCore.Hosting;

namespace DistroHub.Infrastructure.Data;

/// <summary>
/// COMMUNITY: reads distros.json at startup, in-memory, read-only.
/// Limits to 15 distros for demonstration.
/// </summary>
public class JsonDistroRepository
{
    private readonly IReadOnlyList<Distro> _distros;

    public JsonDistroRepository(IWebHostEnvironment env)
    {
        var path = Path.Combine(env.ContentRootPath, "Infrastructure", "Data", "distros.json");
        if (!File.Exists(path)) { _distros = new List<Distro>(); return; }

        var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var all = JsonSerializer.Deserialize<List<Distro>>(File.ReadAllText(path), opts)
                   ?? new List<Distro>();
        _distros = all.Take(15).ToList();   // ⬅️ LIMITE DE 15 DISTROS
    }

    public IEnumerable<Distro> GetAll()       => _distros;
    public Distro? GetBySlug(string slug)     => _distros.FirstOrDefault(d =>
        string.Equals(d.Slug, slug, StringComparison.OrdinalIgnoreCase));
    public IEnumerable<Distro> GetFeatured()  => _distros.Where(d => d.IsFeatured);
}
