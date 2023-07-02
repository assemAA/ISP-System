using ISP.BAL.DTOS.BundleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Interfaces
{
    public interface IBundleManger
    {
        public Task<IEnumerable<ViewBundleDto>> getBundles();

        public Task<ViewBundleDto> getBundleById(int id);

        public Task addBundle(AddBundleDto bundle);

        public Task removeBundle(int id);

        public Task updateBundle(EditBundleDto newbundle);

        public Task saveChanges();
    }
}
