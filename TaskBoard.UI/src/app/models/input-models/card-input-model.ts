export class CardInputModel{
  id= '';
  name= '';
  description= '';
  dueDate: Date = new Date();
  priorityId= '';
  cardListId= '';

  validate(): {[key: string]: string[] } {
    const errors: { [key: string]: string[] } = {};

    if (!this.name.trim()) {
      errors['name'] = ['Card name is required'];
    } else if (this.name.length > 100) {
      errors['name'] = ['Card name must be less than 100 characters'];
    }

    if (this.dueDate.getDate() < Date.now())
    {
      errors['dueDate'] = ['Choose correct date'];
    }

    if(this.priorityId === '')
    {
      errors['priority'] = ['Choose priority'];
    }

    if(this.cardListId === '')
    {
      errors['cardList'] = ['Choose list'];
    }

    return errors;
  }
}
