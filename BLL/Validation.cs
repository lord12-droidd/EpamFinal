using BLL.Models;
using System.Linq;
using System.Collections.Generic;

namespace BLL
{
    public class Validation
    {
        public bool Validator(IEnumerable<UserModel> models, UserModel model)
        {
            if (!ValidatePassword(model.Password))
            {
                return false;
            }
            for (int i = 0; i < models.Count(); i++)
            {
                if (model.Email ==  models.ToList()[i].Email || model.UserName == models.ToList()[i].UserName)
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidatePassword(string password)
        {
            if(password.Length < 4)
            {
                return false;
            }
            return true;
        }
    }
}
