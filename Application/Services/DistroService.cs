using DistroHub.Domain.Entities;
using DistroHub.Domain.Enums;
using DistroHub.Infrastructure.Data;

namespace DistroHub.Application.Services;

/// <summary>COMMUNITY: read-only service over JSON data.</summary>
public class DistroService
{
    private readonly JsonDistroRepository _repo;
    public DistroService(JsonDistroRepository repo) => _repo = repo;

    public IEnumerable<Distro> GetAll(
        string?       search  = null,
        Category?     cat     = null,
        DesktopEnv?   de      = null,
        PackageManager? pm    = null,
        bool?         rolling = null)
    {
        var q = _repo.GetAll();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim().ToLower();
            q = q.Where(d => d.Name.ToLower().Contains(s) || d.Description.ToLower().Contains(s));
        }
        if (cat     is not null) q = q.Where(d => d.Category      == cat);
        if (de      is not null) q = q.Where(d => d.DesktopEnv    == de);
        if (pm      is not null) q = q.Where(d => d.PackageManager == pm);
        if (rolling is not null) q = q.Where(d => d.IsRolling      == rolling);
        return q.OrderBy(d => d.Name);
    }

    public Distro?              GetBySlug(string slug)  => _repo.GetBySlug(slug);
    public IEnumerable<Distro>  GetFeatured()           => _repo.GetFeatured();
}
