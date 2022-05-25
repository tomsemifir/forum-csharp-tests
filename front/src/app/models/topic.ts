import { Message } from "./message";

export class Topic {
    id : number;
    title : string;
    messages: Message[];
    createdDate: Date;
    updatedDate: Date;
}