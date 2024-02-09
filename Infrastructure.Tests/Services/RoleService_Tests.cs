using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Services;

public class RoleService_Tests
{
    private readonly DataContextDbFirst _context = new DataContextDbFirst(new DbContextOptionsBuilder<DataContextDbFirst>()
   .UseInMemoryDatabase($"{Guid.NewGuid()}")
   .Options);

    [Fact]
    public void CreateRole_ShouldCreateNewRole_ReturnNotNull()
    {
        //Arrange
        var roleRepository = new RoleRepository(_context);
        var roleService = new RoleService(roleRepository);

        string roleName = "Test";

        //Act
        var result = roleService.CreateRole(roleName);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void CreateRole_ShouldNotCreateNewRole_ReturnNull()
    {
        //Arrange
        var roleRepository = new RoleRepository(_context);
        var roleService = new RoleService(roleRepository);
        string roleName = "Test";
        roleService.CreateRole(roleName);

        //Act
        var result = roleService.CreateRole(roleName);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetRole_ShouldReturnRoleEntity_ReturnRoleEntity()
    {
        //Arrange
        var roleRepository = new RoleRepository(_context);
        var roleService = new RoleService(roleRepository);

        string roleName = "Test";
        roleService.CreateRole(roleName);

        //Act
        var result = roleService.GetRole(roleName);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetRoleById_ShouldReturnRoleEntity_ReturnRoleEntity()
    {
        //Arrange
        var roleRepository = new RoleRepository(_context);
        var roleService = new RoleService(roleRepository);

        string roleName = "Test";
        var role = roleService.CreateRole(roleName);

        //Act
        var result = roleService.GetRoleById(role.Id);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetRoles_ShouldReturnIEnumerableOfTypeRoleEntity_ReturnIEnumerableOfTypeRoleEntity()
    {
        //Arrange
        var roleRepository = new RoleRepository(_context);
        var roleService = new RoleService(roleRepository);

        string roleName = "Test";
        roleService.CreateRole(roleName);

        //Act
        var result = roleService.GetRoles();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Role>>(result);
    }

    [Fact]
    public void UpdateRole_ShouldUpdateRole_ReturnUpdatedRole()
    {
        //Arrange
        var roleRepository = new RoleRepository(_context);
        var roleService = new RoleService(roleRepository);

        string roleName = "Test";
        roleService.CreateRole(roleName);
     
        //Act
        var result = roleRepository.Update(x => x.RoleName == roleName, new Role { RoleName = "Updated" });

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Updated", result.RoleName);
      

    }

    [Fact]
    public void DeleteRole_ShouldDeleteRole_ReturnTrue()
    {
        //Arrange
        var roleRepository = new RoleRepository(_context);
        var roleService = new RoleService(roleRepository);

        string roleName = "Test";
        roleService.CreateRole(roleName);

        //Act
        var result = roleService.DeleteRole(roleName);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void DeleteRole_ShouldNotDeleteRole_ReturnFalse()
    {
        //Arrange
        var roleRepository = new RoleRepository(_context);
        var roleService = new RoleService(roleRepository);

        string roleName = "Test";

        //Act
        var result = roleService.DeleteRole(roleName);

        //Assert
        Assert.False(result);
    }




}
