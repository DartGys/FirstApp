using TaskBoard.BLL.Models.InputModels;

namespace TaskBoard.WebAPI.Validation;

public static class Validator
{
    public static string Card(CardInputModel input)
    {
        string error = string.Empty;

        if (input == null) return "Card is null";

        if (string.IsNullOrWhiteSpace(input.Name) || input.Name.Length > 100)
        {
            error += "Card name is empty or length more than 100\n";
        };

        if (input.DueDate < DateTime.Now)
        {
            error += "Card dueDate error\n";
        }

        if (input.PriorityId == Guid.Empty)
        {
            error += "Card priority id is empty\n";
        }

        if (input.CardListId == Guid.Empty)
        {
            error += "Card list id is empty";
        }
        
        return error;
    }

    public static string CardList(CardListInputModel input)
    {
        string error = string.Empty;

        if (input == null) return "CardList is null";

        if (string.IsNullOrWhiteSpace(input.Name) && input.Name.Length > 100)
        {
            error += "CardList name is empty or length more than 100\n";
        }

        return error;
    }
}