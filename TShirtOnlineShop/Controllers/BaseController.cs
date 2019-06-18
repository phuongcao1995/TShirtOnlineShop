using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TShirtOnlineShop.Controllers
{
    public class BaseController : Controller
    {
        public static readonly PagedListRenderOptions PagedListOptions = new PagedListRenderOptions
        {
            DisplayLinkToFirstPage = PagedListDisplayMode.Never,
            DisplayLinkToLastPage = PagedListDisplayMode.Never,
            DisplayLinkToIndividualPages = true,
            DisplayLinkToNextPage = PagedListDisplayMode.Always,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            LinkToNextPageFormat = "»",
            LinkToPreviousPageFormat = "«",
        };
    }
}