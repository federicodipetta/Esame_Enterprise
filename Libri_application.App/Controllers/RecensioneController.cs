﻿using Libri_application.App.Abstractions.Services;
using Libri_application.App.Factorys;
using Libri_application.App.Models.Dtos;
using Libri_application.App.Models.Requests;
using Libri_application.App.Models.Responses;
using Libri_application.App.Validators;
using Libri_application.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Libri_application.App.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RecensioneController : ControllerBase
    {
        private readonly IRecensioneService _recensioneService;

        public RecensioneController(IRecensioneService recensioneService)
        {
            _recensioneService = recensioneService;
        }

        [HttpGet]
        [Route("GetRecensione/{idL}")]
        public IActionResult GetRecensione(string idL)
        {
            var identity = this.User.Identity as ClaimsIdentity;
            var idU = int.Parse(identity.Claims.Where(c => "Id" == c.Type).FirstOrDefault().Value);
            var recensione = _recensioneService.GetRecensioneByLibro(idU , idL);
            var response = new RecensioneCompletaResonse();
            response.recensione = new RecensioneDto(recensione);
            response.libro = new LibroDto(recensione.libro);
            response.utente = new UtenteOutDto(recensione.utente);
            return Ok(ResponseFactory.WithSuccess(response));
        }

        [HttpPost]
        [Route("AddRecensione")]
        public async Task<IActionResult> AddRecensione(RecensioneRequest recensione)
        {

            var identity = this.User.Identity as ClaimsIdentity;
            var idU = int.Parse(identity.Claims.Where(c => "Id" == c.Type).FirstOrDefault().Value);
            var result = new RecensioneRequestValidator().Validate(recensione);
            if (!result.IsValid)
            {
                return BadRequest(ResponseFactory.WithError(result.Errors));
            }
            await _recensioneService.AggiungiRecensione(recensione.isbn,recensione.ToRecensione(idU));
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteRecensione")]
        public IActionResult DeleteRecensione(RecensioneDelete recensione)
        {
            var result = new RecensioneDeleteValidator().Validate(recensione);
            if (!result.IsValid)
            {
                return BadRequest(ResponseFactory.WithError(result.Errors));
            }
            var identity = this.User.Identity as ClaimsIdentity;
            var idU = int.Parse(identity.Claims.Where(c => "Id" == c.Type).FirstOrDefault().Value);
            try
            {
                _recensioneService.EliminaRecensione(recensione.ToRecensione(idU));
            }
            catch
            {
                return BadRequest(ResponseFactory.WithError("recensione non trovata"));
            }
            return Ok(ResponseFactory.WithSuccess("recensione eliminata con successo"));
        }

        [HttpGet]
        [Route("GetRecensioni")]
        public List<RecensioneRidottaDto> GetRecensioni()
        {

            var identity = this.User.Identity as ClaimsIdentity;
            var idU = int.Parse(identity.Claims.Where(c => "Id" == c.Type).FirstOrDefault().Value);
            var recensioni = _recensioneService.GetRecensioni(idU);
            return recensioni.Select(x => new RecensioneRidottaDto(x)).ToList();
        }

        [HttpPut]
        [Route("ModificaRecensione")]
        public IActionResult ModificaRecensione(RecensioneRequest recensione)
        {

            var identity = this.User.Identity as ClaimsIdentity;
            var idU = int.Parse(identity.Claims.Where(c => "Id" == c.Type).FirstOrDefault().Value);
            var result = new RecensioneRequestValidator().Validate(recensione);
            if (!result.IsValid)
            {
                return BadRequest(ResponseFactory.WithError(result.Errors));
            }
            bool a = _recensioneService.ModificaRecensione(recensione.ToRecensioneConIsbn(idU,recensione.isbn));
            return a
                ?
                Ok(ResponseFactory.WithSuccess("modifica avvenuta con successo"))
                : BadRequest(ResponseFactory.WithError("modifica non avvenuta"));
            }

    }
}
