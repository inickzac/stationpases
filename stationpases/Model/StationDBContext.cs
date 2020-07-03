namespace stationpases.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StationDBContext : DbContext
    {
      
        public StationDBContext()
            : base("name=StationDBContext")
        {
        }

    }

   
}