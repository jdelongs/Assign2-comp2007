using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign2part1.Models
{
    public interface IbreweriesRepository
    {
        IQueryable<brewery> Breweries { get; }
        brewery Save(brewery brewerys);
        void Delete(brewery brewerys); 
    }
}
