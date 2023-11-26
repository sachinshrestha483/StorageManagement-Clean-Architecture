using StorageManagement.Core.Application.Abstractions;
using StorageManagement.Core.Application.Services.Abstractions;
using StorageManagement.Core.Domain.Entities;
using StorageManagement.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Core.Application.Services.Implementations
{
    public class GateEntryService : IGateEntryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GateEntryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(GateEntry gateEntry, string userName)
        {
            _unitOfWork.GateEntryRepository
                       .Add(gateEntry,userName);
        }

        public bool Delete(int id)
        {
            try
            {
                var savedGateEntry = _unitOfWork.GateEntryRepository.Get(g => g.Id == new GateEntryId(id));

                if (savedGateEntry is not null)
                {
                    _unitOfWork.GateEntryRepository.Remove(GetById(id));
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IEnumerable<GateEntry> GetAll()
        {
            return _unitOfWork.GateEntryRepository.GetAll(includeProperties: null);
        }

        public GateEntry GetById(int id)
        {
            return _unitOfWork.GateEntryRepository.Get(g => g.Id == new GateEntryId(id));
        }

        public void Save()
        {
            _unitOfWork.Save();
        }

        public void Update(GateEntry gateEntry, string userName)
        {
            _unitOfWork.GateEntryRepository.Update(gateEntry, userName);
        }
    }
}
