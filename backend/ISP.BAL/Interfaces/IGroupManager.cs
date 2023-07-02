using ISP.BAL.DTOS;
using ISP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Interfaces
{
    public  interface IGroupManager
    {
        public Task<IEnumerable<GroupDTO>> getGroups();

        public Task<Group> getGroupById(int id);
        public Task addGroup(GroupDTO group);
        public Task updateGroup(GroupDTO group);
        public Task deleteGroup(int id);

        public Task saveChanges();


    }
}
