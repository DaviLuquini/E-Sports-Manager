using System.Web.Mvc;
using ESportsManager.ViewModels;
using ESportsManager.Repositories;

namespace ESportsManager.Controllers {
    public class HomeController : Controller {
        private readonly TeamRepository _teamRepo = new TeamRepository();
        private readonly PlayerRepository _playerRepo = new PlayerRepository();

        public ActionResult Index() {
            var vm = new HomeViewModel {
                Teams = _teamRepo.GetAll(),
                Players = _playerRepo.GetAll()
            };

            return View(vm);
        }
    }
}
