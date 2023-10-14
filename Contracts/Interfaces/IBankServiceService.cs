namespace Contracts;

public interface IBankServiceService
{
    public Task<List<BankServiceDto>> GetList();
}
