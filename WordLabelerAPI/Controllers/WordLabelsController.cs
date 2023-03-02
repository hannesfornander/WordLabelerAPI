using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordLabelerAPI.Data;
using WordLabelerAPI.Dtos;
using WordLabelerAPI.Models;

namespace WordLabelerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordLabelsController : ControllerBase
    {
        private readonly IWordLabelRepository _repository;
        private readonly IMapper _mapper;

        public WordLabelsController(IWordLabelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WordLabelReadDto>> GetAllWordLabels()
        {
            var wordLabels = _repository.GetAllWordLabels();
            return Ok(_mapper.Map<IEnumerable<WordLabelReadDto>>(wordLabels));
        }

        [HttpGet("{id}", Name="GetWordLabelById")]
        public ActionResult<WordLabelReadDto> GetWordLabelById(int id)
        {
            var wordLabel = _repository.GetWordLabelById(id);
            if (wordLabel != null)
            {
                return Ok(_mapper.Map<WordLabelReadDto>(wordLabel));
            }

            return NotFound();
        }

        //TODO: return created wordLabel
        [HttpPost]
        public ActionResult<WordLabelReadDto> CreateWordLabel(WordLabelCreateDto wordLabelCreateDto)
        {
            var wordLabel = _mapper.Map<WordLabel>(wordLabelCreateDto);
            var word = _repository.CreateWordLabel(wordLabel);
            wordLabel.Id = word.WordId;
            //_repository.SaveChanges(); //Les does this here

            var wordLabelReadDto = _mapper.Map<WordLabelReadDto>(wordLabel);

            return CreatedAtRoute(nameof(GetWordLabelById), new { Id = wordLabelReadDto.Id }, wordLabelReadDto);
        }

        [HttpPost("GetWordLabelsFromSentence")]
        public ActionResult<IEnumerable<WordLabelReadDto>> GetWordLabelsFromSentence([FromBody] SentenceDto sentence)
        {
            var wordLabels = _repository.GetWordLabelsFromSentence(_mapper.Map<Sentence>(sentence));
            return Ok(_mapper.Map<IEnumerable<WordLabelReadDto>>(wordLabels));
        }
    }
}
