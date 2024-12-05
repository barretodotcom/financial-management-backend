using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManagement.Business.Expenses.Services;
using FinanceManagement.Controllers.Mappers;
using FinanceManagement.Controllers.Models.Requests;
using FinanceManagement.Controllers.Models.Responses;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessModels = FinanceManagement.Business.Expenses.Models;
using FinanceManagement.Annotations;

namespace FinanceManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost("[action]")]
        [UseAuth]
        public IActionResult Create([FromHeader] Guid UserId, [FromBody] CreateExpense request)
        {
            BusinessModels.CreateExpense createExpense = request.Adapt<BusinessModels.CreateExpense>();
            createExpense.UserId = UserId;

            _expenseService.Save(createExpense);

            Response response = ResponseMapper.Map(true); 

            return Ok(response);
        }
    }
}