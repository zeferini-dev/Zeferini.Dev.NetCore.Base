using NetCore.Base.Enum;
using System;
using System.Xml.Linq;

namespace NetCore.Base
{
    public abstract class Root
    {
        public RuleValidator _validadorDeRegra = RuleValidator.New();
        public NetCore.Base.Enum.EStatus Status { get; private set; }
        public DateTime InsertedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string InsertedBy { get; private set; }
        public string? UpdatedBy { get; private set; }

        public string Name { get; private set; }

        private Root() { }

        public void SetStatus(EStatus status, string updatedBy)
        {
            Status = status;
            UpdatedBy = updatedBy;
            UpdatedOn = DateTime.Now;
        }

        public void SetName(string name, string updatedBy)
        {
            Name = name;
            UpdatedBy = updatedBy;
            UpdatedOn = DateTime.Now;

            ValidateRootBase();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="name"></param>
        /// <param name="insertedBy"></param>
        protected Root(string name, string insertedBy)
        {
            Status = EStatus.ATIVO;
            InsertedOn = DateTime.Now;
            InsertedBy = insertedBy;
            Name = name;

            ValidateRootInsert();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="insertedOn"></param>
        /// <param name="insertedBy"></param>
        /// <param name="updatedBy"></param>
        protected Root(string name, EStatus status, DateTime insertedOn, string insertedBy, string updatedBy)
        {

            Name = name;
            Status = status;
            InsertedOn = insertedOn;
            UpdatedOn = DateTime.Now;
            InsertedBy = insertedBy;
            UpdatedBy = updatedBy;

            ValidateRootUpdate();
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
        protected Root(string name, EStatus status, DateTime insertedOn, string insertedBy, DateTime? updatedOn, string? updatedBy)
        {
            Name = name;
            Status = status;
            InsertedOn = insertedOn;
            UpdatedOn = updatedOn;
            InsertedBy = insertedBy;
            UpdatedBy = updatedBy;

            ValidateRootBase();
        }

        /// <summary>
        /// Retorna true se o parâmetro guid for um string válido
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool ValidateGuid(string guid)
        {

            if (string.IsNullOrEmpty(guid) || (guid == string.Empty.ToString())) return false;

            bool isIdValido = false;

            isIdValido = Guid.TryParse(guid, out Guid guidValido);

            return isIdValido;
        }

        public bool ValidateUpdatedOn()
        {
            return (!((InsertedOn > UpdatedOn) || (InsertedOn > DateTime.Now) || (UpdatedOn != null && UpdatedOn > DateTime.Now)));
        }

        public bool ValidateString(string valor, int? minLength, int? maxLength)
        {
            if (string.IsNullOrEmpty(valor)) return false;

            if ((minLength != null && minLength > 0) &&  (valor.Length < minLength.Value)) return false;
            if ((maxLength != null && maxLength > 0) &&  (valor.Length > maxLength.Value)) return false;            

            if (valor.Length < minLength || valor.Length > maxLength) return false;

            return true;
        }

        private void ValidateRootBase()
        {
            _validadorDeRegra
                .When(!ValidateString(Name, null, null), NetCore.Base.Resource.RootResource.NameIsRequired)
                .When(!ValidateString(Name, NetCore.Base.Resource.RootResource.NameMinLength, NetCore.Base.Resource.RootResource.NameMaxLength), NetCore.Base.Resource.RootResource.NameLengthMessage)
                .ThrowExceptionIfExists();
        }

        private void ValidateRootInsert()
        {
            ValidateRootBase();

            _validadorDeRegra
                .When(!ValidateGuid(InsertedBy), NetCore.Base.Resource.RootResource.InsertedByIsRequired)

                .ThrowExceptionIfExists();
        }

        private void ValidateRootUpdate()
        {
            ValidateRootBase();

            _validadorDeRegra
                .When(!ValidateGuid(UpdatedBy), NetCore.Base.Resource.RootResource.UpdatedByIsRequired)
                .When(!ValidateUpdatedOn(), NetCore.Base.Resource.RootResource.UpdatedOnIsRequired)
                .ThrowExceptionIfExists();
        }        
    }
}
