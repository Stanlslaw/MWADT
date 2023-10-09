﻿
using TelephoneDirectory.Entity;

public interface ITelephoneRepository<T>
{
    Task<List<T>> GetAll();
    Task<T> GetId(Guid id);
    Task Create(T data);
    Task Update(T data);
    Task Remove(T data);
}