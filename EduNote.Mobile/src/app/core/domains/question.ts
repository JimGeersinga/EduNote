import { Answer } from './answer';

export class Question {
    id: number;
    title: string;
    body: string;
    created: Date;
    sectionId: number;
    createdById: number;
    creatorName: string;
    answers:Answer[];
    hasAnswers:boolean = this.answers.length > 0;
}
