using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICrud<TModel> where TModel : class
    {
        IEnumerable<TModel> GetAll();
        Task UpdateAsync(TModel model);


    }
}
