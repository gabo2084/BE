using BE.Infra.Data;

namespace BE.Api.Controllers.Authentication
{
    public class UsersController : BaseApiController
    {
        private readonly BEContext _context;
        public UsersController(BEContext context)
        {
            _context = context;

        }
    }
}