using Backend.EN;

namespace backend_ensolvers.WEBAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
