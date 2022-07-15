using System.ComponentModel.DataAnnotations;

namespace BlackRockEvents.Models
{
    public enum EventType
    {
        [Display(Name = "After-Party")]
        AfterParty,
        [Display(Name = "Anniversary Party")]
        AnniversaryParty,
        [Display(Name = "Baby Shower")]
        BabyShower,
        Banquets,
        [Display(Name = "Bar Mitzvah")]
        BarMitzvah,
        [Display(Name = "Birthday Party")]
        BirthdayParty,
        [Display(Name = "Cast Party")]
        CastParty,
        [Display(Name = "Cocktail Party")]
        CocktailParty,
        Conference,
        [Display(Name = "Costume Party")]
        CostumeParty,
        [Display(Name = "Dance/Ball")]
        DanceBall,
        [Display(Name = "Gender Reveal")]
        GenderReveal,
        [Display(Name = "Graduation Party")]
        GraduationParty,
        [Display(Name = "Holiday Party")]
        HolidayParty,
        [Display(Name = "Pre-Party")]
        PreParty,
        [Display(Name = "Product Launch")]
        ProductLaunch,
        Quinceanera,
        Reception,
        [Display(Name = "Religious Event")]
        ReligiousEvent,
        Seminar,
        [Display(Name = "Suprise Party")]
        SupriseParty,
        Wedding,
        [Display(Name = "Welcome Party")]
        WelcomeParty,
        [Display(Name = "Work Party")]
        WorkParty,
        [Display(Name = "Other...")]
        Other
    }
}
