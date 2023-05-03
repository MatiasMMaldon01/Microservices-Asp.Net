using Rutine.Domain.Entities;
using Rutine.Domain.Interfaces;
using Rutine.IService.Base.DTO;
using Rutine.IService.Exercise;
using Rutine.IService.Exercise.DTO;
using System.Linq.Expressions;

namespace Rutine.Service.ExerciseService
{
    public class ExerciseService : IExerciseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExerciseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(BaseDTO entity)
        {
            var dto = (ExerciseDTO) entity;

            int newExercise = _unitOfWork.ExerciseRepository.Create(new Exercise
            {
                Description = dto.Description,
                Muscle = dto.Muscle,
            });

            _unitOfWork.Commit();

            return newExercise;

        }

        public void Update(BaseDTO entity)
        {
            var dto = (ExerciseDTO)entity;

            var exerciseUpdate = _unitOfWork.ExerciseRepository.Get(dto.Id);

            if (exerciseUpdate == null) throw new Exception("Exercise not found");
            
            exerciseUpdate.Description = dto.Description;
            exerciseUpdate.Muscle = dto.Muscle;

            _unitOfWork.ExerciseRepository.Update(exerciseUpdate);

            _unitOfWork.Commit();

        }

        public void Delete(int id)
        {
            _unitOfWork.ExerciseRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public BaseDTO Get(int id)
        {
            var exercise = _unitOfWork.ExerciseRepository.Get(id);
            if (exercise == null) throw new Exception($"Exercise with id {id} not found");

            return new ExerciseDTO
            {
                Id = exercise.Id,
                Description = exercise.Description,
                Muscle = exercise.Muscle,
            };
        }

        public IEnumerable<BaseDTO> Get(string filter)
        {
            Expression<Func<Exercise, bool>> filterExpression = x => x.Muscle.Contains(filter) || x.Description.Contains(filter) ;

            var exercise = _unitOfWork.ExerciseRepository.Get(filterExpression);

            if (exercise == null) throw new Exception($"Opss... no values here");

            return exercise.Select(e => new ExerciseDTO
            {
                Id = e.Id,
                Description = e.Description,
                Muscle = e.Muscle,

            }).OrderBy(e => e.Muscle)
                .ToList();
        }

        public IEnumerable<BaseDTO> GetAll()
        {
            var exercise = _unitOfWork.ExerciseRepository.GetAll();

            if (exercise == null) throw new Exception($"Opss... no values here");

            return exercise.Select(e => new ExerciseDTO
            {
                Id = e.Id,
                Description = e.Description,
                Muscle = e.Muscle,

            }).OrderBy(e => e.Muscle)
                .ToList();
        }

    }
}
