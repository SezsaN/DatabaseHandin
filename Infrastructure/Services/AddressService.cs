using Infrastructure.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepository;

        public AddressService(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        public Address CreateAddress(string streetName, string postalCode, string city)
        {
            var address = _addressRepository.GetOne(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if (address == null)
            {
                address = _addressRepository.Create(new Address { StreetName = streetName, PostalCode = postalCode, City = city });
            }
            return address!;
        }

        public Address GetAddressByName(string streetName, string postalCode, string city)
        {
            var address = _addressRepository.GetOne(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return address;
        }

        public Address GetAddressById(int id)
        {
            var address = _addressRepository.GetOne(x => x.Id == id);
            return address;
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            var addresses = _addressRepository.GetAll();
            return addresses;
        }

        public Address UpdateAddress(Address address)
        {
            var updatedAddress = _addressRepository.Update(x => x.Id == address.Id, address);
            return updatedAddress;
        }

        public bool DeleteAddress(int id)
        {
            var address= _addressRepository.GetOne(x => x.Id == id);
            if (address!= null)
            {
                _addressRepository.Delete(x => x.Id == id);
                return true;
            }
            return false;
        }
    }
}
