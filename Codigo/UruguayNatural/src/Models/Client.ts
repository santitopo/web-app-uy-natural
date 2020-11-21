export class Client {
    id: number;
    name: string; 
    surname: string; 
    mail: string; 

    constructor(name: string, surname: string, mail: string, password: string) {
        this.name = name; 
        this.surname = surname; 
        this.mail = mail; 
    }

}