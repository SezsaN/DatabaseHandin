﻿using Infrastructure.Contexts;
using Infrastructure.Entities;


namespace Infrastructure.Repositories;

public class AddressRepository(DataContextDbFirst context) : BaseProductRepository<Address>(context)
{
    private readonly DataContextDbFirst _context = context;
}
