using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NueraApp.Api.ViewModel;
using NueraApp.Domain.Models;
using NueraApp.Service.Services;

namespace NueraApp.Api.Controllers
{
    public class ContentLimitItemsController : Controller
    {
        private readonly IInsuranceService _insuranceService;
        private readonly IMapper _mapper;

        public ContentLimitItemsController(IInsuranceService insuranceService, IMapper mapper)
        {
            _insuranceService = insuranceService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("ContentLimit/Items")] //ContentLimit/Items?categoryId={categoryId}
        public JsonResult Index([FromQuery] int categoryId)
        {
            var viewModel = _mapper.Map<IList<ContentLimitItemViewModel>>(_insuranceService.GetContentLimitItemsBy(categoryId));
            return Json(viewModel);
        }


        [HttpPost]
        [Route("ContentLimit/Items")]
        public JsonResult Create([FromBody] ContentLimitItemViewModel contentLimitItemViewModel)
        {
            return Json(_insuranceService.AddContentLimitItem(
                   new ContentLimitItem
                   {
                       Name = contentLimitItemViewModel.Name,
                       Value = contentLimitItemViewModel.Value,
                       ContentLimitCategoryId = contentLimitItemViewModel.ContentLimitCategoryId
                   }));            
        }

        [HttpDelete]
        [Route("ContentLimit/Items/{id}")]
        public int Delete(int id)
        {
            return _insuranceService.DeleteContentLimitItem(id);
        }
    }
}
