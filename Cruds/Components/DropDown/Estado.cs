using Apresentation.Models.Estado;
using AutoMapper;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apresentation.Components.DropDown
{
    public class Estado : ViewComponent
    {
        private readonly IEstadoService _estadoService;
        private readonly IMapper _mapper;
        public Estado(IEstadoService estadoService, IMapper mapper)
        {
            _estadoService = estadoService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var paises = _mapper.Map<IEnumerable<EstadoViewModelGet>>(await _estadoService.GetAllAsync());
            return View("Estado", paises);
        }
    }
}
