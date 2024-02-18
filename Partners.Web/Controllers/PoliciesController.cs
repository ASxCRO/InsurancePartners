using Partners.Web.Data.Entities;
using Partners.Web.Data.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace Partners.Web.Controllers
{
    public class PoliciesController : Controller
    {
        private readonly IRepository<Policy> _policyRepository;

        public PoliciesController(IRepository<Policy> policyRepository)
        {
            _policyRepository = policyRepository;
        }

        // Endpoint: /Policies
        [HttpGet]
        public ActionResult Index(int id)
        {
            var policies = _policyRepository.FindAll().Where(x=>x.PartnerId == id);
            ViewBag["PartnerId"] = id;
            return View("Index", policies);
        }

        // Endpoint: /Policies/Details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var policy = _policyRepository.FindByID(id);
            if (policy == null)
                return HttpNotFound();
            return View("Details", policy);
        }

        // Endpoint: /Policies/Create
        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag["PartnerId"] = id;
            return View();
        }

        // Endpoint: /Policies/Create (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Policy policy)
        {
            if (ModelState.IsValid)
            {
                _policyRepository.Add(policy);
                return RedirectToAction("Index");
            }
            return View(policy);
        }

        // Endpoint: /Policies/Edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var policy = _policyRepository.FindByID(id);
            if (policy == null)
                return HttpNotFound();
            return View("Edit", policy);
        }

        // Endpoint: /Policies/Edit/{id} (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Policy policy)
        {
            if (ModelState.IsValid)
            {
                _policyRepository.Update(policy);
                return RedirectToAction("Index");
            }
            return View(policy);
        }

        // Endpoint: /Policies/Delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var policy = _policyRepository.FindByID(id);
            if (policy == null)
                return HttpNotFound();
            return View("Delete", policy);
        }

        // Endpoint: /Policies/Delete/{id} (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _policyRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}