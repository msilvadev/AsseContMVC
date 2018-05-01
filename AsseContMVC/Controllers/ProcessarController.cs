using AsseContMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace AsseContMVC.Controllers
{
    public class ProcessarController : Controller
    {
        // GET: Processar
        public ActionResult Index()
        {
            IList<String> listaArq = new List<String>();
            List<Marcacao> marcacao = new List<Marcacao>();
            
            string arquivo = @"D:\repositorio\assecont\AsseContMVCSolution\AsseContMVC\Uploads\AFD.txt";
            StreamReader arq = new StreamReader(arquivo);
            
            int acumulador = 0;

            if (!arq.EndOfStream)
            {
                
                while (!arq.EndOfStream)
                {
                    listaArq.Add(arq.ReadLine());

                    acumulador++;
                }

                for (int i=0; i<acumulador; i++)
                {
                    Marcacao marc = new Marcacao();
                    marc.TipoRegistro = listaArq[i].Substring(09, 1);

                    if (marc.TipoRegistro == "3")
                    {
                        
                        marc.TipoRegistro = listaArq[i].Substring(09, 1);

                        string nsr = listaArq[i].Substring(0, 09);
                        marc.Nsr = Convert.ToInt16(nsr);

                        marc.DataMarcacao = listaArq[i].Substring(10, 02) + "/" + listaArq[i].Substring(12, 02) + "/" + listaArq[i].Substring(14, 04);

                        marc.HoraMarcacao = listaArq[i].Substring(18, 02) + ":" + listaArq[i].Substring(20, 02);

                        string pis = listaArq[i].Substring(22, 12);
                        marc.Pis = Convert.ToInt64(pis);

                        marcacao.Add(marc);
                    }
                }
            }
            arq.Close();
            return View(marcacao);
        }
    }
}