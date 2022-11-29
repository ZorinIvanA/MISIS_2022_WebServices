using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISIS_2022_WebServices.Domain;

namespace MISIS_2022_WebServices.Controllers
{
    [Route("api/v1/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _repository;
        public OrdersController(IOrdersRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Order model)
        {
            return StatusCode(StatusCodes.Status201Created,
                _repository.Insert(model));
        }
    }
}
