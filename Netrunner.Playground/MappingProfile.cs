using AutoMapper;
using Netrunner.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netrunner.Playground
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ExternalCard, Card>()
            .ForMember(destinationMember => destinationMember.Cost, opt => opt.MapFrom(src => src.CostForPlay))
            .ForMember(destinationMember => destinationMember.Description, opt => opt.MapFrom(src => src.DescriptionForCard))
            .ForMember(destinationMember => destinationMember.PlayerType, opt => opt.Ignore())
            .ForMember(destinationMember => destinationMember.CardId, opt => opt.MapFrom(src => src.UniqIdForExternalBase))
            .ForMember(destinationMember => destinationMember.Name, opt => opt.MapFrom(src => src.NameOfCorp))
            .ReverseMap();

        }
    }
}
