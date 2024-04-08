using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SiteVinho.ViewModels;

namespace SiteVinho.Controllers
{
    public class VinhoControllercs : Controller
    {


        static IEnumerable<Vinho> vinhos = null;

        private async Task <IEnumerable<Vinho>> GetVinhos()
        {
            IEnumerable<Vinho> vinhos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7215/api/Vinho");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                
                string token = await AutenticacaoUsuario.getToken();
                
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);


                HttpResponseMessage response = await client.GetAsync(client.BaseAddress.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var conteudo = response.Content.ReadAsStringAsync().Result;

                    vinhos = JsonConvert.DeserializeObject<Vinho[]>(conteudo);
                }

            }
            return  vinhos;
        }




        // GET: VinhoControllercs
        public ActionResult Index()
        {
            return View();
        }

        // GET: VinhoControllercs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VinhoControllercs/Create
        public async Task<ActionResult> Create()
        {
            vinhos = await GetVinhos();
            ViewBag.cod_vinho = new SelectList
            (
                vinhos
            );

            return View(vinhos);
        }

        // POST: VinhoControllercs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VinhoControllercs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VinhoControllercs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VinhoControllercs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VinhoControllercs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
