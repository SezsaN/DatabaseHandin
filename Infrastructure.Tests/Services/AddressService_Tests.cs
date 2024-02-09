using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Services;

public class AddressService_Tests
{
    private readonly DataContextDbFirst _context = new DataContextDbFirst(new DbContextOptionsBuilder<DataContextDbFirst>()
   .UseInMemoryDatabase($"{Guid.NewGuid()}")
   .Options);

    [Fact]
    public void CreateAddress_ShouldCreateNewAddress_ReturnNotNull()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var addressService = new AddressService(addressRepository);

        string streetName = "Test";
        string postalCode = "1234";
        string city = "Test";
        //Act
        var result = addressService.CreateAddress(streetName, city, postalCode);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void CreateAddress_ShouldNotCreateNewAddress_ReturnNull()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var addressService = new AddressService(addressRepository);
        string streetName = "Test";
        string postalCode = "1234";
        string city = "Test";
        addressService.CreateAddress(streetName, city, postalCode);

        //Act
        var result = addressService.CreateAddress(streetName, city, postalCode);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetAddressByName_ShouldReturnAddressEntity_ReturnAddressEntity()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var addressService = new AddressService(addressRepository);

        string streetName = "Test";
        string postalCode = "1234";
        string city = "Test";
        addressService.CreateAddress(streetName, city, postalCode);

        //Act
        var result = addressService.GetAddressByName(streetName, city, postalCode);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetAddressById_ShouldReturnAddressEntity_ReturnAddressEntity()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var addressService = new AddressService(addressRepository);

        string streetName = "Test";
        string postalCode = "1234";
        string city = "Test";
        var address = addressService.CreateAddress(streetName, city, postalCode);

        //Act
        var result = addressService.GetAddressById(address.Id);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void UpdateAddress_ShouldReturnUpdatedAddressEntity_ReturnUpdatedAddressEntity()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var addressService = new AddressService(addressRepository);

        string streetName = "Test";
        string postalCode = "1234";
        string city = "Test";
        var address = addressService.CreateAddress(streetName, city, postalCode);
        address.StreetName = "Updated";
        address.PostalCode = "4321";
        address.City = "Updated";

        //Act
        var result = addressService.UpdateAddress(address);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void DeleteAddress_ShouldReturnTrue_ReturnTrue()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var addressService = new AddressService(addressRepository);

        string streetName = "Test";
        string postalCode = "1234";
        string city = "Test";
        var address = addressService.CreateAddress(streetName, city, postalCode);

        //Act
        var result = addressService.DeleteAddress(address.Id);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void DeleteAddress_ShouldReturnFalse_ReturnFalse()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var addressService = new AddressService(addressRepository);

        //Act
        var result = addressService.DeleteAddress(1);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void GetAllAddresses_ShouldReturnAllAddresses_ReturnAllAddresses()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var addressService = new AddressService(addressRepository);

        string streetName = "Test";
        string postalCode = "1234";
        string city = "Test";
        addressService.CreateAddress(streetName, city, postalCode);

        //Act
        var result = addressService.GetAllAddresses();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Address>>(result);
    }

    [Fact]
    public void GetAllAddresses_ShouldReturnEmptyList_ReturnEmptyList()
    {
        //Arrange
        var addressRepository = new AddressRepository(_context);
        var addressService = new AddressService(addressRepository);

        //Act
        var result = addressService.GetAllAddresses();

        //Assert
        Assert.Empty(result);
    }




}
