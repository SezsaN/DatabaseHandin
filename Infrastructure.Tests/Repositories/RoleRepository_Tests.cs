using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Repositories;

public class RoleRepository_Tests
{
    private readonly DataContextDbFirst _context = new DataContextDbFirst(new DbContextOptionsBuilder<DataContextDbFirst>()
       .UseInMemoryDatabase($"{Guid.NewGuid()}")
       .Options);

    [Fact]
    public void Create_ShouldCreateSaveRecordToDatabase_ReturnRoleEntityWithId_1()
    {
        // Arrange
        var roleRepository = new RoleRepository(_context);
        var role = new Role { RoleName = "Test" };

        // Act
        var result = roleRepository.Create(role);

        // Assert
        Assert.NotNull(result);
        Assert.NotEqual(1, result.Id);
    }

    [Fact]
    public void Create_ShouldNotSaveRecordToDatabase_ReturnNull()
    {
        // Arrange
        var roleRepository = new RoleRepository(_context);
        var role = new Role();

        // Act
        var result = roleRepository.Create(role);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetAll_ShouldReturnAllRecords_ReturnIEnumerableOfTypeRoleEntity()
    {
        // Arrange
        var roleRepository = new RoleRepository(_context);
        var role = new Role { RoleName = "Test" };
        roleRepository.Create(role);

        // Act
        var result = roleRepository.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Role>>(result);
        Assert.Single(result);
    }

    [Fact]
    public void GetOne_ShouldGetOneRoleByRoleName_ReturnOneRole()
    {
        // Arrange
        var roleRepository = new RoleRepository(_context);
        var role = new Role { RoleName = "Test" };
        roleRepository.Create(role);

        // Act
        var result = roleRepository.GetOne(x => x.RoleName == role.RoleName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(role.RoleName, result.RoleName);
    }

    [Fact]
    public void GetOne_ShouldNotGetOneRoleByRoleName_ReturnNull()
    {
        // Arrange
        var roleRepository = new RoleRepository(_context);
        var role = new Role { RoleName = "Test" };


        // Act
        var result = roleRepository.GetOne(x => x.RoleName == role.RoleName);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Delete_ShouldNotFindRoleAndDeleteIt_ReturnFalse()
    {
        // Arrange
        var roleRepository = new RoleRepository(_context);
        var role = new Role { RoleName = "Test" };

        // Act
        var result = roleRepository.Delete(x => x.RoleName == role.RoleName);

        // Assert
        Assert.False(result);

    }

    [Fact]
    public void Delete_ShouldFindRoleAndDeleteIt_ReturnTrue()
    {
        // Arrange
        var roleRepository = new RoleRepository(_context);
        var role = new Role { RoleName = "Test" };
        roleRepository.Create(role);

        // Act
        var result = roleRepository.Delete(x => x.RoleName == role.RoleName);

        // Assert
        Assert.True(result);

    }

    [Fact]
    public void Update_ShouldUpdateExistingRole_ReturnUpdatedRole()
    {
        // Arrange
        var roleRepository = new RoleRepository(_context);
        var role = new Role { RoleName = "Test" };
        roleRepository.Create(role);

        // Act
        var result = roleRepository.Update(x => x.RoleName == role.RoleName, new Role { RoleName = "Updated" });

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Updated", result.RoleName);
    }

    [Fact]
    public void Update_ShouldNotUpdateExistingRole_DontReturnUpdatedRole()
    {
        // Arrange
        var roleRepository = new RoleRepository(_context);
        var role = new Role { RoleName = "Test" };
        

        // Act
        var result = roleRepository.Update(x => x.RoleName == role.RoleName, new Role { RoleName = "Updated" });

        // Assert
        Assert.Null(result);
        
    }




}
