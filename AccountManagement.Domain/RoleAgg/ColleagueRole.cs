using _01_Framework.Domain;

namespace AccountManagement.Domain.RoleAgg
{
    public class ColleagueRole : EntityBase
    {
        public long RoleId { get; private set; }
        public Role Role { get; private set; }

        protected ColleagueRole()
        {
        }

        public void Edit(long roleId)
        {
            RoleId = roleId;
        }
    }
}