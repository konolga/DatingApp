import { Photo } from './photo';

export interface User {
  id: number;
  email: string;
  name: string;
  lastName: string;
  password: string;
  confirmPassword: string;
  created?: Date;
  lastActive?: Date;
  photoUrl?: string;
  city?: string;
  country?: string;
  interests?: string;
  introduction?: string;
  lookingFor?: string;
  photos?: Photo[];
}
