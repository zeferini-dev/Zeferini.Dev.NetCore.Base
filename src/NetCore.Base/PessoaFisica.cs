namespace NetCore.Base
{
    public abstract class PessoaFisica : Pessoa
    {
        private RuleValidator _validadorDeRegra = RuleValidator.New();

        private ushort _cpfMinLength { get; } = 11;
        private ushort _cpfMaxLength { get; } = 11;

        public string Id { get; private set; }
        public string CPF { get; private set; }
        public string PreNome { get; private set; }
        public string? NomeDoMeio { get; private set; }
        public string SobreNome { get; private set; }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cpf"></param>
        /// <param name="preNome"></param>
        /// <param name="nomeDoMeio"></param>
        /// <param name="sobreNome"></param>
        /// <param name="insertedBy"></param>
        protected PessoaFisica(string id, string cpf, string preNome, string nomeDoMeio, string sobreNome, string insertedBy)
            : base($@"{preNome} {nomeDoMeio} {sobreNome}", insertedBy)
        {
            Id = id;
            CPF = cpf;
            PreNome = preNome;
            NomeDoMeio = (nomeDoMeio.Trim().Length == 0) ? "" : nomeDoMeio;
            SobreNome = sobreNome;

            ValidatePessoaFisicaBase();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cpf"></param>
        /// <param name="preNome"></param>
        /// <param name="nomeDoMeio"></param>
        /// <param name="sobreNome"></param>
        /// <param name="status"></param>
        /// <param name="insertedOn"></param>
        /// <param name="insertedBy"></param>
        /// <param name="updatedBy"></param>
        protected PessoaFisica(string id, string cpf, string preNome, string nomeDoMeio, string sobreNome, NetCore.Base.Enum.EStatus status, DateTime insertedOn, string insertedBy, string updatedBy)
            : base($@"{preNome} {nomeDoMeio} {sobreNome}", status, insertedOn, insertedBy, updatedBy)
        {
            Id = id;
            CPF = cpf;
            PreNome = preNome;
            NomeDoMeio = (nomeDoMeio.Trim().Length == 0) ? "" : nomeDoMeio;
            SobreNome = sobreNome;

            ValidatePessoaFisicaUpdate();
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cpf"></param>
        /// <param name="preNome"></param>
        /// <param name="nomeDoMeio"></param>
        /// <param name="sobreNome"></param>
        /// <param name="status"></param>
        /// <param name="insertedOn"></param>
        /// <param name="updatedOn"></param>
        /// <param name="insertedBy"></param>
        /// <param name="updatedBy"></param>
        protected PessoaFisica(string id, string cpf, string preNome, string nomeDoMeio, string sobreNome, NetCore.Base.Enum.EStatus status, DateTime insertedOn, DateTime updatedOn, string insertedBy, string updatedBy)
            : base($@"{preNome} {nomeDoMeio} {sobreNome}", status, insertedOn, updatedOn,  insertedBy, updatedBy)
        {
            Id = id;
            CPF = cpf;
            PreNome = preNome;
            NomeDoMeio = (nomeDoMeio.Trim().Length == 0) ? "" : nomeDoMeio;
            SobreNome = sobreNome;
        }

        private void ValidatePessoaFisicaBase()
        {
            bool cpfIsValid = false;
            using (CPFValidator cpfValidator = new CPFValidator(CPF))
            {
                cpfIsValid = cpfValidator.Result;
            }

            _validadorDeRegra
                .When(!ValidateGuid(Id), NetCore.Base.Resource.RootResource.IdIsRequired)

                .When(string.IsNullOrEmpty(CPF), NetCore.Base.Resource.RootResource.NameIsRequired)
                .When(!cpfIsValid, NetCore.Base.Resource.RootResource.CPFIsInvalid)
                .When(!ValidateString(PreNome, null, null), NetCore.Base.Resource.RootResource.PreNomeIsInvalid)
                .When(!ValidateString(SobreNome, null, null), NetCore.Base.Resource.RootResource.SobreNomeIsInvalid)
                .ThrowExceptionIfExists();
        }

        private void ValidatePessoaFisicaInsert()
        {
            ValidatePessoaFisicaBase();

            _validadorDeRegra                
                .ThrowExceptionIfExists();
        }

        private void ValidatePessoaFisicaUpdate()
        {
            ValidatePessoaFisicaBase();

            _validadorDeRegra
                .ThrowExceptionIfExists();
        }
        
    }
}
