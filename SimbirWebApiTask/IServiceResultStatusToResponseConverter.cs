using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirWebApiTask
{
    public interface IServiceResultStatusToResponseConverter
    {
        public IActionResult GetResponse<T>(ServiceResult<T> serviceResult, string modelPath = null);
    }
}
