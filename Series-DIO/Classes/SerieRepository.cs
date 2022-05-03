using Series_DIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_DIO
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> serieList = new List<Serie>();

        public void Delete(int id)
        {
            serieList[id].Delete();
        }

        public void Insert(Serie objectSerie)
        {
            serieList.Add(objectSerie);
        }

        public List<Serie> List()
        {
            return serieList;
        }

        public int NextId()
        {
            return serieList.Count();
        }

        public Serie ReturnId(int id)
        {
            return serieList[id];
        }

        public void Update(int id, Serie objectSerie)
        {
            serieList[id] = objectSerie;
        }
    }
}
