using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fintech.Models;
using Fintech.DTOs;
using AutoMapper;
using Fintech.DA;

namespace Fintech.Controllers
{
    public class CreditRequestsController : Controller
    {
        private readonly FintechContext _context;
        private readonly IMapper _mapper;
        private readonly ICreditRequestsDA _creditRequestsDA;


        public CreditRequestsController(FintechContext context, IMapper mapper, ICreditRequestsDA creditRequestsDA)
        {
            _context = context;
            _mapper = mapper;
            _creditRequestsDA = creditRequestsDA;
        }


        [HttpPost]
        [Route("CreateCreditRequest")]
        public async Task<IActionResult> CreateCreditRequest([FromBody] CreditRequestDTO creditRequest)
        {
            var creditRequestVO = _mapper.Map<CreditRequest>(creditRequest);
            var customerVO = _mapper.Map<Customer>(creditRequest.CustomerDto);

            await _creditRequestsDA.CreateCreditRequest(creditRequestVO, customerVO);

            creditRequest.Id = creditRequestVO.Id;


            return Ok(_mapper.Map<CreditRequestDTO>(creditRequestVO)); 
        }



        [HttpGet]
        [Route("CreditRequestPenddingApproved")]
        public async Task<IActionResult> CreditRequestPenddingApproved()
        {
            List<CreditRequestDTO> creditRequestVO = _creditRequestsDA.GetCreditRequestPenddingApproved();

            return Ok(creditRequestVO);
        }

        // GET: CreditRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CreditRequests == null)
            {
                return NotFound();
            }

            CreditRequestDTO creditRequestDTO = await _creditRequestsDA.GetCreditRequestDetails(id);

            /*var creditRequest = await _context.CreditRequests
                .FirstOrDefaultAsync(m => m.Id == id);*/
            if (creditRequestDTO == null)
            {
                return NotFound();
            }

            return View(creditRequestDTO);
        }

        [HttpPost]
        [Route("CreateCreditEvaluation")]
        public async Task<IActionResult> CreateCreditEvaluation([FromBody] CreditEvaluationDTO creditRequest)
        {
            var ceditEvaluationVO = _mapper.Map<CreditEvaluation>(creditRequest);
            

            await _creditRequestsDA.CreateCreditEvaluation(ceditEvaluationVO);


            return Ok(_mapper.Map<CreditEvaluationDTO>(ceditEvaluationVO));
        }



        [Route("prueba")]
        public async Task<IActionResult> GetPrueba()
        {
            return _context.CreditRequests != null ?
                        View(await _context.CreditRequests.ToListAsync()) :
                        Problem("Entity set 'FintechContext.CreditRequest'  is null.");
        }


        // GET: CreditRequests
        public async Task<IActionResult> Index()
        {
              return _context.CreditRequests != null ? 
                          View(await _context.CreditRequests.ToListAsync()) :
                          Problem("Entity set 'FintechContext.CreditRequest'  is null.");
        }

        

        // GET: CreditRequests/Create
        public IActionResult Create()
        {
            return View();
        }

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
    }
}
