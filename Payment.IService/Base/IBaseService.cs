using Payment.IService.Base.DTO;

namespace Payment.IService.Base
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
