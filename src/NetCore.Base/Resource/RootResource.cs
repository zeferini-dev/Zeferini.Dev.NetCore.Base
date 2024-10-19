using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Base.Resource
{
    public static class RootResource
    {
        public static readonly string IdIsRequired = "Please ensure you have entered the Id";
        public static readonly int IdMinLength = 36;
        public static readonly int IdMaxLength = 36;

        public static readonly string CPFIsInvalid = "Please ensure you have entered a valid CPF";
        public static readonly string CNPJIsInvalid = "Please ensure you have entered a valid CNPJ";
        public static readonly string InscricaoEstadualIsInvalid = "Please ensure you have entered a valid InscricaoEstadual";
        public static readonly string RazaoSocialIsInvalid = "Please ensure you have entered a valid RazaoSocial";

        public static readonly string PreNomeIsInvalid = "Please ensure you have entered a valid PreNome";
        public static readonly string SobreNomeIsInvalid = "Please ensure you have entered a valid NobreNome";


        public static readonly string NameIsRequired = "Please ensure you have entered the Name";
        public static readonly int NameMinLength = 4;
        public static readonly int NameMaxLength = 100;
        public static readonly string NameLengthMessage = $@"The Name must have between {NameMinLength} and {NameMaxLength} characters";

        public static readonly string InsertedByIsRequired = "Please ensure you have entered the InsertedBy";
        public static readonly string InsertedOnIsRequired = "Please ensure you have entered the InsertedOn";
        public static readonly string InsertedOnMustBeLowerThanUpdatedOn = "InsertedOn is greater than UpdatedOn";

        public static readonly string UpdatedByIsRequired = "Please ensure you have entered the UpdatedBy";
        public static readonly string UpdatedOnIsRequired = "Please ensure you have entered the UpdatedOn";

        public static readonly string StatusIsRequired = "Please ensure you have entered the Status";

    }
}
