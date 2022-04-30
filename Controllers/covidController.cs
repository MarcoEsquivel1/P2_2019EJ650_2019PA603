using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2019EJ650_2019PA603.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_2019EJ650_2019PA603.Controllers
{
    public class covidController : Controller
    {
        private readonly dbContext _contexto;
        public covidController(dbContext miContexto)
        {
            this._contexto = miContexto;
        }
        public IActionResult Index()
        {
            //Departamentos lista
            IEnumerable<Departamentos> listaDepartamentos = from d in _contexto.departamentos select d;

            List<SelectListItem> ComboDepartamentosValores = new List<SelectListItem>();
            foreach (Departamentos departamento in listaDepartamentos)
            {
                SelectListItem miOpcion = new SelectListItem
                {
                    Text = departamento.departamento,
                    Value = departamento.departamentoId.ToString()
                };

                ComboDepartamentosValores.Add(miOpcion);
            }

            //Departamentos lista
            IEnumerable<Generos> listaGeneros = from g in _contexto.generos select g;

            List<SelectListItem> ComboGenerosValores = new List<SelectListItem>();
            foreach (Generos genero in listaGeneros)
            {
                SelectListItem miOpcion = new SelectListItem
                {
                    Text = genero.genero,
                    Value = genero.generoId.ToString()
                };

                ComboGenerosValores.Add(miOpcion);
            }

            ViewBag.ComboDepartamentosValores = ComboDepartamentosValores;
            ViewBag.ComboGenerosValores = ComboGenerosValores;

            //Lista de casos
            IEnumerable<Casos> casos = (from c in _contexto.casos
                                        join d in _contexto.departamentos on c.departamentoId equals d.departamentoId
                                        join g in _contexto.generos on c.generoId equals g.generoId
                                        select new Casos
                                        {
                                            departamento = d.departamento,
                                            genero = g.genero,
                                            confirmados = c.confirmados,
                                            recuperados = c.recuperados,
                                            fallecidos = c.fallecidos,
                                        });

            return View(casos);
        }

        public IActionResult postNew(Casos datosForm)
        {
            var nuevo = new Casos() {
                casoId = datosForm.casoId,
                departamentoId = datosForm.departamentoId,
                generoId = datosForm.generoId,
                confirmados = datosForm.confirmados,
                recuperados = datosForm.recuperados,
                fallecidos = datosForm.fallecidos
            };

            _contexto.casos.Add(nuevo);
            _contexto.SaveChanges();
            return RedirectToAction("Index", "covid");
        }
    }
}
