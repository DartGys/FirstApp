using AutoMapper;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.InputModels;
using TaskBoard.BLL.Models.ViewModels.List;
using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.BLL.Services;

public class BoardService : IBoardService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BoardService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BoardVm>> GetAsync()
    {
        var entities = await _unitOfWork.Board.GetAllAsync();

        var boards = _mapper.Map<IEnumerable<BoardVm>>(entities);

        boards = boards.Select(board =>
        {
            board.CardListCount = _unitOfWork.Board.GetCardListCount(board.Id);
            board.CardCount = _unitOfWork.Board.GetCardCount(board.Id);
            return board;
        });

        return boards;
    }

    public async Task AddAsync(BoardInputModel input)
    {
        var entity = _mapper.Map<Board>(input);

        await _unitOfWork.Board.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task UpdateAsync(BoardInputModel input)
    {
        var entity = _mapper.Map<Board>(input);
        
        _unitOfWork.Board.Update(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = new Board() { Id = id };
        
        _unitOfWork.Board.Remove(entity);
        await _unitOfWork.SaveChangeAsync();
    }
}