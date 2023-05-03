using Members.Domain.Entities;
using Members.Domain.Interfaces;
using Members.IServicio.Base.DTO;
using Members.IServicio.Members;
using Members.IServicio.Members.DTO;
using Members.IServicio.User;
using Members.IServicio.User.DTO;
using MongoDB.Bson;
using Common;
using System.Linq.Expressions;

namespace Members.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repositoryUser;
        private readonly IMemberService _memberService;


        public UserService(IRepository<User> repository, IMemberService memberService)
        {
            _repositoryUser = repository;
            _memberService = memberService;
        }

        public void Create(BaseDTO entity)
        {
            var dto = (UserDTO)entity;

            var newUser = new User
            {
                UserName = dto.UserName,
                Password = PasswordEncrypt.GetSHA256(dto.Password),
                MemberId = dto.MemberId
            };

            _repositoryUser.Create(newUser);
        }

        public void Update(BaseDTO entity)
        {
            var dto = (UserDTO)entity;
            ObjectId _id = new ObjectId(dto.Id);

            var newUser = new User
            {
                Id = _id,
                UserName = dto.UserName,
                Password = dto.Password,
                MemberId = dto.MemberId,
            };

            _repositoryUser.Update(newUser);
        }

        public void Delete(string id)
        {
            _repositoryUser.Delete(id);
        }

        public BaseDTO GetById(string id)
        {
            var User = _repositoryUser.GetById(id);

            return new UserDTO
            {
                Id = User.Id.ToString(),
                UserName = User.UserName,
                Password = User.Password,
                MemberId = User.MemberId,
                Member = (MemberDTO)_memberService.GetById(User.MemberId),
                CreatedAt = User.CreatedAt,
            };
        }

        public IEnumerable<BaseDTO> GetAll()
        {
            var request = _repositoryUser.GetAll();

            return request.Select(m => new UserDTO
            {
                Id = m.Id.ToString(),
                UserName = m.UserName,
                Password = m.Password,
                MemberId = m.MemberId,
                Member = (MemberDTO)_memberService.GetById(m.MemberId),
                CreatedAt = m.CreatedAt,
            })
                .OrderBy(m => m.CreatedAt)
                .ToList();
        }

        public IEnumerable<BaseDTO> GetByFilter(string stringToFind)
        {
            Expression<Func<User, bool>> filter = x => x.UserName.ToLower().Contains(stringToFind.ToLower());

            var request = _repositoryUser.GetByFilter(filter);

            return request.Select(m => new UserDTO
            {
                Id = m.Id.ToString(),
                UserName = m.UserName,
                Password = m.Password,
                Member = (MemberDTO)_memberService.GetById(m.MemberId),
                CreatedAt = m.CreatedAt,
            })
                .OrderBy(m => m.CreatedAt)
                .ToList();
        }

        // ================================ Private Methods ================================ //

    }
}
