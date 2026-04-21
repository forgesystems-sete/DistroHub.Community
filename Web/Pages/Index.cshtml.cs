using DistroHub.Application.Services;
using DistroHub.Domain.Entities;
using DistroHub.Domain.Enums;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DistroHub.Web.Pages;

public class IndexModel : PageModel
{
    private readonly DistroService _svc;
    public IndexModel(DistroService svc) => _svc = svc;

    public IEnumerable<Distro> Distros    { get; set; } = [];
    public int                 TotalCount { get; set; }
    public string?             Search     { get; set; }
    public int?                Cat        { get; set; }
    public int?                De         { get; set; }
    public int?                Pm         { get; set; }
    public bool?               Rolling    { get; set; }

    public bool HasFilters =>
        Search is not null || Cat.HasValue || De.HasValue ||
        Pm.HasValue || Rolling.HasValue;

    public void OnGet(string? q, int? cat, int? de, int? pm, bool? rolling)
    {
        Search  = q;
        Cat     = cat;
        De      = de;
        Pm      = pm;
        Rolling = rolling;

        TotalCount = _svc.GetAll().Count();
        Distros    = _svc.GetAll(
            search:  q,
            cat:     cat.HasValue ? (Category)cat.Value         : null,
            de:      de.HasValue  ? (DesktopEnv)de.Value        : null,
            pm:      pm.HasValue  ? (PackageManager)pm.Value    : null,
            rolling: rolling);
    }
}
