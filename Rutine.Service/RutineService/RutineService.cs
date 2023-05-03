using Rutine.Domain.Entities;
using Rutine.Domain.Interfaces;
using Rutine.IService.Base.DTO;
using Rutine.IService.Rutine;
using Rutine.IService.Rutine.DTO;
using System.Linq.Expressions;
using System.Transactions;

namespace Rutine.Service.RutineService
{
    public class RutineService : IRutineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RutineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(BaseDTO entity)
        {
            using (var tran = new TransactionScope())
            {
                try
                {

                    var dto = (RutineDTO) entity;

                    var rutine = new Domain.Entities.Rutine
                    {
                        MemberId = dto.MemberId,
                        StartDate = dto.StartDate,
                        EndDate = dto.EndDate,
                        RutineDetails = new List<RutineDetail>(),
                    };


                    foreach(var detail in dto.RutineDetails)
                    {
                        rutine.RutineDetails.Add(new RutineDetail
                        {
                            ExerciseId = detail.ExerciseId,
                            DayOfWeek = detail.DayOfWeek,
                            Reps = detail.Reps,
                            Series = detail.Series,
                            Weight = detail.Weight,
                        });
                        
                    }

                    var rutineId = _unitOfWork.RutineRepository.Create(rutine);
                    _unitOfWork.Commit();
                    
                    tran.Complete();
                    return rutineId;
                }
                catch
                {
                    tran.Dispose();
                    throw new Exception("Failed creating the rutine");
                }
            }
        }

        // TODO: Update Rutine
        public void Update(BaseDTO entity)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    var dto = (RutineDTO)entity;

                    var rutineToUpdate = _unitOfWork.RutineRepository.Get(dto.Id, "RutineDetails, RutineDetails.Exercise");

                    if (rutineToUpdate == null) throw new Exception("Rutine not found");

                    var rutine = new Domain.Entities.Rutine
                    {
                        Id = rutineToUpdate.Id,
                        MemberId = dto.MemberId,
                        StartDate = dto.StartDate,
                        EndDate = dto.EndDate,
                    };


                    foreach (var detail in dto.RutineDetails)
                    {
                        var detailToUpdate = new RutineDetail
                        {
                            Id = detail.Id,
                            ExerciseId = detail.ExerciseId,
                            DayOfWeek = detail.DayOfWeek,
                            Reps = detail.Reps,
                            Series = detail.Series,
                            Weight = detail.Weight,
                        };

                        _unitOfWork.RutineDetailRepository.Update(detailToUpdate);

                    }

                    _unitOfWork.RutineRepository.Update(rutine);
                    _unitOfWork.Commit();

                    tran.Complete();
                }
                catch
                {
                    tran.Dispose();
                    throw new Exception("Failed updating the rutine");
                }
            }
        }

        public void Delete(int id)
        {
            _unitOfWork.RutineRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public BaseDTO Get(int id)
        {
            var rutine = _unitOfWork.RutineRepository.Get(id, "RutineDetails, RutineDetails.Exercise");

            if (rutine == null) throw new Exception($"Opss... no values here");

            return new RutineDTO
            {
                Id = rutine.Id,
                MemberId = rutine.MemberId,
                StartDate = rutine.StartDate,
                EndDate = rutine.EndDate,
                RutineDetails = rutine.RutineDetails.Select(d => new RutineDetailDTO
                {
                    Id = d.Id,
                    ExerciseId = d.ExerciseId,
                    Exercise = d.Exercise.Description,
                    DayOfWeek = d.DayOfWeek,
                    DayOfWeekStr = d.DayOfWeek.ToString(),
                    Reps = d.Reps,
                    Series = d.Series,
                    Weight = d.Weight
                }).OrderBy(d => d.DayOfWeek)
                .ToList(),

            };
        }

        public IEnumerable<BaseDTO> Get(string filter)
        {
            Expression<Func<Domain.Entities.Rutine, bool>> filterExpression = f => f.MemberId == filter;

            var rutine = _unitOfWork.RutineRepository.Get(filterExpression, "RutineDetails, RutineDetails.Exercise");

            if (rutine == null) throw new Exception($"Opss... no values here");

            return rutine.Select(r => new RutineDTO
            {
                Id = r.Id,
                MemberId = r.MemberId,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                RutineDetails = r.RutineDetails.Select(d => new RutineDetailDTO
                {
                    Id = d.Id,
                    ExerciseId = d.ExerciseId,
                    Exercise = d.Exercise.Description,
                    DayOfWeek = d.DayOfWeek,
                    DayOfWeekStr = d.DayOfWeek.ToString(),
                    Reps = d.Reps,
                    Series = d.Series,
                    Weight = d.Weight
                }).OrderBy(d => d.DayOfWeek)
                .ToList()

            }).OrderBy(e => e.StartDate)
                .ToList();
        }

        public IEnumerable<BaseDTO> GetAll()
        {
            var rutine = _unitOfWork.RutineRepository.GetAll("RutineDetails, RutineDetails.Exercise");

            if (rutine == null) throw new Exception($"Opss... no values here");

            return rutine.Select(r => new RutineDTO
            {
                Id = r.Id,
                MemberId = r.MemberId,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                RutineDetails = r.RutineDetails.Select(d => new RutineDetailDTO
                {
                    Id = d.Id,
                    ExerciseId = d.ExerciseId,
                    Exercise = d.Exercise.Description,
                    DayOfWeek = d.DayOfWeek,
                    DayOfWeekStr = d.DayOfWeek.ToString(),
                    Reps = d.Reps,
                    Series = d.Series,
                    Weight = d.Weight
                }).OrderBy(d => d.DayOfWeek)
                .ToList()
                
            }).OrderBy(e => e.StartDate)
                .ToList();
        }

    }
}
