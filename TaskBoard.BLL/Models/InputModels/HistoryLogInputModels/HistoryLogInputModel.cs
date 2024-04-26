using TaskBoard.BLL.Common.Mapping;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogInputModel : IMapWith<HistoryLog>
{
    public HistoryLogInputModel() {}

    protected HistoryLogInputModel(Guid cardId)
    {
        CardId = cardId;
    }
    public Guid CardId { get; set; }
    public DateTime ChangeDate { get; private set; } = DateTime.UtcNow;
}