using Application.Common;
using Application.Common.Messaging;
using Application.Features.EmployeeCollection.Commands.AddEmployeeToCollection;

namespace Application.Features.EmployeeCollection.Commands.DeleteEmployeeFromCollection
{
    public record DeleteEmployeeFromCollectionCommand(int id) : ICommand;
    public class DeleteEmployeeFromCollectionCommandHandler : ICommandHandler<DeleteEmployeeFromCollectionCommand>
    {
        private readonly IUOW _uOW;
        public DeleteEmployeeFromCollectionCommandHandler(IUOW uOW)
        {
            this._uOW = uOW;

        }
        public async Task<Result> Handle(DeleteEmployeeFromCollectionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uOW.EmployeeCollectionRepo.GetByIdAsync(request.id);
            if (entity == null)
            {
                return Result.Failure(new Error("404", " الموظف غير موجود "));
            }
            _uOW.EmployeeCollectionRepo.Delete(entity);
            var result = await _uOW.SaveChangesAsync(cancellationToken);
            return result.IsSuccess ? Result.Success() : Result.Failure(new Error(result.ErrorCode, result.Message));
        }
    }
}