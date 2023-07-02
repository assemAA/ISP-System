using AutoMapper;
using ISP.BAL.DTOS;
using ISP.BAL.Interfaces;
using ISP.DAL.Interfaces;
using ISP.DAL.Models;
using ISP.DAL.Privillages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BAL.Reprosatories
{
    public class GroupManager : IGroupManager
    {
        private readonly IGeneralRepo<Group> _groupRepo;
        private readonly IMapper _mapper;
        public GroupManager(IGeneralRepo<Group> groupRepo , IMapper mapper)
        {
            _groupRepo = groupRepo;
            _mapper = mapper;
           
        }
        public async Task addGroup(GroupDTO group)
        {
            Group newGorup = _mapper.Map<Group>(group);
            newGorup = FillRole(newGorup);
            await _groupRepo.addItem(newGorup);
        }

        public async Task deleteGroup(int id)
        {
            await _groupRepo.removeItem(id);
        }

        public async Task<IEnumerable<GroupDTO>> getGroups()
        {
            IEnumerable<Group> groups = await _groupRepo.getAll();
            IEnumerable<GroupDTO> groupDTOs = _mapper.Map<List<GroupDTO>>(groups);
            return groupDTOs;
        }

        public async Task saveChanges()
        {
            await _groupRepo.saveChanges();
        }

        public async Task updateGroup(GroupDTO group)
        {
            Group groupToUpdate = _mapper.Map<Group>(group);
            groupToUpdate = FillRole(groupToUpdate);

            await _groupRepo.updateItem(groupToUpdate);
        }

       

        public async Task<Group> getGroupById(int id)
        {
            return await _groupRepo.getById(id);
        }


        public Group FillRole(Group group)
        {
            if (group.IsAdmin)
            {
                group.groupRole = Privileges.Admin.ToString();
                return group;
            }
            else if (group.IsManager)
            {
                group.groupRole = Privileges.Manager.ToString();
                return group;
            }
            else if(group.IsEmployee)
            {
                group.groupRole = Privileges.Employee.ToString();
                return group;
            }
            else if (group.ReadClients)
            {
                group.groupRole = Privileges.UserCanReadClientsData.ToString();
                return group;
            }
            else if (group.ReadWriteClients)
            {
                group.groupRole = Privileges.UserCanReadWriteClientsData.ToString();
                return group;
            }
            else
                return group;
        }


    }
}
