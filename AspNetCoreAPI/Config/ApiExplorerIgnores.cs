/*
 * AspNetCore API Template
 * (C) 2020-21 Alessio Saltarin
 * MIT LICENSE
 * 
 */

using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AspNetCoreAPI.Config
{
    public class ApiExplorerIgnores : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if (action.Controller.ControllerName.Equals("Home"))
            {
                action.ApiExplorer.IsVisible = false;
            }
        }
    }

}
