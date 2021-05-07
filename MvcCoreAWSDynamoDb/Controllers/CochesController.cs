using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSDynamoDb.Models;
using MvcCoreAWSDynamoDb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSDynamoDb.Controllers
{
    public class CochesController : Controller
    {
        ServiceAWSDynamoDb service;
        public CochesController(ServiceAWSDynamoDb service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await this.service.GetCoches()); ;
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await this.service.FindCoche(id));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeleteCoche(id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Coche car)
        {
            await this.service.CreateCoche(car);
            return RedirectToAction("Index");
        }
    }
}
