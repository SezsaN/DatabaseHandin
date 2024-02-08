using Infrastructure.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    internal class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Role CreateRole(string roleName)
        {
            var role = _roleRepository.GetOne(x => x.RoleName == roleName);
            if (role != null)
            {
                role = _roleRepository.Create(new Role { RoleName = roleName });
            }
            return role!;
        }

        public Role GetRole (string roleName)
        {
            var role = _roleRepository.GetOne(x => x.RoleName == roleName);
            return role;
        }

        public Role GetRoleById(int id)
        {
            var role = _roleRepository.GetOne(x => x.Id == id);
            return role;
        }

        public IEnumerable<Role> GetRoles()
        {
            var roles = _roleRepository.GetAll();
            return roles;
        }

        public Role UpdateRole(Role role)
        {
            var updatedRole = _roleRepository.Update(x => x.RoleName == role.RoleName, role);
            return updatedRole;
        }

        public bool DeleteRole(string roleName)
        {
            var role = _roleRepository.GetOne(x => x.RoleName == roleName);
            if (role != null)
            {
                _roleRepository.Delete(x => x.RoleName == roleName);
                return true;
            }
            return false;
        }
    }
}
