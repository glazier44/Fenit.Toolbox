using Fenit.Toolbox.ApplicationUserManager.Enum;

namespace Fenit.Toolbox.ApplicationUserManager.ViewModel
{
    public class LoginResult : Response
    {
        private SignInStatus _signInStatus;

        public SignInStatus SignInStatus
        {
            get { return _signInStatus; }
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
