
namespace IFMA_LP3.Entidades
{
    internal class Maintenance
    {
        public Maintenance()
        {            
        }

        Maintenance NewMaintenance(
            string problemDescription, bool deliver, bool clean, bool packing,
            Customer customer,
            Computer computer
            )
        {
            ProblemDescription = problemDescription;
            Deliver = deliver;
            Clean = clean;
            Packing = packing;
            Customer = customer;
            Computer = computer;
            return this;
        }

        public Guid Id { get; } = Guid.NewGuid();

        public DateTime ArrivalDate { get; set; } = DateTime.Now;

        public DateTime EstimatedCompletionDate { get; set; }

        public string ProblemDescription { get; set; }

        public bool Deliver { get; set; }

        public bool Clean { get; set; }

        public bool Packing { get; set; }


        public Customer Customer { get; set; }

        public Computer Computer { get; set; }


        #region builders
        
        internal Maintenance WithDeliveryOptionAs(bool deliver)
        {
            Deliver = deliver;
            return this;
        }

        internal Maintenance WithCleaningOptionAs(bool cleaning)
        {
            Clean = cleaning;
            return this;
        }

        internal Maintenance WithPackingOptionAs(bool packing)
        {
            Packing = packing;
            return this;
        }

        internal Maintenance WithEstimatedCompletionDate(DateTime estimatedCompletionDate)
        {
            EstimatedCompletionDate = estimatedCompletionDate;
            return this;
        }

        internal Maintenance WithProblemDescriptionAs(string problemDescription)
        {
            ProblemDescription = problemDescription;
            return this;
        }

        internal Maintenance WithCostumer(Customer customer)
        {
            Customer = customer;
            return this;
        }

        internal Maintenance WithComputer(Computer computer)
        {
            Computer = computer;
            return this;
        }
        #endregion

        public override string ToString() 
            => $"{Customer.FullName}, Sua Manutenção foi programada!\n" +
                $"O Item {Computer.Name} será finalizado em {EstimatedCompletionDate.ToShortDateString()}\n" +
                (Deliver ? $"Programado para ser Entregue.\n" : "") +
                (Clean ? $"Programado para ser Limpo.\n" : "") +
                (Packing ? $"Programado para ser Empacotado.\n" : "")
                ;
    }
}
