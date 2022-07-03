using EfCoreGenericServicesAndSerilogBootstrapRepo.Dto;
using GenericServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EfCoreGenericServicesAndSerilogBootstrapRepo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICrudServices _crudServices;

        public IEnumerable<PersonDto> People { get; set; } = new List<PersonDto>();

        public IndexModel(ILogger<IndexModel> logger, ICrudServices crudServices)
        {
            _logger = logger;
            _crudServices = crudServices;
        }

        public void OnGet()
        {
            People = _crudServices.ReadManyNoTracked<PersonDto>().ToList();
        }

        public ActionResult OnPost()
        {
            string newName = Request.Form["name"];

            var personDto = new PersonDto { Name = newName };

            _crudServices.CreateAndSave(personDto);

            return Redirect("/Index");
        }
    }
}