using Members.IServicio.Base.DTO;

namespace Members.IServicio.Base
{
    public interface IBaseService
    {
        void Create(BaseDTO entity);
        void Update(BaseDTO entity);
        void Delete(string id);


        BaseDTO GetById(string id);
        IEnumerable<BaseDTO> GetAll();
        IEnumerable<BaseDTO> GetByFilter(string stringToFind);
    }
}
