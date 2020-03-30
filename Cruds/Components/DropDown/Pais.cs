using Apresentation.Models.Pais;
using AutoMapper;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apresentation.Components.DropDown
{
    public class Pais : ViewComponent
    {
        private readonly IPaisService _paisService;
        private readonly IMapper _mapper;
        public Pais(IPaisService paisService, IMapper mapper)
        {
            _paisService = paisService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var paises =  _mapper.Map<IEnumerable<PaisViewModelGet>>(await _paisService.GetAllAsync());
            return View("Pais", paises);
        }

    }
}
