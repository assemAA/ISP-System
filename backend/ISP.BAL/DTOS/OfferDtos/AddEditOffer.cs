using ISP.BAL.DTOS.BranchesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.DTOS.OfferDtos
{
    public class AddEditOffer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double FineInFirstYear { get; set; }
        public int PeriodForCancelOffer { get; set; }
        public bool AbilityToLowOrRaise { get; set; }
        public int AmountOfOfferMonths { get; set; }
        public int AmountOfFreeMonths { get; set; }
        public bool FreeMonthsFirst { get; set; }
        public bool CombinedBill { get; set; }
        public bool IsThereDiscount { get; set; }
        public int AmountOfDiscount { get; set; }
        public bool IsIncludeRouter { get; set; } 

        public int RouterCost { get; set; }

        public List<int> BranchesId { get; set; }
    }
}
