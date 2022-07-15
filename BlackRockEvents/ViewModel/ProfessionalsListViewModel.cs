using BlackRockEvents.Models;
using System.Collections.Generic;

namespace BlackRockEvents.ViewModel
{
    /*This View Model is used by the Index View in the Views/Professionals folder to initialize the _ProfessionalCards.*/
    public class ProfessionalsListViewModel
    {
        public IEnumerable<Professional> Professionals { get; set; }
    }
}
