using System;
using System.Collections.Generic;

namespace BachorzLibrary.Common.Tools.API
{
    public class ApiValidatorV2<R>
    {
        public R Result { get; set; }
        public IDictionary<string, string> ErrorCodes { get; set; }
        public Action<ApiValidatorV2<R>> FindErrors { get; set; } = (validator) => { };
        public string ErrorMessagesConnector { get; set; } = ApiError.DefaultErrorConnector;
        public bool TechnicalErrorOccured { get; private set; } = false;
        public IList<ApiError> ErrorList { get; private set; }

        public void AddError(string message, string additionalMessage = "")
        {
            ErrorList?.AddError($"{message} {additionalMessage}");
        }

        public void AddErrorByCode(string code, string additionalMessage = "")
        {
            ErrorList?.AddError(code, $"{ErrorCodes?.PickErrorMessage(code)} {additionalMessage}");
        }

        public void Run()
        {
            try
            {
                ErrorList = new List<ApiError>();
                FindErrors(this);
            }
            catch (Exception ex)
            {
                TechnicalErrorOccured = true;
            }
        }

    }
}
