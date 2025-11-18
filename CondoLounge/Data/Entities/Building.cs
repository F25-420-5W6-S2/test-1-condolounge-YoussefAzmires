namespace CondoLounge.Data.Entities
{

    //    The CondoLounge App should be a way to manage the condo buildings.
    //Usually there is at least one user that leaves in a condo.
    //One condo can have multiple users and the Condo-Number is mandatory and uniq id in the same building.
    //One user may have multiple condos in multiple buildings.
    //A condo will have: CondoNumber, location/ address.
    public class Building
    {
        public int Id { get; set; }

        public ICollection<Condo> condos { get; set; } = new List<Condo>();

        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
