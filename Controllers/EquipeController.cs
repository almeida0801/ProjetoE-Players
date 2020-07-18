using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoE_Players.Models;

namespace ProjetoE_Players.Controllers
{
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();

        /// <summary>
        /// Aponta a Index da minha View
        /// </summary>
        /// <returns>a própria View da Index</returns>
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll(); 
            return View();
        }

        
        /// <summary>
        /// Cadastra uma nova equipe
        /// </summary>
        /// <param name="form">Formulário de equipes</param>
        /// <returns></returns>
        // IFormCollection --> GERA DADOS DO FRONT, QUE SÃO APLICADOS NO CONTROLLER
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe equipe = new Equipe();
            equipe.IdEquipe = Int32.Parse( form["IdEquipe"] );
            equipe.Nome = form["Nome"];
            
            // Upload de Imagem
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                equipe.Imagem   = file.FileName;
            }
            else
            {
                equipe.Imagem   = "padrao.png";
            }
            // Fim - Upload de Imagem

            equipeModel.Create(equipe);

            return LocalRedirect("~/Equipe");
        }
        /// <summary>
        /// Método para excluir uma equipe
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [Route("[controller]/{id}")]
        public IActionResult Excluir(int id)
        {
            equipeModel.Delete(id);
            return LocalRedirect("~/Equipe");
        }

    }
}
