using System;
using System.Web.Mvc;
using Service.Reference;
using Service.Sample;
using Web.MVC.Models;

namespace Web.MVC.Controllers
{
    public class SampleController : Controller
    {
        private readonly StatusService _statusService;
        private readonly UserService _userService;
        private readonly SampleService _sampleService;

        public SampleController()
        {
            _statusService = new StatusService();
            _userService = new UserService();
            _sampleService = new SampleService();
        }

        public ActionResult Index(int page = 1, int size = 10, string user = null, int? status = null, string barcode = null)
        {
            if (!_sampleService.IsValid(page, size, user, status, barcode))
            {
                TempData["ValidRequest"] = false;
                return RedirectToAction("Index", "Sample");

            }

            if (TempData["ValidRequest"] != null)
            {
                ViewBag.Success = false;
                ViewBag.Message = "Invalid Search. Default Search Applied";
            }
            
            SampleIndexModel model = new SampleIndexModel
            {
                Page = page,
                Size = size,
                User = user,
                Status = status,
                Barcode = barcode,
            };

            model.InsertRecords(_sampleService.GetSamples(page, size, user, status, barcode));
            ViewBag.StatusList = new SelectList(_statusService.GetStatusList(), "Key", "Value");
            var pageCount = (double) _sampleService.GetTotalCount(user, status, barcode)/size;
            ViewBag.PageCount = Convert.ToInt32(Math.Ceiling(pageCount));

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Index(SampleIndexModel model)
        {
            return RedirectToAction("Index",
                new
                {
                    page = model.Page,
                    size = model.Size,
                    user = model.User,
                    status = model.Status,
                    barcode = model.Barcode
                });
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.UsersList = new SelectList(_userService.GetUsersList(), "Key", "Value");
            ViewBag.StatusList = new SelectList(_statusService.GetStatusList(), "Key", "Value");
            var model = new SampleCreateModel();
            
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(SampleCreateModel model)
        {

            if (ModelState.IsValid)
            {
                ViewBag.Success = _sampleService.CreateSample((int)model.UserId, (int)model.StatusId, model.Barcode);

                if (ViewBag.Success == true)
                {
                    ViewBag.Message = "New Sample Created";
                    return View("Index");
                }
                else
                {
                    ViewBag.Message = "New Sample Creation Failed";
                }
            }

            ViewBag.UsersList = new SelectList(_userService.GetUsersList(), "Key", "Value");
            ViewBag.StatusList = new SelectList(_statusService.GetStatusList(), "Key", "Value");
            return View("Create", model);            
        }
    }
}