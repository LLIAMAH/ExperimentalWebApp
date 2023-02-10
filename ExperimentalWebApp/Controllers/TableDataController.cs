using ExperimentalWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;

namespace ExperimentalWebApp.Controllers
{
    public class TableDataController : Controller
    {
        private static IList<TableData> _tableDatas = new List<TableData>()
        {
            new TableData()
            {
                Id = 1, Title = "Title 1", Status = EnumStatus.Unknown, Description = "Short description for title 1"
            },
            new TableData()
            {
                Id = 2, Title = "Title 2", Status = EnumStatus.Unknown, Description = "Short description for title 2"
            },
            new TableData()
            {
                Id = 3, Title = "Title 3", Status = EnumStatus.Unknown, Description = "Short description for title 3"
            },
            new TableData()
            {
                Id = 4, Title = "Title 4", Status = EnumStatus.Unknown, Description = "Short description for title 4"
            },
            new TableData()
            {
                Id = 5, Title = "Title 5", Status = EnumStatus.Unknown, Description = "Short description for title 5"
            },
            new TableData()
            {
                Id = 6, Title = "Title 6", Status = EnumStatus.Unknown, Description = "Short description for title 6"
            },
        };

        public IActionResult Index()
        {
            var view = new TableDataView();
            view.Data.AddRange(_tableDatas);

            return View(view);
        }

        public PartialViewResult GetTableBody()
        {
            return PartialView("PartialTableData", _tableDatas);
        }

        public JsonResult GetTableJson()
        {
            return Json(_tableDatas);
        }

        [HttpPost]
        public JsonResult PostItem(string title, string status, string description)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(description))
                return Json(false);

            var exists = _tableDatas.FirstOrDefault(o => o.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (exists != null)
                return Json(false);

            var newItem = new TableData
            {
                Id = _tableDatas.Max(o => o.Id) + 1,
                Title = title,
                Description = description,
                Status = TryParseStatus(status),
                DateUpdated = null
            };

            _tableDatas.Add(newItem);

            return Json(true);
        }

        private EnumStatus TryParseStatus(string status)
        {
            try
            {
                return Enum.Parse<EnumStatus>(status, true);
            }
            catch
            {
                return EnumStatus.Unknown;
            }
        }
    }
}
