
using System.Reflection.Emit;

namespace IFMA_LP3.Entidades
{
    internal class Address
    {
        public Address()
        {
        }

        public Address(int zipcode, string number, string street)
        {
            ZipCode = zipcode;
            HouseNumber = number;
            Street = street;
        }

        public int ZipCode { get; set; }

        public string HouseNumber { get; set; }

        public string Street { get; set; }


        #region Builders

        internal Address WithHouseNumber(string houseNumber)
        {
            HouseNumber = houseNumber;
            return this;
        }

        internal Address WithStreet(string street)
        {
            Street = street;
            return this;
        }

        internal Address WithZipCode(int zipCode)
        {
            ZipCode = zipCode;
            return this;
        }
        #endregion
    }
}
