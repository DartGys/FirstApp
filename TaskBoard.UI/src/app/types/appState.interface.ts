import {CardListStateInterface} from "../components/cardlist/types/cardListState.interface";
import {CardStateInterface} from "../components/card/types/cardState.interface";


export interface AppStateInterface {
  cardLists: CardListStateInterface;
  card: CardStateInterface;
}
