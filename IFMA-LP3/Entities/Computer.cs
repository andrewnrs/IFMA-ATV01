
namespace IFMA_LP3.Entidades
{
    internal class Computer : Equipment
    {
        public List<Acessory> Acessories { get; set; }

        public ComputerTypeEnum ComputerType { get; set; }

        public bool New { get; set; }

        #region Utilities
        public bool HasAcessories()
            => Acessories is not null;

        public bool IsNew()
            => New;

        public string GetComputerTypeDescription()
            => ComputerType.ToString();
        #endregion

        #region Builders
        internal Computer WithComputerStateAs(bool newComputer)
        {
            New = newComputer;
            return this;
        }

        internal Computer WithComputerTypeAs(int ComputerTypeIndex)
        {
            ComputerType = (ComputerTypeEnum) ComputerTypeIndex;
            return this;
        }

        internal Computer WithAcessories(ICollection<Acessory> acessories)
        {
            Acessories = acessories.ToList();
            return this;
        }

        internal Computer WithName(string name)
        {
            Name = name;
            return this;
        }

        internal Computer WithBrand(string brand)
        {
            Brand = brand;
            return this;
        }

        internal Computer WithModel(string model)
        {
            Model = model;
            return this;
        }

        internal Computer WithSerialNumber(string serialNumber)
        {
            SerialNumber = serialNumber;
            return this;
        }
        #endregion
    }
}
