import {CardlistVm} from "../../../models/view-models/cardlist-vm";

export interface CardListStateInterface {
  isLoading: boolean;
  cardLists: CardlistVm[];
  error: string | null;
  boardId: string | undefined;
  Id: string | undefined;
}


