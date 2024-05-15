import {CardlistVm} from "../../../models/view-models/cardlist-vm";
import {CardInputModel} from "../../../models/input-models/card-input-model";
import {CardVmDetails} from "../../../models/view-models/card-vm-details";


export interface CardStateInterface{
  isLoading: boolean;
  cardLists: CardlistVm[];
  card: CardVmDetails | undefined;
  cardInput: CardInputModel | undefined;
  error: string | null;
  Id: string | undefined;
}
