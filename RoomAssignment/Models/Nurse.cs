using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace RoomAssignment.Models
{
    public class Nurse
    {
        public int ID { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string Rooms { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }

}


    public class NurseDBContext : DbContext
    {
        public NurseDBContext(): base("NurseDBContext") 
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("staffassign");
        }

        public DbSet<Nurse> Nurses { get; set; }
    }
}