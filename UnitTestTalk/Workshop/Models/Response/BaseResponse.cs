using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UnitTestTalk.Workshop.Models.Response
{
    public class BaseResponse
    {
        public bool Success
        {
            get { return !Errors.Any(); }
        }

        public IEnumerable<ValidationResult> Errors { get; set; }
    }
}