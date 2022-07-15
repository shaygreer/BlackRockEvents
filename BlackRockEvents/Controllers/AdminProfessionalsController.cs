using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackRockEvents.Data;
using BlackRockEvents.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlackRockEvents.Controllers
{
    /*This controller is only available to users in the role of Superadmin.*/
    [Authorize(Roles = "Superadmin")]
    public class AdminProfessionalsController : Controller
    {
        private readonly IProfessionalData _professionalData;
        /*This constructor for the AdminProfessionalController takes the ProfessionalData repostiory as a dependency, through dependency injection.*/
        public AdminProfessionalsController(IProfessionalData professionalData)
        {
            _professionalData = professionalData;
        }
        /*This method returns the Index View in the Views/AdminProfessionals folder, This view returns a datatable of all the professionals using the datatables plugin, which requires the GetList Endpoint. */
        public async Task<IActionResult> Index()
        {
            return View();
        }
        /*This method returns a list of all the profesisonals in the Professional table of the database via the GetList endpoint, which is in turn used in the Index view in the Views/AdminProfessionals folder
         * for the datatables plugin. */
        public ActionResult GetList() 
        {
            var proList = from p in _professionalData.Professionals.ToList()
                          select new
                          {
                              firstName = p.FirstName,
                              lastName = p.LastName,
                              profession = p.ProfessionName,
                              imageName = p.PhotoName,
                              email = p.Email,
                              phone = p.Phone,
                               proId = p.Professional_Id
                           };
            return new JsonResult(proList);
        }
        /*This method returns the View Details in the Views/AdminProfessionals/Details folder. It takes an id of a professional as a parameter and returns the professionals details in the view.*/
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professional = _professionalData.Professionals
                .FirstOrDefault(m => m.Professional_Id == id);
            if (professional == null)
            {
                return NotFound();
            }

            return View(professional);
        }
        /*This method returns an empty form requesting information details of the professional you would like to add. This method needs an option to upload an image as well. */
        public IActionResult Create()
        {
            return View();
        }
        /*This method adds the professional created to the database's Professionals table and returns the user to the Index View in Views/AdminProfessionals folder.*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Professional_Id,FirstName,LastName,ProfessionName,PhotoName,Email,Phone")] Professional professional)
        {
            if (ModelState.IsValid)
            {
                _professionalData.Add(professional);
                return RedirectToAction(nameof(Index));
            }
            return View(professional);
        }
        /*This method takes a professionals id as a parameter, and then returns the details of that professional in the Edit View in the Views/AdminProfessionals folder, the user can then edit the details of the professional.*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var professional = _professionalData.GetById(id);
            if (professional == null)
            {
                return NotFound();
            }
            return View(professional);
        }
        /*This method takes the information entered in the Edit View of the Views/AdminProfessionals folder and updates the details of the professional.If everything is valid the user is redirected to the Index View in the 
         * Views/AdminProfessionals folder. Otherwise, the user is kept on the same page with validation notifications. */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Professional_Id,FirstName,LastName,ProfessionName,PhotoName,Email,Phone")] Professional professional)
        {

            if (ModelState.IsValid)
            {
                _professionalData.Update(professional);
            
                return RedirectToAction(nameof(Index));
            }
            return View(professional);
        }
        /*This method takes a Professional's Id as a parameter and then shows those details in the Delete View in the Views/AdminProfessionals folder. */
        public IActionResult Delete(int id)
        {
            Professional professional = _professionalData.GetById(id);
            return View(professional);
        }

        /*This method takes a Professional's Id as a parameter and deletes it from the databae. It then redirects the user to the Index View in the Views/AdminProfessionals folder.*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            _professionalData.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
