import { Message } from "./message";

export class Subject {
    _id : string;
    title : string;
    likes: number;
    messages: Message[];
    createdDate: Date;
    updatedDate: Date;
}