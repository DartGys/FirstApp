export class BoardInputModel{
  id = '';
  name = '';

  validate(): {[key: string]: string[] } {
    const errors: { [key: string]: string[] } = {};

    if (!this.name.trim()) {
      errors['name'] = ['Board name is required'];
    } else if (this.name.length > 100) {
      errors['name'] = ['Board name must be less than 100 characters'];
    }

    return errors;
  }
}
