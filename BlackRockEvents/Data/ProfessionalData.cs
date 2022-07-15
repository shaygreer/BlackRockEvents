using BlackRockEvents.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlackRockEvents.Data
{
    public class ProfessionalData : IProfessionalData
    {
        private readonly ApplicationDbContext _applicationDbContext;
        /*This constructor takes the database as a parameter to inject as a dependency. */
        public ProfessionalData(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        /*This method returns a list of all professsionals from the database. */
        public IEnumerable<Professional> Professionals
        {
            get
            {
                return _applicationDbContext.Professionals;
            }
        }
        /*This method takes a professional as a parameter and adds that professional to the database, saves the changes, and then returns the professional.*/
        public Professional Add(Professional professional)
        {
            _applicationDbContext.Professionals.Add(professional);
            _applicationDbContext.SaveChanges();
            return professional;
        }
        /*This method takes a professional id and searches for the professional in the database. If a professional is found, it is returned, if not, this method returns a null pro. */
        public Professional GetById(int id)
        {
            Professional pro=_applicationDbContext.Professionals.FirstOrDefault(p => p.Professional_Id == id);
            return pro;
            
        }
        /*This method takes the id of a professional, searches the database for the professional with that  id and then deletes it from the database and saves the changes. */
        public Professional Delete(int id)
        {
            Professional pro = _applicationDbContext.Professionals.SingleOrDefault(p => p.Professional_Id == id);
            if(pro != null)
            {
                _applicationDbContext.Professionals.Remove(pro);
                _applicationDbContext.SaveChanges();
            }

            return pro;
        }
        /*This method takes a professional as a parameter and pulls the information saved under the same id from the database, it then saves the information passed in the parameter
         * to replace the information in the database, and then returns the professional with the updated information.*/
        public Professional Update(Professional professional)
        {
            Professional pro = _applicationDbContext.Professionals.SingleOrDefault(p=> p.Professional_Id == professional.Professional_Id);
            if (pro!= null)
            {
                pro.FirstName = professional.FirstName;
                pro.LastName = professional.LastName;   
                pro.ProfessionName = professional.ProfessionName;
                pro.PhotoName = professional.PhotoName;
                pro.Email = professional.Email;
                pro.Phone = professional.Phone;
                _applicationDbContext.SaveChanges();
            }
            return pro;
        }
    }
}
