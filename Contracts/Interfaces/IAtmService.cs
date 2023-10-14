namespace Contracts
{
    public interface IAtmService
    {
        public Task<List<AtmDto>> GetList(AtmQueryFilter filter);
        public Task<AtmDto> GetById(Guid id); 
    }
}
