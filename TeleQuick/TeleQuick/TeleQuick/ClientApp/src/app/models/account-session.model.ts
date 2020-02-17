// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

export class AccountSession {
    constructor(id?: number, loginUser?: string, loginUserPassword?: string, isValid?: boolean,
        concessionaryName?: string ) {
        this.id = id;
        this.loginUser = loginUser;
        this.loginUserPassword = loginUserPassword;
        this.isValid = isValid;
        this.concessionaryName = concessionaryName;
    }

    public id: number;
    public loginUser: string;
    public loginUserPassword: string;
    public isValid: boolean;
    public concessionaryName: string;
}