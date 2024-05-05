using AutoMapper;
using TaxReporter.Contracts;
using TaxReporter.DTOs.InvoiceState;
using TaxReporter.Entities;
using TaxReporter.Exceptions.InvoiceState;
using TaxReporter.Repository.Contract;

namespace TaxReporter.Services
{
    public class InvoiceStateService : IInvoiceStateService
    {
        public readonly IGenericRepository<InvoiceState> _invoiceStateRepository;
        public readonly IMapper _mapper;

        public InvoiceStateService(IGenericRepository<InvoiceState> invoiceStateRepository, IMapper mapper)
        {
            _invoiceStateRepository = invoiceStateRepository;
            _mapper = mapper;
        }

        public async Task<List<GetState>> GetListAsycn()
        {
            try
            {
                var listRols = await _invoiceStateRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetState>>(listRols.ToList());

            }
            catch
            {
                throw new GetInvoiceStateFailedException();
            }

        }

    }

}
