namespace ExploreNationalParks
{
    public class UserRepository : IUserRepository
    {
        private readonly NationalParkDBContext _context;

        public UserRepository(NationalParkDBContext context)
        { 
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsUniqueUser(string username)
        {
            throw new NotImplementedException();
        }

        public User Register(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
