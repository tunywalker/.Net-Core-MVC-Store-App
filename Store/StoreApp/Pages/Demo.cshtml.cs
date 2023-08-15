using Entities.Models;
using StoreApp.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;


namespace StoreApp.Pages
{
    public class DemoModel : PageModel
    {
        public DemoModel()
        {
        }
        public string? FullName => HttpContext?.Session?.GetString("name");
        public void OnGet()
        {
           

        }
        public void OnPost([FromForm] string name)
        {
            //FullName=name;
            HttpContext.Session.SetString("name", name);
            //HttpContext.Session.GetJson("name");
        }

    }


}