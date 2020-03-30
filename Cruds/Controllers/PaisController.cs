using Apresentation.Models.Pais;
using AutoMapper;
using Crosscuting.Notification;
using Domain.DTO;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Controllers
{
    [Controller]
    [Route("pais")]
    
    public class PaisController : Controller
    {
        private readonly IPaisService _paisService;
        private readonly INotify _notify;
        private readonly IMapper _mapper;
        public PaisController(IPaisService paisService, INotify notify, IMapper mapper)
        {
            _paisService = paisService;
            _notify = notify;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] PaisViewModelPost pais)
        {
            pais.Descricao = pais?.Descricao?.Trim();
            if (!await _paisService.AddAsync(_mapper.Map<PaisDTO>(pais))) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return Json(new { success = true, mensagem = "País inserido com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromForm] PaisViewModelPost pais)
        {
            pais.Descricao = pais.Descricao.Trim();
            if (!await _paisService.UpdateAsync(_mapper.Map<PaisDTO>(pais))) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return Json(new { success = true, mensagem = "País editado com sucesso." });
        }

        [HttpGet("listar")]
        public async Task<ActionResult> Get()
        
        {
            var result = await _paisService.GetAllAsync();
            if (_notify.HaveNotification()) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return View("_Lista", _mapper.Map<IEnumerable<PaisViewModelGet>>(result.AsEnumerable()));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]Guid id)
        {
            if (!await _paisService.RemoveAsync(id)) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return Json(new { success = true, mensagem = "País removido com sucesso." });
        }
    }
}