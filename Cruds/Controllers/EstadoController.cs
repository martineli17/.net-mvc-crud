using Apresentation.Models.Estado;
using AutoMapper;
using Crosscuting.Notification;
using Domain.DTO;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Controllers
{
    [Controller]
    [Route("estado")]
    public class EstadoController : Controller
    {
        private readonly IEstadoService _estadoService;
        private readonly INotify _notify;
        private readonly IMapper _mapper;
        public EstadoController(IEstadoService estadoService, INotify notify, IMapper mapper)
        {
            _estadoService = estadoService;
            _notify = notify;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] EstadoViewModelPost estado)
        {
            estado.Descricao = estado?.Descricao?.Trim();
            if (!await _estadoService.AddAsync(_mapper.Map<EstadoDTO>(estado))) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return Json(new { success = true, mensagem = "Estado inserido com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromForm] EstadoViewModelPut estado)
        {
            estado.Descricao = estado.Descricao.Trim();
            if (!await _estadoService.UpdateAsync(_mapper.Map<EstadoDTO>(estado))) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return Json(new { success = true, mensagem = "Estado editado com sucesso." });
        }

        [HttpGet("listar")]
        public async Task<ActionResult> Get()
        {
            var result = await _estadoService.GetAllAsync();
            if (_notify.HaveNotification()) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return View("_Lista", _mapper.Map<IEnumerable<EstadoViewModelGet>>(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]Guid id)
        {
            if (!await _estadoService.RemoveAsync(id)) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return Json(new { success = true, mensagem = "Estado removido com sucesso." });
        }
    }
}