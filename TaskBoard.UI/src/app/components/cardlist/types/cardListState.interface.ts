import {CardlistVm} from "../../../models/view-models/cardlist-vm";
import {CardlistInputModel} from "../../../models/input-models/cardlist-input-model";

export interface CardListStateInterface {
  isLoading: boolean;
  cardLists: CardlistVm[];
  cardList: CardlistInputModel | undefined;
  error: string | null;
  boardId: string | undefined;
  Id: string | undefined;
}


