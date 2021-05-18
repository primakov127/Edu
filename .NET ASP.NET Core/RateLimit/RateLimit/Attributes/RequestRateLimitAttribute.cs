using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RateLimit.Attributes
{
    public class RequestRateLimitAttribute : ActionFilterAttribute
    {
        private readonly int _concurrentRequestAmount;
        private int _currentRequestAmount;

        private bool CanRequest
        {
            get
            {
                return (_currentRequestAmount < _concurrentRequestAmount);
            }
        }

        public RequestRateLimitAttribute(int concurrentRequestAmount)
        {
            _concurrentRequestAmount = concurrentRequestAmount;
            _currentRequestAmount = 0;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (CanRequest)
            {
                _currentRequestAmount = _currentRequestAmount + 1;
            }
            else
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.TooManyRequests);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _currentRequestAmount = _currentRequestAmount - 1;
        }
    }
}
