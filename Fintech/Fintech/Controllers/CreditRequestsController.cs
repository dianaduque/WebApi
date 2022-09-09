using AutoMapper;
using Fintech.Application.Services;
using Fintech.DA;
using Fintech.Domain.Model;
using Fintech.DTOs;
using Fintech.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class CreditRequestsController : Controller
    {/*
        private readonly FintechContext _context;
        private readonly IMapper _mapper;
        private readonly ICreditRequestsDA _creditRequestsDA;
        private readonly ICustomerDA _customerDA;
        private readonly IEmailService _emailService;
        private readonly IFileService _fileService;
        private const string approval_message = "Su credito ha sido aprobado y uno de nuestros analistas se contactara con usted para indicarle el resto del proceso.";
        private const string reject_message = "Su credito ha sido rechazado. De acuerdo a las siguientes observaciones: ";



        public CreditRequestsController(FintechContext context, IMapper mapper, ICreditRequestsDA creditRequestsDA, ICustomerDA customerDA, IEmailService emailService, IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _creditRequestsDA = creditRequestsDA;
            _emailService = emailService;
            _customerDA = customerDA;
            _fileService = fileService;
        }



        [HttpPost]
        [Route("credit/property")]
        public async Task<IActionResult> UploadFile()
        {
            IFormFile file = HttpContext.Request.Form.Files[0];

            if (file.Length <= 0)
                return BadRequest("Empty file");

            string uniqueFilePath = await _fileService.SaveFile(file);

            int id = await _creditRequestsDA.CreateCreditRequest(uniqueFilePath);

            return Ok(_mapper.Map<int>(id));
        }


        [HttpPost]
        [Route("credit")]
        public async Task<IActionResult> CreateCreditRequest([FromBody] CreditRequestDTO creditRequest)
        {

            var creditRequestVO = _mapper.Map<CreditRequest>(creditRequest);
            var customerVO = _mapper.Map<Customer>(creditRequest.CustomerDto);


            creditRequestVO = await _creditRequestsDA.UpdateCreditRequest(creditRequestVO, customerVO);

            var customerDTO = _mapper.Map<CustomerDTO>(customerVO);
            var creditRequestDTO = _mapper.Map<CreditRequestDTO>(creditRequestVO);
            creditRequestDTO.CustomerDto = customerDTO;

            return Ok(creditRequestDTO);

        }



        [HttpGet]
        [Route("credit/analyst")]
        public async Task<IActionResult> CreditRequestPenddingApproved()
        {
            List<CreditRequestDTOPending> creditRequestVO = _creditRequestsDA.GetCreditRequestPenddingApproved();

            return Ok(creditRequestVO);
        }

        [Route("credit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CreditRequests == null)
            {
                return NotFound();
            }

            CreditRequestDTOPending creditRequestDTO = await _creditRequestsDA.GetCreditRequestDetails(id);

            if (creditRequestDTO == null)
            {
                return NotFound();
            }

            return Ok(creditRequestDTO);
        }

        [HttpPost]
        [Route("credit/evaluate")]
        public async Task<IActionResult> CreateCreditEvaluation([FromBody] CreditEvaluationDTO creditRequest)
        {
            var ceditEvaluationVO = _mapper.Map<CreditEvaluation>(creditRequest);
            
            await _creditRequestsDA.CreateCreditEvaluation(ceditEvaluationVO);

            string to = _customerDA.GetEmailCustomer(ceditEvaluationVO.CreditRequest);

            _emailService.Send(to, "Evaluacion Solicitud", creditRequest.IsApproved ? approval_message : reject_message + creditRequest.Comments);

            return Ok(_mapper.Map<CreditEvaluationDTO>(ceditEvaluationVO));
        }*/

/*


        // POST: CreditRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Customer,AmountRequest,Comments")] CreditRequestDTO creditRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creditRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(creditRequest);
        }

        // GET: CreditRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CreditRequests == null)
            {
                return NotFound();
            }

            var creditRequest = await _context.CreditRequests.FindAsync(id);
            if (creditRequest == null)
            {
                return NotFound();
            }
            return View(creditRequest);
        }

        // POST: CreditRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Customer,AmountRequest,Comments")] CreditRequest creditRequest)
        {
            if (id != creditRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditRequestExists(creditRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(creditRequest);
        }

        // GET: CreditRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CreditRequests == null)
            {
                return NotFound();
            }

            var creditRequest = await _context.CreditRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (creditRequest == null)
            {
                return NotFound();
            }

            return View(creditRequest);
        }

        // POST: CreditRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CreditRequests == null)
            {
                return Problem("Entity set 'FintechContext.CreditRequest'  is null.");
            }
            var creditRequest = await _context.CreditRequests.FindAsync(id);
            if (creditRequest != null)
            {
                _context.CreditRequests.Remove(creditRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditRequestExists(int id)
        {
          return (_context.CreditRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
*/
    }
}
