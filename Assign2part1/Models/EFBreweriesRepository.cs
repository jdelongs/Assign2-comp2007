using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//added referencees 
using System.Web;
using System.Data.Entity; 
namespace Assign2part1.Models
{
    public class EFBreweriesRepository : IbreweriesRepository
    {
        //db connection 
        StoreModel db = new StoreModel(); 
        
        public IQueryable<brewery> Breweries { get { return db.breweries; } }

        public void Delete(brewery brewery)
        {
            db.breweries.Remove(brewery);
            db.SaveChanges(); 
        }

        public brewery Save(brewery brewery)
        {
            if (brewery.breweryID == 0)
            {
                db.breweries.Add(brewery);
            }
            else
            {
                db.Entry(brewery).State = EntityState.Modified;
            }
            db.SaveChanges();

            return brewery; 
        }
    }
}
