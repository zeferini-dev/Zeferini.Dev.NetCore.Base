using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Base
{
    public class CNPJValidator
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

        ~CNPJValidator()
        {
            Dispose(false);
        }
        #endregion

        private bool ValidateCNPJ(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj)) return false;

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14) return false;

            if (cnpj.Distinct().Count() == 1) return false;

            if (cnpj == "00000000000000" || cnpj == "11111111111111" || cnpj == "22222222222222" || cnpj == "33333333333333" || cnpj == "44444444444444" || cnpj == "55555555555555" || cnpj == "66666666666666" || cnpj == "77777777777777" || cnpj == "88888888888888" || cnpj == "99999999999999") return false;

            int[] numbers = new int[14];

            for (int i = 0; i < 14; i++)
            {
                numbers[i] = int.Parse(cnpj[i].ToString());
            }

            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += numbers[i] * (5 - i);
            }

            for (int i = 0; i < 2; i++)
            {
                sum += numbers[12 + i] * (13 - i);
            }

            int rest = sum % 11;

            if (rest < 2)
            {
                if (numbers[12] != 0) return false;
            }
            else
            {
                if (numbers[12] != 11 - rest) return false;
            }

            sum = 0;
            for (int i = 0; i < 13; i++)
            {
                sum += numbers[i] * (6 - i);
            }

            for (int i = 0; i < 2; i++)
            {
                sum += numbers[12 + i] * (14 - i);
            }

            rest = sum % 11;

            if (rest < 2)
            {
                if (numbers[13] != 0) return false;
            }
            else
            {
                if (numbers[13] != 11 - rest) return false;
            }

            return true;
        }

        public bool Result { get; private set; }

        public CNPJValidator(string cnpj)
        {
            Result = ValidateCNPJ(cnpj);
        }
    }
}
