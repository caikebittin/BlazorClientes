﻿using BlazorClientes.Context;
using BlazorClientes.Shared.Entities;
using BlazorClientes.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorClientes.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ClienteContext _context;
    public ClienteRepository(ClienteContext context)
    {
        _context = context;
    }

    public async Task<Cliente> AddClienteAsync(Cliente model)
    {
        if (model is null)
            return null!;

        var chk = await _context.Clientes.Where(x => x.Nome.ToLower()
                                                .Equals(model.Nome.ToLower())).FirstOrDefaultAsync();
        if (chk is not null)
            return null!;

        var novoCliente = _context.Clientes.Add(model).Entity;
        await _context.SaveChangesAsync();
        return novoCliente;
    }

    public async Task<Cliente> DeleteClienteAsync(int clienteId)
    {
        var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == clienteId);

        if (cliente == null)
            return null!;

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return cliente;
    }

    public async Task<List<Cliente>> GetAllClientesAsync() =>
                                    await _context.Clientes.ToListAsync();

    public async Task<Cliente> GetClienteByIdAsync(int clienteId)
    {
        var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == clienteId);

        if(cliente == null) 
            return null!;

        return cliente;
    }

    public async Task<Cliente> UpdateClienteAsync(Cliente model)
    {
        var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (cliente is null)
            return null!;

        await _context.SaveChangesAsync();

        return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == model.Id)!;
    }
}
