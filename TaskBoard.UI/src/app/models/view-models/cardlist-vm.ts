export class CardlistVm{
  id: string;
  name: string;
  cards: CardVmList[];
}

export class CardVmList{
  id: string;
  name: string;
  description: string;
  dueDate: Date;
  priorityName: string;
}
