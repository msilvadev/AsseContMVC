using AsseContMVC.Models;
using System;
using System.IO;
using System.Web.Mvc;

namespace AsseContMVC.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Upload arq)
        {
            try
            {
                string nomeArquivo = "";
                if (arq.Arquivo.ContentLength > 0)
                {
                    nomeArquivo = Path.GetFileName(arq.Arquivo.FileName);
                    var caminho = Path.Combine(Server.MapPath("~/Uploads"), nomeArquivo);
                    arq.Arquivo.SaveAs(caminho);
                }
                ViewBag.Messagem = "Arquivo: " + nomeArquivo + ", enviado com sucesso.";
            }
            catch(Exception ex)
            {
                ViewBag.Messagem = "Erro: " + ex.Message;
            }
            return View();
        }
    }
}