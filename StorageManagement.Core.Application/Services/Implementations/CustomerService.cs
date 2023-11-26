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
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Customer customer)
        {
            _unitOfWork.CustomerRepository
                       .Add(customer,string.Empty);
        }

        public bool Delete(int id)
        {
            try
            {
                var savedCustomer = _unitOfWork.CustomerRepository.Get(c => c.Id == new CustomerId(id));

                if (savedCustomer is not null)
                {
                    _unitOfWork.CustomerRepository.Remove(GetById(id));
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            return _unitOfWork.CustomerRepository.GetAll(includeProperties: null);
        }

        public Customer GetById(int id)
        {
            return _unitOfWork.CustomerRepository.Get(g => g.Id == new CustomerId(id));
        }

        public void Save()
        {
            _unitOfWork.Save();
        }

        public void Update(Customer customer)
        {
            _unitOfWork.CustomerRepository.Update(customer);
        }
    }
}
