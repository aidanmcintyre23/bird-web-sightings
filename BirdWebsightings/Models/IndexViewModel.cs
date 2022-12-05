namespace BirdWebsightings.Models
{
    public class IndexViewModel
    {
        public string Header { get; set; }
        public ResultsViewModel Results { get; set; }

        public static IndexViewModel Load()
            => new IndexViewModel
            {
                Header = "Bird Websightings",
                Results = ResultsViewModel.Load()
            };
    }
}