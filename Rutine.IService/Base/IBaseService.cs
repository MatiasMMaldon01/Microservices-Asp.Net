using Rutine.IService.Base.DTO;
using System.Linq.Expressions;

namespace Rutine.IService.Base
{
    public interface IBaseService
    {
        int Create(BaseDTO entity);
        void Update(BaseDTO entity);
        void Delete(int id);


        BaseDTO Get(int id);
        IEnumerable<BaseDTO> Get(string filter);
        IEnumerable<BaseDTO> GetAll();
    }
}
