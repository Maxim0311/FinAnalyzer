import { IconAuthor } from '../../components/ui/Icon';

export interface ICategory {
  id: number;
  name: string;
  description: string | null;
  isExpenditure: boolean;
  iconAuthor: IconAuthor;
  iconName: string;
  iconColor: string;
}

export interface ICategoryCreate {
  name: string;
  description?: string;
  isExpenditure: boolean;
  iconAuthor?: IconAuthor;
  iconName: string;
  iconColor: string;
}

export interface ICategoryUpdate {
  id: number;
  name: string;
  description?: string;
  isExpenditure: boolean;
  iconAuthor?: IconAuthor;
  iconName: string;
  iconColor: string;
}
