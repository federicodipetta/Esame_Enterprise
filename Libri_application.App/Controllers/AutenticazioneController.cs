﻿using Libri_application.App.Abstractions.Services;
using Libri_application.App.Factorys;
using Libri_application.App.Models.Dtos;
using Libri_application.App.Models.Exception;
using Libri_application.App.Models.Requests;
using Libri_application.App.Models.Responses;
using Libri_application.App.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Libri_application.App.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutenticazioneController : ControllerBase
    {
        private readonly IAutenticazioneService _service;
        public AutenticazioneController(IAutenticazioneService service)
        {
            _service = service;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest user)
        {
            var validator = new LoginValidator();
            var result = validator.Validate(user);
            if (!result.IsValid)
            {
                return BadRequest(Factorys.ResponseFactory.WithError(result.Errors));
            }
            try
            {
                var token = _service.Login(user.login, user.password);
                return Ok(ResponseFactory.WithSuccess(new TokenResponse(token)));
                
            } catch (MyException e)
            {
                return BadRequest(Factorys.ResponseFactory.WithError(e.Message));
            }catch(System.Exception e)
            {
                return BadRequest(Factorys.ResponseFactory.WithError(e));
            }

            
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest user)
        {
            var validator = new RegisterValidator();
            var result = validator.Validate(user);
            if (!result.IsValid)
            {
                return BadRequest(Factorys.ResponseFactory.WithError(result.Errors));
            }
            try
            {
                var token = _service.Register(user.username, user.password, user.email);
                return Ok(ResponseFactory.WithSuccess(new TokenResponse(token)));
            }
            catch (Exception e)
            {
                return BadRequest(Factorys.ResponseFactory.WithError(e));
            }
            
        }   
    }
}
