
namespace IFMA_LP3.Entidades
{
    internal class Customer
    {
        public Customer()
        {
        }

        public Guid Id { get; } = Guid.NewGuid();

        public int Registration { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        #region Builders
        internal Customer WithFullname(string fullname)
        {
            FullName = fullname;
            return this;
        }

        internal Customer WithPhoneNumber(string phone)
        {
            PhoneNumber = phone;
            return this;
        }

        internal Customer WithEmail(string email)
        {
            Email = email;
            return this;
        }

        internal Customer WithRegistration(int registration)
        {
            Registration = registration;
            return this;
        }

        internal Customer WithAddress(Address address)
        {
            Address = address;
            return this;
        }
        #endregion
    }
}
