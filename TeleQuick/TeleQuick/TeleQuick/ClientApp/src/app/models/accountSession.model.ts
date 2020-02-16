// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

export class AccountSession {
    constructor(loginUser?: string, loginUserPassword?: string, rememberMe?: boolean) {
        this.loginUser = loginUser;
        this.loginUserPassword = loginUserPassword;
        this.rememberMe = rememberMe;
    }

    loginUser: string;
    loginUserPassword: string;
    rememberMe: boolean;
}