using Microsoft.AspNetCore.Mvc;
using Basics.Models;
namespace Basics.Controllers
{


    public class EmployeeController:Controller
    {
      public IActionResult Index1()
      {
        string message =$"Hello WOrld. {DateTime.Now.ToString()}";
        return View("Index1",message);
      }
      public ViewResult Index2()
      {
        var names = new String[]
        {
          "Ahmet",
          "Mehmet",
          "Can"
        };
        return View(names);
      }
      
     public IActionResult Index3()
      {

            var list = new List<Employee>()
              {
                new Employee(){id=1,FirstName="Tuna",LastName="GÜL", Age=25},
                new Employee(){id=2,FirstName="Çiço",LastName="Sinirligil", Age=3},
                new Employee(){id=3,FirstName="Paşa",LastName="Özelkedigilleri", Age=3}
              };
            return View("Index3",list);
      }

        
    }

}