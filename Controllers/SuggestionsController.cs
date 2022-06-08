using System;
using System.Threading.Tasks;
using AutoMapper;
using carsaApi.Data;
using carsaApi.Dto;
using carsaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace awamrakeApi.Controllers
{


    [Route("suggestions")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {




        private readonly CarsaApiContext _context;
        private IMapper _mapper;
        public SuggestionsController(IMapper mapper, CarsaApiContext context)
        {

            _mapper = mapper;
            _context = context;

        }



        [HttpGet]
        [Route("get-suggestionses")]
        public async Task<ActionResult> GetAll()
        {
            var data = await _context.Suggestionses.ToListAsync();
            return Ok(data);
        }



        [HttpPost]
        [Route("add-suggestions")]
        public async Task<ActionResult> Createsuggestions([FromForm] Suggestions suggestionsDto)
        {

            var coomansModel = _mapper.Map<Suggestions>(suggestionsDto);
            if (suggestionsDto == null)
            {
                throw new ArgumentNullException(nameof(suggestionsDto));
            }

            await _context.Suggestionses.AddAsync(coomansModel);
            // var commandReadDto = _mapper.Map<suggestionsReadDto>(coomansModel);
            await _context.SaveChangesAsync();

            return Ok(coomansModel);


        }



        [HttpPost]
        [Route("delete-suggestions")]
        public async Task<ActionResult> Deletesuggestions([FromForm] int id)
        {

            var suggestionsModelFromRepo =await _context.Suggestionses.FirstOrDefaultAsync(p => p.Id==id);
            if (suggestionsModelFromRepo == null)
            {
                return NotFound();
            }

            _context.Remove(suggestionsModelFromRepo);
                await _context.SaveChangesAsync();
            return Ok(suggestionsModelFromRepo);



        }




        [HttpPost]
        [Route("update-suggestions")]
        public async Task<ActionResult> Updatesuggestions([FromForm] int id, [FromForm] CreateSuggestions suggestions)
        {
            var brandModelFromRepo =await _context.Suggestionses.FirstOrDefaultAsync(p => p.Id==id);
            if (brandModelFromRepo == null)
            {
                return NotFound();
            }


            _mapper.Map(suggestions, brandModelFromRepo);

            // _repository.Updatesuggestions(brandModelFromRepo);

          await  _context.SaveChangesAsync();

            return Ok(brandModelFromRepo);

        }

    }



}