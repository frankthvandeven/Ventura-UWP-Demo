using Ventura;

namespace Demo.Pages
{
    public class CountriesListViewmodel : ViewmodelBase
    {
        public enum ModeKind
        {
            List,
            Lookup
        }

        public ModeKind ModelMode { get; }

        public CountriesListViewmodel(ModeKind mode)
        {
            ModelMode = mode;
        }

        public string Input_CountryCodeID { get; set; } = null;

    }
}
