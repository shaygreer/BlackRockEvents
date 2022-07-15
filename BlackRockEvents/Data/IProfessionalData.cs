using BlackRockEvents.Models;
using System.Collections.Generic;

namespace BlackRockEvents.Data
{
    /*Interface indicating what is needed in the ProfessionalsData Repository. */
    public interface IProfessionalData
    {
        IEnumerable<Professional> Professionals { get; }
        Professional Add(Professional professional);
        Professional Update(Professional professional);
        Professional GetById(int id);
        Professional Delete(int id);

    }
}
