using Fenit.Toolbox.ApplicationUserManager.Enum;
using Fenit.Toolbox.Core.Web;

namespace Fenit.Toolbox.ApplicationUserManager.ViewModel
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
                        IsError = true;
                        break;
                    }
                    case SignInStatus.Failure:
                    {
                        Message = "Błąd";
                        IsError = true;
                        break;
                    }
                }
            }
        }
    }
}