using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Base
{
    public class CPFValidator : IDisposable
    {
        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        ~CPFValidator()
        {
            Dispose(false);
        }
        #endregion

        private bool ValidateCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return false;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11) return false;

            if (cpf.Distinct().Count() == 1) return false;

            if (cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" || cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" || cpf == "99999999999") return false;

            int[] numbers = new int[11];

            for (int i = 0; i < 11; i++)
            {
                numbers[i] = int.Parse(cpf[i].ToString());
            }

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += numbers[i] * (10 - i);
            }

            int rest = sum % 11;

            if (rest < 2)
            {
                if (numbers[9] != 0) return false;
            }
            else
            {
                if (numbers[9] != 11 - rest) return false;
            }

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += numbers[i] * (11 - i);
            }

            rest = sum % 11;

            if (rest < 2)
            {
                if (numbers[10] != 0) return false;
            }
            else
            {
                if (numbers[10] != 11 - rest) return false;
            }

            return true;
        }

        public bool Result { get; private set; }

        public CPFValidator(string cpf)
        {
            Result = ValidateCPF(cpf);
        }
    }
}
