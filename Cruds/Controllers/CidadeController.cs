using Apresentation.Models.Cidade;
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
    [Route("cidade")]
    public class CidadeController : Controller
    {
        private readonly ICidadeService _cidadeService;
        private readonly INotify _notify;
        private readonly IMapper _mapper;
        public CidadeController(ICidadeService cidadeService, INotify notify, IMapper mapper)
        {
            _cidadeService = cidadeService;
            _notify = notify;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CidadeViewModelPost cidade)
        {
            cidade.Descricao = cidade?.Descricao?.Trim();
            if (!await _cidadeService.AddAsync(_mapper.Map<CidadeDTO>(cidade))) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return Json(new { success = true, mensagem = "Cidade inserida com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromForm] CidadeDTO cidade)
        {
            cidade.Descricao = cidade.Descricao.Trim();
            if (!await _cidadeService.UpdateAsync(cidade)) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return Json(new { success = true, mensagem = "Cidade editada com sucesso." });
        }

        [HttpGet("listar")]
        public async Task<ActionResult> Get()
        {
            var result = await _cidadeService.GetAllAsync();
            if (_notify.HaveNotification()) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return View("_Lista", _mapper.Map<IEnumerable<CidadeViewModelGet>>(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!await _cidadeService.RemoveAsync(id)) return Json(new { success = false, mensagem = string.Join(".", _notify.GetNotifications().Select(n => n.ErrorMessage).FirstOrDefault()) });
            return Json(new { success = true, mensagem = "Cidade removida com sucesso." });
        }
    }
}