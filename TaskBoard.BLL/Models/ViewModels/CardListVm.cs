namespace TaskBoard.BLL.Models.ViewModels.List;

public class CardListVm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IReadOnlyList<CardVmList> Cards { get; set; }
}