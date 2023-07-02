using ISP.BAL.DTOS.CentralsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Interfaces
{
    public interface ICentralManager
    {
        public Task<IEnumerable<ViewCentralDto>> getCentrals();

        public Task<ViewCentralDto> getCentralById(int id);

        public Task addCentral(AddEditCentralDto central);

        public Task removeCentral(int id);

        public Task updateCentral(AddEditCentralDto central);

        public Task saveChanges();

    }
}
