using IFMA_LP3.Entidades;

namespace IFMA_LP3
{
    public partial class Problema003 : Form
    {
        List<Acessory> AcessoryList = new();
        Customer defaultCustomer;

        public Problema003()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            EquipmentEstimatedCompletionDtPicker.MinDate = DateTime.Today;

            defaultCustomer = new Customer()
                .WithFullname("Andrew Silva")
                .WithRegistration(71)
                .WithPhoneNumber("99999999999")
                .WithEmail("andrew.navarro@acad.ifma.edu.br")
                .WithAddress(new(65000000, "Zero", "Rua dos bobos"))
                ;
        }

        #region Form Events

        private void HasAcessoriesChkBox_CheckedChanged(object sender, EventArgs e)
            => ComputerAcessoriesGpBox.Visible = !ComputerAcessoriesGpBox.Visible;

        private void CleanFormBtn_Click(object sender, EventArgs e)
            => ResetForm();

        private void ConfirmMaintanenceBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var equipment = new Computer()
                .WithComputerTypeAs(EquipmentTypeCbBox.SelectedIndex)
                .WithComputerStateAs(EquipmentNewRadBtn.Checked)
                .WithBrand(EquipmentBrandTxtBox.Text)
                .WithModel(EquipmentBrandTxtBox.Text)
                .WithName(EquipmentBrandTxtBox.Text)
                .WithSerialNumber(EquipmentBrandTxtBox.Text)
                ;

            var customer = new Customer()
                .WithFullname(CustomerNameTxtBox.Text)
                .WithPhoneNumber(CustomerPhoneTxtBox.Text)
                .WithRegistration(Convert.ToInt32(CustomerRegistrationTxtBox.Text))
                ;

            var maintenance = new Maintenance()
                .WithCostumer(customer)
                .WithDeliveryOptionAs(DeliveryChkBox.Checked)
                .WithCleaningOptionAs(CleaningChkBox.Checked)
                .WithPackingOptionAs(PackingChkBox.Checked)
                .WithEstimatedCompletionDate(EquipmentEstimatedCompletionDtPicker.Value)
                .WithProblemDescriptionAs(EquipmentProblemDescriptionTxtBox.Text)
                .WithComputer(equipment)
                ;

            MessageBox.Show(maintenance.ToString());

            ResetForm();
        }

        private void AddAcessoryBtn_Click(object sender, EventArgs e)
        {
            #region Acessory Validation
            if (AcessoryNameTxtBox.Text == "")
            {
                MessageBox.Show("Preencha um nome de acessório válido");
                return;
            }
            #endregion

            #region Create Current Acessory
            Acessory acessory = new Acessory()
                .WithName(AcessoryNameTxtBox.Text)
                .WithModel(AcessoryModelTxtBox.Text)
                .WithBrand(AcessoryBrandTxtBox.Text)
                .WithSerialNumber(AcessorySerialNumberTxtBox.Text);

            AcessoriesAddedCbBox.Items.Add(acessory.Name);
            AcessoryList.Add(acessory);
            #endregion

            #region Clear Current Acessory
            AcessorySerialNumberTxtBox.Text = "";
            AcessoryModelTxtBox.Text = "";
            AcessoryBrandTxtBox.Text = "";
            AcessoryNameTxtBox.Text = "";
            #endregion
        }

        private void RemoveAcessoryTxtBox_Click(object sender, EventArgs e)
        {
            #region Get Selected Acessory
            var acessoryName = AcessoriesAddedCbBox.SelectedItem is not null
                ? AcessoriesAddedCbBox.SelectedItem.ToString()
                : AcessoriesAddedCbBox.Text;

            if (acessoryName is "")
                return;
            #endregion

            #region Remove From List
            var a = AcessoryList.Where(a => a.Name == acessoryName).First();

            AcessoryList.Remove(a);
            #endregion

            #region Remove from ComboBox
            AcessoriesAddedCbBox.Items.Remove(AcessoriesAddedCbBox.SelectedItem);
            AcessoriesAddedCbBox.SelectedItem = "";
            AcessoriesAddedCbBox.SelectedIndex = -1;
            AcessoriesAddedCbBox.Text = "";
            #endregion
        }

        private void EquipmentTypeCbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EquipmentTypeCbBox.SelectedItem.ToString() == "Desktop"
                || EquipmentTypeCbBox.SelectedItem.ToString() == "Notebook")
            {
                HasAcessoriesChkBox.Enabled = true;
                HasAcessoriesChkBox.Visible = true;
            }
            else
            {
                HasAcessoriesChkBox.Enabled = false;
                HasAcessoriesChkBox.Visible = false;
            }
        }

        private void CustomerRegistrationTxtBox_TextChanged(object sender, EventArgs e)
        {
            if(CustomerRegistrationTxtBox.Text is not "" 
                && defaultCustomer.Registration == Convert.ToInt32(CustomerRegistrationTxtBox.Text))
                LoadDefaultCustomer();
        }

        #endregion

        #region Internal Methods
        private bool ValidateForm()
        {
            var validForm = true;
            var erros = "";

            #region Customer
            if (CustomerRegistrationTxtBox.Text is ""
                || CustomerNameTxtBox.Text is ""
                || CustomerPhoneTxtBox.Text is "")
            {
                erros += "Cadastre um cliente válido.\n";
                validForm = false;
            }

            if (DeliveryChkBox.Checked
                && (CustomerStreetAdressTxtBox.Text is ""
                    || CustomerZipCodeTxtBox.Text is ""
                    || CustomerHouseNumberTxtBox.Text is ""))
            {
                erros += "Cadastre p endereço do cliente ou desmarque a opção 'Para Entrega'.\n";
                validForm = false;
            }
            #endregion

            #region Warranty
            if (!EquipmentUsedRadBtn.Checked && !EquipmentNewRadBtn.Checked)
            {
                erros += "Escolha se o Equipamento é Novo ou Usado.\n";
                validForm = false;
            }
            #endregion

            #region Estimated Completion Date not on Sunday
            if (EquipmentEstimatedCompletionDtPicker.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                erros += "A data escolhida não pode ser domingo.\n";
                validForm = false;
            }
            #endregion

            #region Acessory
            if (HasAcessoriesChkBox.Checked && AcessoryList.Count == 0)
            {
                erros += "Cadastre um acessório ou desmarque a opção de 'Possui Acessórios'.\n";
                validForm = false;
            }
            #endregion

            #region Equipment
            if (EquipmentBrandTxtBox.Text is ""
                || EquipmentModelTxtBox.Text is ""
                || EquipmentNameTxtBox.Text is ""
                || EquipmentProblemDescriptionTxtBox.Text is ""
                || EquipmentSerialNumberTxtBox.Text is ""
                || EquipmentTypeCbBox.Text is "")
            {
                erros += "Cadastre todos os dados do equipamento com valores válidos.\n";
                validForm = false;
            }
            #endregion

            if (!validForm)
            {
                MessageBox.Show("Atenção! Seu formulário posui pendências:\n\n" + erros);

                return false;
            }

            return true;
        }

        private void ResetForm()
        {
            Controls.Clear();
            InitializeComponent();
        }

        private void LoadDefaultCustomer()
        {
            CustomerEmailTxtBox.Text = defaultCustomer.Email;
            CustomerNameTxtBox.Text = defaultCustomer.FullName;
            CustomerPhoneTxtBox.Text = defaultCustomer.PhoneNumber;
            CustomerStreetAdressTxtBox.Text = defaultCustomer.Address.Street;
            CustomerZipCodeTxtBox.Text = defaultCustomer.Address.ZipCode.ToString();
            CustomerHouseNumberTxtBox.Text = defaultCustomer.Address.HouseNumber;
        }
        #endregion

        #region HELP
        private void CustomerRegistrationTxtBox_HelpRequested(object sender, HelpEventArgs hlpevent)
         => MessageBox.Show("Digite o Registro do Cliente aqui para Preencher seus dados automaticamente.\n" +
                "Cliente de Exemplo: 71");
        
        #endregion

    }
}