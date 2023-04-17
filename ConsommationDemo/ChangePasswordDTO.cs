using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommationDemo
{
    public class ChangePasswordDTO
    {
        public ChangePasswordDTO(string actualPassword, string newPassword, string newPasswordConfirmation)
        {
            this.actualPassword = actualPassword;
            this.newPassword = newPassword;
            this.newPasswordConfirmation = newPasswordConfirmation;
        }

        public string actualPassword { get; set; }
        public string newPassword { get; set; }
        public string newPasswordConfirmation { get; set; }

    }
}
