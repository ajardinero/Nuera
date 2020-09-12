using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NueraApp.Api.ViewModel;
using NueraApp.Service.Services;

namespace NueraApp.Api.Controllers
{
    public class ContentLimitCategoriesController : Controller
    {
        private readonly IInsuranceService _insuranceService;
        private readonly IMapper _mapper;

        public ContentLimitCategoriesController(IInsuranceService insuranceService, IMapper mapper)
        {
            _insuranceService = insuranceService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ContentLimit/Categories")]
        public JsonResult Index()
        {
            var viewModel = _mapper.Map<IList<ContentLimitCategoryViewModel>>(_insuranceService.GetCategories());
            return Json(viewModel);
        }
    }
}
