

using Fenit.Toolbox.Core.Answers;
using Fenit.Toolbox.UserManager.Enum;

namespace Fenit.Toolbox.UserManager.ViewModel
{
    public class LoginResult : Response
    {
        private SignInStatus _signInStatus;

        public SignInStatus SignInStatus
        {
            get => _signInStatus;
            set
            {
                _signInStatus = value;
                switch (value)
                {
                    case SignInStatus.Block:
                    {
                        Message = "zablokowany";
                        ResponseStatus=ResponseStatus.Warning;
                        break;
                    }
                    case SignInStatus.Failure:
                    {
                        Message = "Błąd";
                        ResponseStatus = ResponseStatus.Error;

                            break;
                    }
                }
            }
        }
    }
}