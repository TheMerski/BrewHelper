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
