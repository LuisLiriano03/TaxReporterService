using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaxReporter.Contracts;
using TaxReporter.DTOs.Invoice;
using TaxReporter.Entities;
using TaxReporter.Repository.Contract;
using TaxReporter.Enums;
using TaxReporter.Exceptions.Invoice;
using TaxReporter.Validators.Invoice;
using TaxReporter.Validators.User;
using FluentValidation;

namespace TaxReporter.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IGenericRepository<InvoiceInfo> _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IGenericRepository<InvoiceInfo> invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<GetInvoice> Register(CreateInvoice model)
        {
            try
            {

                var validator = new CreateInvoiceValidator();
                var validationResult = validator.Validate(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                    throw new TaskCanceledException($"{string.Join(", ", errors)}");
                }

                var invoiceInfo = _mapper.Map<InvoiceInfo>(model);

                invoiceInfo.StateId = (int)InvoiceStatus.Pending;

                var invoiceCreated = await _invoiceRepository.CreateAsync(invoiceInfo);

                var invoiceException = invoiceCreated.InvoiceId == (int)InvoiceCreationOption.DoNotCreate ? throw new InvoiceNotCreatedException() : invoiceCreated;

                var query = await _invoiceRepository.VerifyDataExistenceAsync(u => u.InvoiceId == invoiceCreated.InvoiceId);

                invoiceCreated = query.Include(rol => rol.User)
                    .Include(a => a.State).First();

                return _mapper.Map<GetInvoice>(invoiceCreated);
            }
            catch
            {
                throw;
            }

        }

        public async Task<List<GetInvoice>> GetAsync()
        {
            try
            {
                var invoiceQuery = await _invoiceRepository.VerifyDataExistenceAsync();
                var invoicesWithInclude = invoiceQuery
                    .Include(rol => rol.User)
                    .Include(rol => rol.State)
                    .ToList();

                return _mapper.Map<List<GetInvoice>>(invoicesWithInclude);
            }
            catch
            {
                throw new GetInvoiceFailedException();
            }

        }

        private async Task<List<GetInvoice>> GetInvoicesByStatusAsync(InvoiceStatus status)
        {
            try
            {
                var invoiceQuery = await _invoiceRepository
                    .VerifyDataExistenceAsync(invoice => invoice.StateId == (int)status);

                var invoicesWithInclude = invoiceQuery
                    .Include(invoice => invoice.User)
                    .Include(invoice => invoice.State)
                    .ToList();

                return _mapper.Map<List<GetInvoice>>(invoicesWithInclude);
            }
            catch
            {
                throw new GetInvoiceFailedException();
            }

        }

        public async Task<List<GetInvoice>> GetPendingInvoicesAsync()
        {
            return await GetInvoicesByStatusAsync(InvoiceStatus.Pending);
        }

        public async Task<List<GetInvoice>> GetApprovedInvoicesAsync()
        {
            return await GetInvoicesByStatusAsync(InvoiceStatus.Approved);
        }

        public async Task<List<GetInvoice>> GetUnapprovedInvoicesAsync()
        {
            return await GetInvoicesByStatusAsync(InvoiceStatus.NotApproved);
        }

        private async Task<List<GetInvoice>> GetInvoicesByUserAsync(int userId, InvoiceStatus stateId)
        {
            try
            {
                var assignedInvoices = await _invoiceRepository
                    .VerifyDataExistenceAsync(invoice => invoice.UserId == userId && invoice.StateId == (int)stateId);

                string noInvoicesFound = assignedInvoices == null || !assignedInvoices.Any() ? throw new GetInvoiceFailedByUserException() : null;

                var invoicesWithInclude = assignedInvoices
                    .Include(user => user.User)
                    .Include(user => user.State);

                var invoiceList = await invoicesWithInclude.ToListAsync();

                return _mapper.Map<List<GetInvoice>>(invoiceList);
            }
            catch
            {
                throw;
            }

        }

        public async Task<List<GetInvoice>> GetPendingInvoiceByUser(int userId)
        {
            return await GetInvoicesByUserAsync(userId, InvoiceStatus.Pending);
        }

        public async Task<List<GetInvoice>> GetApprovedInvoiceByUser(int userId)
        {
            return await GetInvoicesByUserAsync(userId, InvoiceStatus.Approved);
        }

        public async Task<List<GetInvoice>> GetUnapprovedInvoiceByUser(int userId)
        {
            return await GetInvoicesByUserAsync(userId, InvoiceStatus.NotApproved);
        }

        public async Task<bool> UpdateAsync(UpdateInvoice model)
        {
            try
            {

                var validator = new UpdateInvoiceValidator();
                var validationResult = await validator.ValidateAsync(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException(string.Join(", ", errors));
                }

                var invoiceModel = _mapper.Map<InvoiceInfo>(model);
                var invoiceFound = await _invoiceRepository.GetEverythingAsync(u => u.InvoiceId == invoiceModel.InvoiceId);

                var invoiceToUpdate = invoiceFound ?? throw new InvoiceNotFoundException();

                invoiceToUpdate.UserId = invoiceModel.UserId;
                invoiceToUpdate.BusinessName = invoiceModel.BusinessName;
                invoiceToUpdate.Rnc = invoiceModel.Rnc;
                invoiceToUpdate.Nfc = invoiceModel.Nfc;
                invoiceToUpdate.AmountWithoutItbis = invoiceModel.AmountWithoutItbis;
                invoiceToUpdate.Itbis = invoiceModel.Itbis;
                invoiceToUpdate.ServicePercentage = invoiceModel.ServicePercentage;
                invoiceToUpdate.TotalAmount = invoiceModel.TotalAmount;
                invoiceToUpdate.ImageUrl = invoiceModel.ImageUrl;

                bool response = await _invoiceRepository.UpdateAsync(invoiceFound);

                bool isUpdateSuccessful = !response ? throw new UpdateInvoiceFailedException() : response;

                return response;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> UpdateStateAsync(UpdateState model)
        {
            try
            {
                var validator = new UpdateStateInvoiceValidator();
                var validationResult = await validator.ValidateAsync(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException(string.Join(", ", errors));
                }

                var invoiceModel = _mapper.Map<InvoiceInfo>(model);

                var invoiceFound = await _invoiceRepository.GetEverythingAsync(u => u.InvoiceId == invoiceModel.InvoiceId);

                var invoiceToUpdate = invoiceFound ?? throw new InvoiceNotFoundException();

                invoiceToUpdate.StateId = invoiceModel.StateId;

                bool response = await _invoiceRepository.UpdateAsync(invoiceFound);

                bool isUpdateSuccessful = !response ? throw new UpdateInvoiceFailedException() : response;

                return response;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> DeleteAsync(int invoiceId)
        {
            try
            {
                var invoiceFound = await _invoiceRepository.GetEverythingAsync(u => u.InvoiceId == invoiceId);

                var invoiceDelete = invoiceFound ?? throw new InvoiceNotFoundException();

                bool response = await _invoiceRepository.DeleteAsync(invoiceFound);

                var isDeleteSuccessful = response ? response : throw new DeleteInvoiceFailedException();

                return response;
            }
            catch
            {
                throw new DeleteInvoiceErrorFailedException();
            }

        }

    }

}
