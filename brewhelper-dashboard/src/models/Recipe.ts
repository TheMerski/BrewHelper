import { Ingredient } from './Ingredient';

export interface Recipe {
  id: number;
  name: string;
  description?: string;
  startSG: number;
  endSG: number;
  yield: number;
  readyAfter: number;
  alcoholPercentage: number;
  ibu: number;
  ebc: number;
  mashWater: number;
  mashIngredients?: RecipeIngredient[];
  mashSteps?: RecipeStep[];
  rinseWater: number;
  boilingSteps?: RecipeStep[];
  yeastingSteps?: RecipeStep[];
}

export interface RecipeStep {
  id: number;
  name?: string;

  description?: string;
  time: number;
  temperature?: number;
  ingredients?: RecipeIngredient[];
}

export interface RecipeIngredient {
  id: number;
  ingredient: Ingredient;
  weight: number;
}
