import { IconAuthor } from '../../components/ui/Icon';

export interface ICategory {
  id: number;
  name: string;
  description: string | null;
  isExpenditure: boolean;
  iconAuthor: IconAuthor;
  iconName: string;
  color: string;
}

export interface ICategoryCreate {
  name: string;
  description?: string;
  isExpenditure: boolean;
}
