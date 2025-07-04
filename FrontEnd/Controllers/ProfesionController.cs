﻿using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using System.Security.Claims;

namespace FrontEnd.Controllers
{
    public class ProfesionController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public ProfesionController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = string.Empty;
            if (userIdClaim != null)
            {
                userId = userIdClaim.Value;
            }
            TotalesDTO totales = new TotalesDTO();
            totales = await _apiService.GetTotales(int.Parse(userId), HttpContext.Session.GetString("APIToken"));
            return View(totales);

        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<JsonResult> GetAllProfesiones()
        {
            List<Profesion> oLista = new List<Profesion>();
            oLista = await _apiService.GetAllProfesiones(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<JsonResult> CreateProfesion([FromBody] Profesion profesion)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (profesion.Id == 0)
                {
                    if (profesion.Descripcion != "")
                    {
                        profesion = await _apiService.AddProfesion(profesion, HttpContext.Session.GetString("APIToken"));
                        resultado = profesion.Id;
                        mensaje = "Profesión ingresada correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (profesion.Descripcion != "")
                    {
                        await _apiService.UpdateProfesion(profesion.Id, profesion, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Profesión Modificado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje += ex.Message;

            }
            return Json(new { resultado = resultado, mensaje = mensaje });
        }

        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Details(int id)
        {

            Profesion profesion = new Profesion();
            profesion = await _apiService.GetProfesionById(id, HttpContext.Session.GetString("APIToken"));
            return View(profesion);
        }

        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Delete(int id)
        {
            Profesion profesion = new Profesion();
            profesion = await _apiService.GetProfesionById(id, HttpContext.Session.GetString("APIToken"));
            return View(profesion);
        }

        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]

        public async Task<JsonResult> DeleteProfesion([FromBody] Profesion profesion)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteProfesion(profesion.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Profesión eliminada correctamente";
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje += ex.Message;

            }
            return Json(new { resultado = resultado, mensaje = mensaje });
        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
