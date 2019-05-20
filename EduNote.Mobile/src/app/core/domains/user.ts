import { Question } from './question';
import { Note } from './note';

export class User {
    groups: string[];
    questions: Question[];
    answers: string[];
    notes: Note[];
    id: number;
    firstName: string;
    lastName: string;
    email: string;
}
