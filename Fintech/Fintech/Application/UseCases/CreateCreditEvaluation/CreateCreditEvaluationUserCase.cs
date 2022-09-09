using AutoMapper;
using Fintech.Application.Services;
using Fintech.Domain;
using Fintech.Domain.Model;
using Fintech.DTOs;

namespace Fintech.Application.UseCases.CreateCreditEvaluation
{
    public class CreateCreditEvaluationUserCase : ICreateCreditEvaluationUserCase
    {
        private IOutputPort _outputPort;
        private readonly ICreditRepository _creditRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private const string approval_message = "Su credito ha sido aprobado y uno de nuestros analistas se contactara con usted para indicarle el resto del proceso.";
        private const string reject_message = "Su credito ha sido rechazado. De acuerdo a las siguientes observaciones: ";

        public CreateCreditEvaluationUserCase(ICreditRepository creditRepository, IEmailService emailService, ICustomerRepository customerRepository,IMapper mapper)
        {
            _creditRepository = creditRepository;
            _emailService = emailService;
            _outputPort = new CreateCreditEvaluationPresenter();
            _customerRepository = customerRepository;
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task Execute(CreditEvaluationDTO creditRequest)
        {
            var ceditEvaluationVO = _mapper.Map<CreditEvaluation>(creditRequest);
            return CreateCreditEvaluation(ceditEvaluationVO);
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        private async Task CreateCreditEvaluation(CreditEvaluation ceditEvaluationVO)
        {

            ceditEvaluationVO = await _creditRepository.CreateCreditEvaluation(ceditEvaluationVO);

            if (ceditEvaluationVO.Id > 0)
            {
                string to = _customerRepository.GetEmailCustomer(ceditEvaluationVO.CreditRequest);

                _emailService.Send(to, "Evaluacion Solicitud", ceditEvaluationVO.IsApproved ? approval_message : reject_message + ceditEvaluationVO.Comments);

                _outputPort.Ok(ceditEvaluationVO);
                return;
            }
            _outputPort.Invalid();
        }
    }
}

