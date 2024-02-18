using Partners.Web.Data.Entities;
using Partners.Web.Data.Repositories;
using System.Web.Mvc;

namespace Partners.Web.Controllers
{
    public class PartnersController : Controller
    {
        private readonly IPartnerRepository _partnerRepository;

        public PartnersController(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        // Endpoint: /Partners
        [HttpGet]
        public ActionResult Index()
        {
            var partners = _partnerRepository.GetPartnersWithPolicySummary();
            return View("Index", partners);
        }

        // Endpoint: /Partners/Details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var partner = _partnerRepository.FindByID(id);
            if (partner == null)
                return HttpNotFound();
            return View("Details", partner);
        }

        // Endpoint: /Partners/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Endpoint: /Partners/Create (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Partner partner)
        {
            if (ModelState.IsValid)
            {
                _partnerRepository.Add(partner);
                return RedirectToAction("Index");
            }
            return View(partner);
        }

        // Endpoint: /Partners/Edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var partner = _partnerRepository.FindByID(id);
            if (partner == null)
                return HttpNotFound();
            return View("Edit", partner);
        }

        // Endpoint: /Partners/Edit/{id} (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Partner partner)
        {
            if (ModelState.IsValid)
            {
                _partnerRepository.Update(partner);
                return RedirectToAction("Index");
            }
            return View(partner);
        }

        // Endpoint: /Partners/Delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var partner = _partnerRepository.FindByID(id);
            if (partner == null)
                return HttpNotFound();
            return View("Delete", partner);
        }

        // Endpoint: /Partners/Delete/{id} (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _partnerRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}