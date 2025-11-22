using System.Web.Mvc;
using ESportsManager.Repositories;
using ESportsManager.Models;

namespace ESportsManager.Controllers {
    public class PlayerController : Controller {
        private readonly PlayerRepository _repo = new PlayerRepository();
        private readonly TeamRepository _teamRepo = new TeamRepository();

        public ActionResult Index() {
            var players = _repo.GetAll();
            return View(players);
        }

        public ActionResult Details(int id) {
            var player = _repo.GetById(id);
            if (player == null)
                return HttpNotFound();

            return View(player);
        }

        public ActionResult Create() {
            ViewBag.Teams = new SelectList(_teamRepo.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Player player) {
            if (!ModelState.IsValid) {
                ViewBag.Teams = new SelectList(_teamRepo.GetAll(), "Id", "Name", player.TeamId);
                return View(player);
            }

            _repo.Add(player);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id) {
            var player = _repo.GetById(id);
            if (player == null)
                return HttpNotFound();

            ViewBag.Teams = new SelectList(_teamRepo.GetAll(), "Id", "Name", player.TeamId);
            return View(player);
        }

        [HttpPost]
        public ActionResult Edit(Player player) {
            if (!ModelState.IsValid) {
                ViewBag.Teams = new SelectList(_teamRepo.GetAll(), "Id", "Name", player.TeamId);
                return View(player);
            }

            _repo.Update(player);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) {
            var player = _repo.GetById(id);
            if (player == null)
                return HttpNotFound();

            return View(player);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id) {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
