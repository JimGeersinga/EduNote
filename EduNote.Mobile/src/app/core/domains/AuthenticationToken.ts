export interface AuthenticationToken {
    token: string;
    refreshToken: string;
    expirationDate: Date;
}
