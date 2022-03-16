using BachorzLibrary.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BachorzLibrary.Web.API
{
    public class ApiValidator<R>
    {
        public IDictionary<string, string> ErrorCodes { get; set; }
        public Func<R, IDictionary<string, string>, IEnumerable<ApiError>> ErrorList { get; set; } = (result, errors) => ApiError.NoErrors;
        public string ErrorMessagesConnector { get; set; } = ApiError.DefaultErrorConnector;
        public bool HitAlert { get; set; } = true;
        public bool TechnicalErrorOccured { get; private set; } = false;

        private void Verify(IEnumerable<ApiError> errorList)
        {
            if (errorList.IsNotNullOrEmpty() && HitAlert)
            {
                throw new ApiResponseException(errorList);
            }
        }

        public IEnumerable<ApiError> Errors(R result)
        {
            try
            {
                return ErrorList(result, ErrorCodes).WithoutEmptyValues();
            }
            catch (Exception ex)
            {
                TechnicalErrorOccured = true;
                return ApiError.TechnicalErrorList;
            }
        }

        public void VerifyErrorList(R result) => Verify(ErrorList(result, ErrorCodes));
    }
}
