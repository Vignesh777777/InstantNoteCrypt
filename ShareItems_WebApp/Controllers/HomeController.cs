using Microsoft.AspNetCore.Mvc;
using ShareItems_WebApp.Entities;
using ShareItems_WebApp.Services;

namespace ShareItems_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext _userContext;
        private readonly IEncryptionService _encryptionService;

        public HomeController(UserContext userContext, IEncryptionService encryptionService)
        {
            _userContext = userContext;
            _encryptionService = encryptionService;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(string Code)
        {
            if (string.IsNullOrEmpty(Code))
            {
                return View();
            }
            else
            {
                return RedirectToAction("VerifySecondaryPassword", new { Code });
            }
        }
        public IActionResult AccessToItems(string Code)
        {
            if (string.IsNullOrEmpty(Code)){
                return RedirectToAction("Index");
            }
            var entry = _userContext.UserCredentials.FirstOrDefault(x => x.code.Equals(Code));
            if (entry == null)
            {
                UserCredential model = new UserCredential()
                {
                    code = Code,
                    matter = "",
                    secondaryPassword = null,
                    dateTimes = new List<DateTime> { DateTime.Now },
                };
                _userContext.UserCredentials.Add(model);
                _userContext.SaveChanges();
                return View(model);
            }
            entry.dateTimes.Add(DateTime.Now);
            _userContext.UserCredentials.Update(entry);
            _userContext.SaveChanges();
            entry.matter = _encryptionService.DecryptData(entry.matter);
            return View(entry);
        }
        [HttpPost]
        public IActionResult Save(UserCredential model)
        {
            var entry = _userContext.UserCredentials.FirstOrDefault(x => x.code.Equals(model.code));
            if (entry != null)
            {
                entry.matter = _encryptionService.EncryptData(model.matter);
                _userContext.UserCredentials.Update(entry);
                _userContext.SaveChanges();
            }
            return RedirectToAction("AccessToItems", new { Code = model.code });
        }
        [HttpPost]
        public IActionResult CreateSecondaryLock(string Code,string Pin)
        {
            var entry = _userContext.UserCredentials.FirstOrDefault(x => x.code.Equals(Code));
            entry.secondaryPassword = _encryptionService.EncryptData(Pin);
            _userContext.Update(entry);
            _userContext.SaveChanges();
            return RedirectToAction("AccessToItems", new {Code});
        }

        public IActionResult VerifySecondaryPassword(string Code)
        {
            var entry = _userContext.UserCredentials.FirstOrDefault(x => x.code.Equals(Code));
            if (entry == null || entry.secondaryPassword == null)
            {
                return RedirectToAction("AccessToItems", new { Code });
            }
            return View("CheckSecondaryPassword",entry);
        }
        [HttpPost]
        public IActionResult CheckSecondaryPassword(string Code,string Pin)
        {
            var entry = _userContext.UserCredentials.FirstOrDefault(x => x.code.Equals(Code));
            string decryptedPin = _encryptionService.DecryptData(entry.secondaryPassword);
            if (decryptedPin.Equals(Pin))
            {
                return RedirectToAction("AccessToItems", new { Code });
            }
            return View("CheckSecondaryPassword",entry);
        }
        public IActionResult DeleteSecondaryPassword(string Code)
        {
            var entry = _userContext.UserCredentials.FirstOrDefault(x => x.code.Equals(Code));
            entry.secondaryPassword = null;
            _userContext.Update(entry);
            _userContext.SaveChanges();
            ViewBag.Message = "Secondary Password removed.";
            return RedirectToAction("AccessToItems", new { Code });
        }
        public IActionResult DestroyNote(string Code)
        {
            var entry = _userContext.UserCredentials.FirstOrDefault(x => x.code.Equals(Code));
            _userContext.UserCredentials.Remove(entry);
            _userContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult OpenActivityLog(string Code)
        {
            var entry = _userContext.UserCredentials.FirstOrDefault(x => x.code.Equals(Code));
            entry.dateTimes.Reverse();
            return View(entry);
        }
        public IActionResult ExitToAccessItems(string Code)
        {
            return RedirectToAction("AccessToItems", new { Code });
        }
        public IActionResult ExitToIndex()
        {
            return RedirectToAction("Index");
        }
    }
}
