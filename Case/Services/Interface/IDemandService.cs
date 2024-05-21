using Case.Dtos;

namespace Case.Services.Interface
{
    public interface IDemandService
    {
        Task CreateAsyncDemand(DemandCreateDto demandCreateDto);
        Task<List<DemandOptionDto>> GetDemandOption();
        Task<TableDto<DemandTableDto>> GetAllDemands(int start, int length, int draw);
    }
}
