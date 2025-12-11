namespace VSA.Application.Entities
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        //Relational Properties
        public virtual AppUserProfile AppUserProfile { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
