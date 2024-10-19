using NetCore.Base.Enum;

namespace NetCore.Base
{
    public abstract class PessoaJuridica : Pessoa
    {
        public string CNPJ { get; private set; }
        public string InscricaoEstadual { get; private set; }
        public string RazaoSocial { get; private set; }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="cnpj"></param>
        /// <param name="inscricaoEstadual"></param>
        /// <param name="nomeFantasia"></param>
        /// <param name="razaoSocial"></param>
        /// <param name="insertedBy"></param>
        protected PessoaJuridica(string cnpj, string inscricaoEstadual, string nomeFantasia, string razaoSocial, string insertedBy) : base(nomeFantasia, insertedBy)
        {
            CNPJ = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            RazaoSocial = razaoSocial;

            ValidatePessoaJuridicaInsert();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="cnpj"></param>
        /// <param name="inscricaoEstadual"></param>
        /// <param name="nomeFantasia"></param>
        /// <param name="razaoSocial"></param>
        /// <param name="status"></param>
        /// <param name="insertedOn"></param>
        /// <param name="insertedBy"></param>
        /// <param name="updatedBy"></param>
        protected PessoaJuridica(string cnpj, string inscricaoEstadual, string nomeFantasia, string razaoSocial, EStatus status, DateTime insertedOn, string insertedBy, string updatedBy) : base(nomeFantasia, status, insertedOn, insertedBy, updatedBy)
        {
            CNPJ = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            RazaoSocial = razaoSocial;

            ValidatePessoaJuridicaUpdate();
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="cnpj"></param>
        /// <param name="inscricaoEstadual"></param>
        /// <param name="nomeFantasia"></param>
        /// <param name="razaoSocial"></param>
        /// <param name="status"></param>
        /// <param name="insertedOn"></param>
        /// <param name="insertedBy"></param>
        /// <param name="updatedBy"></param>
        protected PessoaJuridica(string cnpj, string inscricaoEstadual, string nomeFantasia, string razaoSocial, EStatus status, DateTime insertedOn, DateTime updatedOn, string insertedBy, string updatedBy) : 
            base(nomeFantasia, status, insertedOn, updatedOn, insertedBy, updatedBy)
        {
            CNPJ = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            RazaoSocial = razaoSocial;
        }

        private void ValidatePessoaJuridicaInsert()
        {
            NetCore.Base.RuleValidator
                .New()
                .When(string.IsNullOrEmpty(CNPJ), NetCore.Base.Resource.RootResource.CNPJIsInvalid)
                .When(string.IsNullOrEmpty(InscricaoEstadual), NetCore.Base.Resource.RootResource.InscricaoEstadualIsInvalid)
                .When(string.IsNullOrEmpty(RazaoSocial), NetCore.Base.Resource.RootResource.RazaoSocialIsInvalid)
                .ThrowExceptionIfExists();
        }

        private void ValidatePessoaJuridicaUpdate()
        {
            NetCore.Base.RuleValidator
                .New()
                .When(InsertedOn == DateTime.MinValue, NetCore.Base.Resource.RootResource.InsertedOnIsRequired)
                .When(InsertedOn > UpdatedOn, NetCore.Base.Resource.RootResource.InsertedOnMustBeLowerThanUpdatedOn)
                .When(UpdatedBy == string.Empty.ToString(), NetCore.Base.Resource.RootResource.UpdatedByIsRequired)
                .ThrowExceptionIfExists();
        }
    }
}
