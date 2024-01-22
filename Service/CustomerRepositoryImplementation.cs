
using System.Linq;
using Customer_Repo_Pattern.Models;

namespace Customer_Repo_Pattern.Service
{
    public class CustomerRepositoryImplementation : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepositoryImplementation(CustomerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customer.ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customer.FirstOrDefault(c => c.CustomerId == id);
        }
        public bool IsEmailOrPhoneNumberExists(string email, string phoneNumber, int customerId)
        {
            // Check if email or phone number already exists for customers excluding the current customer
            return _context.Customer.Any(c => (c.Email == email || c.PhoneNumber == phoneNumber) && c.CustomerId != customerId);
        }

        public bool IsEmailOrPhoneNumberExists(string email, string phoneNumber)
        {
            // Check if email or phone number already exists for any customer
            return _context.Customer.Any(c => c.Email == email || c.PhoneNumber == phoneNumber);
        }

        public void Add(Customer customer)
        {
            // Check if email or phone number already exists
            if (_context.Customer.Any(c => c.Email == customer.Email || c.PhoneNumber == customer.PhoneNumber))
            {
                Console.WriteLine("Customer with the same email or phone number already exists.");
                return;
            }

            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var existingCustomer = _context.Customer.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                _context.Customer.Remove(customer);
                _context.SaveChanges();
            }
        }
    }
}
