using Nicom.Timesheets.Data.Interfaces;

namespace Nicom.Timesheets.Data.Repositories
{
    public class RepositoryFactory
    {
        private static IUserRepository userRepository;

        private RepositoryFactory()
        {
        }

        public static IUserRepository UserRepository => userRepository ?? (userRepository = new UserRepository());
    }
}