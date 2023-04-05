
namespace IFMA_LP3.Entidades
{
    internal class Acessory : Equipment
    {
        public Guid Id { get; } = Guid.NewGuid();

        #region Builders
        internal Acessory WithName(string name)
        {
            Name = name;
            return this;
        }

        internal Acessory WithBrand(string brand)
        {
            Brand = brand;
            return this;
        }
        internal Acessory WithoutBrand()
        {
            Brand = "N/A";
            return this;
        }

        internal Acessory WithModel(string model)
        {
            Model = model;
            return this;
        }

        internal Acessory WithoutModel(string model)
        {
            Model = "N/A";
            return this;
        }

        internal Acessory WithSerialNumber(string serialNumber)
        {
            SerialNumber = serialNumber;
            return this;
        }

        internal Acessory WithoutSerialNumber()
        {
            SerialNumber = "N/A";
            return this;
        }
        #endregion
    }
}
