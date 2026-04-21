using DistroHub.Application.Services;
using DistroHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DistroHub.Web.Pages.Distros;

public class DetailModel : PageModel
{
    private readonly DistroService _svc;
    public DetailModel(DistroService svc) => _svc = svc;

    public Distro? Distro { get; set; }

    public void OnGet(string slug) => Distro = _svc.GetBySlug(slug);
}
