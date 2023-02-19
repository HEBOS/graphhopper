using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphHopper.Directions.Api.Models
{
    public enum ResponseCode
    {
        Success,
        BadRequest,
        InternalServerError,
        EmptyResponse,
        Cancelled
    }
}
