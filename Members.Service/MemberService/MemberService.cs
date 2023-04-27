using Amazon.Runtime.Internal;
using Members.Domain.Entities;
using Members.Domain.Interfaces;
using Members.IServicio.Base.DTO;
using Members.IServicio.Members;
using Members.IServicio.Members.DTO;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace Members.Service.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly IRepository<Member> _repository;

        public MemberService(IRepository<Member> repository)
        {
            _repository = repository;
        }

        public void Create(BaseDTO entity)
        {
            var dto = (MemberDTO)entity;

            var newMember = new Member
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                IsDeleted = false,
            };

            _repository.Create(newMember);
        }

        public void Update(BaseDTO entity)
        {
            var dto = (MemberDTO)entity;
            ObjectId _id = new ObjectId(dto.Id);

            var newMember = new Member
            {
                Id = _id,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                IsDeleted = false,
            };

            _repository.Update(newMember);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public BaseDTO GetById(string id)
        {
            var member = _repository.GetById(id);

            return new MemberDTO
            {
                Id = member.Id.ToString(),
                Name = member.Name,
                Email = member.Email,
                Surname = member.Surname,
                CreatedAt = member.CreatedAt,
                IsDeleted = member.IsDeleted,
            };
        }

        public IEnumerable<BaseDTO> GetAll()
        {
            var request = _repository.GetAll();            

            return request.Select(m => new MemberDTO
            {
                Id = m.Id.ToString(),
                Name = m.Name,
                Surname = m.Surname,
                Email = m.Email,
                CreatedAt = m.CreatedAt,
            })
                .OrderBy(m => m.CreatedAt)
                .ToList();
        }

        public IEnumerable<BaseDTO> GetByFilter(string stringToFind)
        {
            Expression<Func<Member, bool>> filter = x => x.Name.ToLower().Contains(stringToFind.ToLower()) || x.Surname.ToLower().Contains(stringToFind.ToLower());

            var request = _repository.GetByFilter(filter);

            return request.Select(m => new MemberDTO
            {
                Id = m.Id.ToString(),
                Name = m.Name,
                Surname = m.Surname,
                Email = m.Email,
                CreatedAt = m.CreatedAt,
            })
                .OrderBy(m => m.CreatedAt)
                .ToList();
        }

        // TODO: Fix Get Exceptions
    }
}
