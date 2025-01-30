﻿using Users.Domain.Entities;

namespace Users.Domain.Repositories;

public interface IUsersRepository
{
    Task<IEnumerable<User>> GetAllAsync();
}
