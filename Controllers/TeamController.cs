using ESportsManager.Models;
using ESportsManager.Repositories;
using System.Web.Mvc;

namespace ESportsManager.Controllers {
    public class TeamController : Controller {
        private readonly TeamRepository _repo = new TeamRepository();

        public ActionResult Index() {
            var teams = _repo.GetAll();
            return View(teams);
        }

        public ActionResult Details(int id) {
            var team = _repo.GetById(id);
            if (team == null)
                return HttpNotFound();

            return View(team);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Team team) {
            if (!ModelState.IsValid)
                return View(team);

            _repo.Add(team);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id) {
            var team = _repo.GetById(id);
            if (team == null)
                return HttpNotFound();

            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(Team team) {
            if (!ModelState.IsValid)
                return View(team);

            _repo.Update(team);
            return RedirectToAction("Index");
        }
    }
}
