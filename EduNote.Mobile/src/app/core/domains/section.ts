import { Question } from './Question';
import { Note } from './note';

export class Section {
    id: number;
    title: string;
    description: string;
    parentId: number;
    sections: Section[];
    questions: Question[];
    notes: Note[];
}
