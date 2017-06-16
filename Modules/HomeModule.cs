using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using /////////NEW PROJET .Objects;


namespace /////////NEW PROJESDCDSCSDFSDS
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      // root -> list all recipes
      Get["/"] = _ => {
        List<Recipe> allRecipes = Recipe.GetAll();
        return View["index.cshtml", allRecipes];
      };

      // thing add
      Get["/THINGS/add"] = _ => {
        Post[""]
      };

    }
  }
}
