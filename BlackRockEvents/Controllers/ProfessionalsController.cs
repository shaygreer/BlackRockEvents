using BlackRockEvents.Data;
using BlackRockEvents.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackRockEvents.Controllers
{
    [AllowAnonymous]
    public class ProfessionalsController : Controller
    {
        private readonly IProfessionalData _professionalData;
        /*This constructor takes the ProfessionalData repository as a dependency. */
        public ProfessionalsController(IProfessionalData professionalData)
        {
            _professionalData = professionalData;
        }
        /*This method returns the Index View in the Views/Professionals folder, the view contains a series of partial views called _ProfessionalCard in the Views/Shared folder. The _ProfessionalCard is a view of an individual Professionals details.*/
        public IActionResult Index(ProfessionalsListViewModel prosModel)
        {
            prosModel.Professionals = _professionalData.Professionals;
            return View(prosModel);
        }
    }
}
