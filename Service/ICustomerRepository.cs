using Customer_Repo_Pattern.Models;

namespace Customer_Repo_Pattern.Service
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        //void CreateOrEdit(Customer customer);
        void Delete(int id);
        bool IsEmailOrPhoneNumberExists(string email, string phoneNumber, int customerId);
        bool IsEmailOrPhoneNumberExists(string email, string phoneNumber);
    }
}
