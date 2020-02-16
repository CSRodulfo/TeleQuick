// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

export class AccountSession {
    constructor(id?: number, loginUser?: string, loginUserPassword?: string, isValid?: boolean) {
        this.id = id;
        this.loginUser = loginUser;
        this.loginUserPassword = loginUserPassword;
        this.isValid = isValid;
    }

    public id: number;
    public loginUser: string;
    public loginUserPassword: string;
    public isValid: boolean;
}