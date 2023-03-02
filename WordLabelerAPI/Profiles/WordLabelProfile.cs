using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordLabelerAPI.Dtos;
using WordLabelerAPI.Models;

namespace WordLabelerAPI.Profiles
{
    public class WordLabelProfile : Profile
    {
        public WordLabelProfile()
        {
            //TODO: join data from Word and Label or fix in EF
            CreateMap<WordLabel, WordLabelReadDto>();
            CreateMap<WordLabelCreateDto, WordLabel>();
            CreateMap<SentenceDto, Sentence>();
        }
    }
}
