
namespace Netrunner.Domain.Core
{
    public class ExternalCard
    {
        public int CostForPlay { get; set; }

        public string DescriptionForCard { get; set; }

        public string NameOfCorp {  get; set; }

        public Guid UniqIdForExternalBase { get; set; }

        
    }
}
