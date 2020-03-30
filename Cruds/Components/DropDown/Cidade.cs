using Apresentation.Models.Cidade;
using AutoMapper;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Components.DropDown
{
    public class Cidade : ViewComponent
    {
        private readonly ICidadeService _cidadeService;
        private readonly IMapper _mapper;
        public Cidade(ICidadeService cidadeService, IMapper mapper)
        {
            _cidadeService = cidadeService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var paises = _mapper.Map<IEnumerable<CidadeViewModelGet>>(await _cidadeService.GetAllAsync());
            return View("Cidade", paises);
        }
    }
}
