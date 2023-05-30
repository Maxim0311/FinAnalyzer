export interface CategoriesStatsResponse {
  name: string;
  value: number;
  color: string;
}

export interface PieDiagramItem {
  name: string;
  value: number;
  color: string;
  legendFontColor: string;
  legendFontSize: number;
}
