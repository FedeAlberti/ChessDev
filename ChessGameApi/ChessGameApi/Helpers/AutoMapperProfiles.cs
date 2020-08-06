using AutoMapper;
using ChessGameApi.DTOs;
using ChessGameApi.Models;
using ChessGameAPI.Dtos;

namespace ChessGameApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Piece, PieceDto>()
                .ForMember(dest => dest.color, opt =>
            {
                opt.MapFrom(srs => srs.Color.ToString());
            }).ForMember(dest => dest.pieceType, opt =>
            {
                opt.MapFrom(srs => srs.PieceType.ToString());
            }).ForPath(dest => dest.possibleMoves.Keys, opt =>
            {
                opt.Ignore();
            });


            CreateMap<Game, GameDto>()
                .ForMember(x => x.Pieces, opt => 
                opt.MapFrom(srs => srs.Pieces));

            CreateMap<PieceToMove, PieceToMoveDto>();

        }
    }
}
