using customhost_backend.crm.Domain.Models.Aggregates;
using customhost_backend.crm.Domain.Models.Commands;
using customhost_backend.crm.Domain.Repositories;
using customhost_backend.Shared.Domain.Repositories;

namespace customhost_backend.crm.Application.Internal.CommandServices;

public class ServiceRequestCommandRepository
(IServiceRequestRepository serviceRequestRepository, IUnitOfWork unitOfWork)
{
    public async Task<ServiceRequest?> Handle(CreateServiceRequestCommand command)
    {
        var serviceRequest = new ServiceRequest(command);
        await serviceRequestRepository.AddAsync(serviceRequest);
        await unitOfWork.CompleteAsync();
        return serviceRequest;
    }
}