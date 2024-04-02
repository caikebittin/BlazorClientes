using BlazorClientes.Shared.Entities;
using BlazorClientes.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorClientes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    [HttpGet("Clientes")]
    public async Task<ActionResult<List<Cliente>>> GetActionResultAsync()
    {
        var clientes = await _clienteRepository.GetAllClientesAsync();
        return Ok(clientes);
    }

    [HttpGet("cliente/{id}")]
    public async Task<ActionResult<List<Cliente>>> GetSingleClienteAsync(int id)
    {
        var cliente = await _clienteRepository.GetClienteByIdAsync(id);
        return Ok(cliente);
    }

    [HttpPost("Add-Cliente")]
    public async Task<ActionResult<List<Cliente>>> AddClienteAsync(Cliente model)
    {
        var cliente = await _clienteRepository.AddClienteAsync(model);
        return Ok(cliente);
    }

    [HttpPut("Update-Cliente")]
    public async Task<ActionResult<List<Cliente>>> UpdateClienteAsync(Cliente model)
    {
        var cliente = await _clienteRepository.UpdateClienteAsync(model);
        return Ok(cliente);
    }

    [HttpDelete("Delete-Cliente/{id}")]
    public async Task<ActionResult<List<Cliente>>> DeleteClienteAsync(int id)
    {
        var cliente = await _clienteRepository.DeleteClienteAsync(id);
        return Ok(cliente);
    }
}
