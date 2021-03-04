export interface Ingredient {
  id: number;
  name: string;
  description?: string;
  type: IngredientType;
}

export enum IngredientType {
  MALT = 'Malt',
  SUGAR = 'Sugar',
  HOP = 'Hop',
  YEAST = 'Yeast',
  HERB = 'Herb',
}

export function CreateIngredientQueryFilter(filter: any): string {
  let filterQuery = '';
  if (typeof filter.Name != undefined && filter.Name != null) {
    filterQuery += `&Name=${filter.Name}`;
  }
  if (
    typeof filter.type != undefined &&
    filter.type != null &&
    filter.type.length > 0
  ) {
    for (let type of filter.type) {
      if (type != null) filterQuery += `&Types=${type}`;
    }
  }
  return filterQuery;
}