export class CardlistVm{
  id= '';
  name= '';
  cards: CardVmList[] = [];
}

export class CardVmList{
  id= '';
  name= '';
  description= '';
  dueDate: Date = new Date();
  priorityName= '';
  cardListId='';
}
