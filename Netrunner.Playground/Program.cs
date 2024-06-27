// See https://aka.ms/new-console-template for more information
using AutoMapper;
using Netrunner.Domain.Common;
using Netrunner.Domain.Core;
using Netrunner.Domain.Interface;
using Netrunner.Infrastructure.Implementation;
using System.ComponentModel;

Console.WriteLine("Hello, World!");



var card = new Card()
{ 
    Cost = 10,
    Description = "",
    Name = "Test",
    PlayerType = PlayerType.HaasBioroid

};



var externalApiCard = new ExternalCard()
{
    CostForPlay = 10,
    DescriptionForCard = "123154",
    NameOfCorp = "Haas",
    UniqIdForExternalBase = Guid.NewGuid()
};

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<ExternalCard, Card>()
            .ForMember(destinationMember => destinationMember.Cost, opt => opt.MapFrom(src => src.CostForPlay))
            .ForMember(destinationMember => destinationMember.Description, opt => opt.MapFrom(src => src.DescriptionForCard))
            .ForMember(destinationMember => destinationMember.PlayerType, opt => opt.Ignore())
            .ForMember(destinationMember => destinationMember.CardId, opt => opt.MapFrom(src => src.UniqIdForExternalBase))
            .ForMember(destinationMember => destinationMember.Name, opt => opt.MapFrom(src => src.NameOfCorp))
            .ReverseMap();
});

IMapper _mapper = config.CreateMapper();

var cardOfOurType = _mapper.Map<Card>(externalApiCard);

Console.WriteLine(cardOfOurType.Name + " " + cardOfOurType.Description);


ICardRepository _cardLogic = new CardRepository("Data Source=Amarum;Initial Catalog=Netrunner.Base;Integrated Security=True;Encrypt=False");
//await _cardLogic.AddCard(cardOfOurType);

//var updatableCard = await _cardLogic.GetCardGetById("5A7A4A42-A461-4C8C-AD07-3849EFEA0EC3");

//updatableCard.Name = "Weyland";


//await _cardLogic.RemoveCard("A58C885D-E038-4D5A-88BE-F0F36CE60336");