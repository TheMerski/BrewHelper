import { Recipe } from './Recipe';

export interface BrewLog {
  id: string;
  recipe?: Recipe;
  recipeId: number;
  notes?: string;
  startDate: Date;
  endDate?: Date;
  startSG?: number;
  endSG?: number;
  alcoholPercentage?: number;
  yield?: number;
  ibu?: number;
  ebc?: number;
  mashingLog: StepLog;
  boilingLog: StepLog;
  yeastingLog: StepLog;
}

export interface StepLog {
  id: number;
  start: Date;
  end?: Date;
  notes?: string;
  temperatureMeasurements: Measurement[];
  phMeasurements: Measurement[];
  sgMeasurements: Measurement[];
}

export interface Measurement {
  id: number;
  values: number;
  time: Date;
  notes?: string;
}
