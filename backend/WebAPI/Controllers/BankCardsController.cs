using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Helpers.Extensions;
using WebAPI.Helpers.Services;
using WebAPI.Interface.Services;
using WebAPI.Models.Identity;
using WebAPI.Models.Schemas;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BankCardsController : ControllerBase
{
    private readonly IBankCardService _bankCardService;
    private readonly IAccountService _accountService;

    public BankCardsController(IBankCardService bankCardService, IAccountService accountService)
    {
        _bankCardService = bankCardService;
        _accountService = accountService;
    }

    [Authorize]
    [HttpGet("{cardId}")]
    public async Task<IActionResult> GetCard(int cardId)
    {
        var userId = _accountService.GetIdFromToken(Request.GetAuthString());
        var status = await _accountService.IsValidUserId(userId);

        if (status.StatusCode != 200)
            return StatusCode(status.StatusCode, status.StatusMessage);

        if (!await _bankCardService.IsCardOwnedByUser(cardId, userId!))
            return StatusCode(403, "You do not have permission to access this card.");

        var card = await _bankCardService.GetCard(cardId);

        return Ok(card);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllCards()
    {
        var userId = _accountService.GetIdFromToken(Request.GetAuthString());
        var status = await _accountService.IsValidUserId(userId);

        if (status.StatusCode != 200)
            return StatusCode(status.StatusCode, status.StatusMessage);

        var cards = await _bankCardService.GetAllUserCards(userId!);

        return Ok(cards);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateCard(BankCardCreateSchema schema)
    {
        var userId = _accountService.GetIdFromToken(Request.GetAuthString());
        var status = await _accountService.IsValidUserId(userId);

        if (status.StatusCode != 200)
            return StatusCode(status.StatusCode, status.StatusMessage);

        var card = await _bankCardService.CreateAsync(schema, userId!);

        return Created("", card);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateCard(BankCardUpdateSchema schema)
    {
        var userId = _accountService.GetIdFromToken(Request.GetAuthString());
        var status = await _accountService.IsValidUserId(userId);

        if (status.StatusCode != 200)
            return StatusCode(status.StatusCode, status.StatusMessage);

        if (!await _bankCardService.IsCardOwnedByUser(schema.Id, userId!))
            return StatusCode(403, "You do not have permission to access this card.");

        var card = await _bankCardService.UpdateAsync(schema, userId!);

        return Ok(card);
    }

    [Authorize]
    [HttpDelete("{cardId}")]
    public async Task<IActionResult> DeleteCard(int cardId)
    {
        var userId = _accountService.GetIdFromToken(Request.GetAuthString());
        var status = await _accountService.IsValidUserId(userId);

        if (status.StatusCode != 200)
            return StatusCode(status.StatusCode, status.StatusMessage);

        if (!await _bankCardService.IsCardOwnedByUser(cardId, userId!))
            return StatusCode(403, "You do not have permission to access this card.");

        if (!await _bankCardService.DeleteCard(cardId))
            return StatusCode(502, "Something went wrong when deleting your card. Make sure that the id is valid and try again.");

        return NoContent();
    }
}