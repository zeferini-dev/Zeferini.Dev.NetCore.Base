namespace NetCore.Base
{
    public abstract class Pessoa : Root
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="name"></param>
        /// <param name="insertedBy"></param>
        protected Pessoa(string name, string insertedBy)
            : base(name, insertedBy)
        {
            ValidatePessoaInsert();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="insertedOn"></param>
        /// <param name="insertedBy"></param>
        /// <param name="updatedBy"></param>
        protected Pessoa(string name, NetCore.Base.Enum.EStatus status, DateTime insertedOn, string insertedBy, string updatedBy)
            : base(name, status, insertedOn, insertedBy, updatedBy)
        {
            ValidatePessoaUpdate();
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="insertedOn"></param>
        /// <param name="updatedOn"></param>
        /// <param name="insertedBy"></param>
        /// <param name="updatedBy"></param>
        protected Pessoa(string name, NetCore.Base.Enum.EStatus status, DateTime insertedOn, DateTime updatedOn, string insertedBy, string updatedBy)
            : base(name, status, insertedOn, insertedBy, updatedOn,   updatedBy)
        {
            
        }


        private void ValidatePessoaInsert()
        {
            NetCore.Base.RuleValidator
                .New()
                .ThrowExceptionIfExists();
        }

        private void ValidatePessoaUpdate()
        {
            NetCore.Base.RuleValidator
                .New()
                .ThrowExceptionIfExists();
        }
    }
}
