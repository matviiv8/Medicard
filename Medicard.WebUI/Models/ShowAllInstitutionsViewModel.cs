using Medicard.Services.ViewModels.Institution;

namespace Medicard.WebUI.Models
{
    public class ShowAllInstitutionsViewModel
    {
        public IEnumerable<AllInstitutionsViewModel> AllInstitutions { get; set; }

        public PageViewModel PagingInfo { get; set; }
    }
}
