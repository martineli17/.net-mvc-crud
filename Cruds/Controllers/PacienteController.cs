using Apresentation.Models.Paciente;
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
    [Route("paciente")]
    public class PacienteController : Controller
    {
        private readonly IPacienteService _pacienteService;
        private readonly INotify _notify;
        private readonly IMapper _mapper;
        public PacienteController(IPacienteService pacienteService, INotify notify, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _notify = notify;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] PacienteViewModelPost paciente)
        {
            if (!await _pacienteService.AddAsync(_mapper.Map<PacienteDTO>(paciente))) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return Json(new { success = true, mensagem = "Paciente inserido com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromForm] PacienteViewModelPut paciente)
        {
            if (!await _pacienteService.UpdateAsync(_mapper.Map<PacienteDTO>(paciente))) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return Json(new { success = true, mensagem = "Paciente editado com sucesso." });
        }

        [HttpGet("listar")]
        public async Task<ActionResult> Get()
        {
            var result = await _pacienteService.GetAllAsync();
            if (_notify.HaveNotification()) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return View("_Lista", _mapper.Map<IEnumerable<PacienteViewModelGet>>(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!await _pacienteService.RemoveAsync(id)) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return Json(new { success = true, mensagem = "Paciente removido com sucesso." });
        }
    }
}