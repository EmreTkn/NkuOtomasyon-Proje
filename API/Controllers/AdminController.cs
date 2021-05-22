using API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers
{

    public class AdminController : BaseApiController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
      
        public async Task<RoleDto> CreateRole(RoleDto model) //this can be changed. Json doesnt convert to string.
        {
            var res =await _roleManager.CreateAsync(new IdentityRole(model.Name));
            if (res.Succeeded)
            {
                var data = _roleManager.Roles;
                model.Roles = data;
                return model;
            }
            return null;
        }
        
        
    }
}
